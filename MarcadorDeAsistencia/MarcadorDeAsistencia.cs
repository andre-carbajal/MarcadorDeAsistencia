using AForge.Video.DirectShow;
using MarcadorDeAsistencia.Clases;
using MarcadorDeAsistencia.Data;
using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarcadorDeAsistencia
{
    public partial class MarcadorDeAsistencia : Form
    {
        private readonly FaceDetectionService faceDetectionService = new FaceDetectionService();
        private readonly EmpleadoRepository empleadoRepository = new EmpleadoRepository();
        private readonly RegistroDiarioRepository registroDiarioRepository = new RegistroDiarioRepository();
        private readonly FechaRepository fechaRepository = new FechaRepository();
        private readonly EstadoAsistenciaRepository estadoAsistenciaRepository = new EstadoAsistenciaRepository();
        private readonly TurnoRepository turnoRepository = new TurnoRepository();

        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private Empleado empleado;

        private const int toleranciaAsistencia = 15;
        private const int tiempoFalta = 30;

        public MarcadorDeAsistencia()
        {
            InitializeComponent();

            timerHora.Interval = 1000;
            timerHora.Tick += (s, e) => lblHora.Text=FechaUtil.FormatearHora(DateTime.Now);
            timerHora.Start();

            lblFecha.Text = FechaUtil.FormatearFechaLarga(DateTime.Now);
            lblHora.Text = FechaUtil.FormatearHora(DateTime.Now);

            lblValidacion.Text = string.Empty;
            lblNombre.Text = string.Empty;
            lblTipoyHora.Text = string.Empty;

            gbDescanso.Enabled = false;
            this.Load += MarcadorDeAsistencia_Load;
        }

        private void MarcadorDeAsistencia_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(MarcadorDeAsistencia_KeyDown);
        }

        private void MarcadorDeAsistencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnValidar.PerformClick();
                e.Handled = true;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => Close();

        private void btnMinimizar_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        private void btnValidar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("Por favor, ingrese un código.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!(txtCodigo.Text.Length == 8 && txtCodigo.Text.All(char.IsDigit)))
            {
                MessageBox.Show("El código debe tener exactamente 8 números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cleanTxtCodigo();
                return;
            }

            lblValidacion.Text = "Validando código con reconocimiento facial...";
            RunCamara();

            Task.Run(async () =>
            {
                try
                {
                    while (videoSource == null || !videoSource.IsRunning)
                    {
                        System.Threading.Thread.Sleep(100);
                    }

                    await Task.Delay(2000);

                    Bitmap frameCopy = null;
                    pbCamera.Invoke((MethodInvoker)delegate
                    {
                        if (pbCamera.Image != null)
                            frameCopy = new Bitmap(pbCamera.Image);
                    });
                    if (frameCopy == null)
                    {
                        Invoke(new Action(() =>
                        {
                            lblValidacion.Text = "No se pudo capturar la imagen de la cámara.";
                            cleanTxtCodigo();
                            StopCamera();
                        }));
                        return;
                    }

                    var result = await faceDetectionService.DetectPerson(txtCodigo.Text, frameCopy);

                    frameCopy.Dispose();

                    if (result != null && result.result)
                    {
                        Invoke(new Action(() =>
                        {
                            StopCamera();
                            empleado = empleadoRepository.ObtenerEmpleado(txtCodigo.Text);
                            cleanTxtCodigo();

                            var turno = turnoRepository.ObtenerTurno(empleado.idTurno);
                            TimeSpan horaSalidaProgramada = turno.horaFin;
                            TimeSpan horaActual = DateTime.Now.TimeOfDay;
                            TimeSpan dosHorasAntesSalida = horaSalidaProgramada - TimeSpan.FromHours(2);

                            var fecha = fechaRepository.ObtenerOInsertarFecha(DateTime.Today);
                            if (!registroDiarioRepository.ExisteEntrada(empleado.idEmpleado, fecha.idFecha))
                            {
                                TimeSpan horaEntradaProgramada = turnoRepository.ObtenerTurno(empleado.idRol).horaInicio;
                                int minutosRetraso = (int)(horaActual - horaEntradaProgramada).TotalMinutes;

                                int idEstadoAsistencia;

                                if (minutosRetraso <= toleranciaAsistencia)
                                {
                                    idEstadoAsistencia = estadoAsistenciaRepository.obtenerEstado("Asistencia").idEvento;
                                }
                                else if (minutosRetraso >= tiempoFalta)
                                {
                                    idEstadoAsistencia = estadoAsistenciaRepository.obtenerEstado("Falta").idEvento;
                                }
                                else
                                {
                                    idEstadoAsistencia = estadoAsistenciaRepository.obtenerEstado("Tardanza").idEvento;
                                }

                                var registro = new RegistroDiario
                                {
                                    idEmpleado = empleado.idEmpleado,
                                    idFecha = fecha.idFecha,
                                    horaEntrada = horaActual,
                                    estadoAsistencia = idEstadoAsistencia
                                };

                                registroDiarioRepository.registrarRegistroDiario(registro);
                                lblNombre.Text = $"{empleado.nombreEmpleado} {empleado.apellidoEmpleado}";
                                lblTipoyHora.Text = $"{registroDiarioRepository.ObtenerEstadoAsistencia(empleado.idEmpleado, DateTime.Now)} - {FechaUtil.FormatearHora(DateTime.Now)}";
                            }
                            else
                            {
                                if (horaActual >= dosHorasAntesSalida)
                                {
                                    var registro = registroDiarioRepository.ObtenerRegistro(empleado.idEmpleado, fecha.idFecha);
                                    if (registro != null && registro.horaSalida != null)
                                    {
                                        MessageBox.Show("Ya existe una salida registrada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        gbDescanso.Enabled = false;
                                        return;
                                    }
                                    registroDiarioRepository.RegistrarSalida(empleado.idEmpleado, fecha.idFecha, horaActual);
                                    MessageBox.Show("Salida registrada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    gbDescanso.Enabled = false;
                                }
                                else
                                {
                                    gbDescanso.Enabled = true;
                                    MessageBox.Show("Puede registrar su descanso.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }

                        }));
                    }
                    else
                    {
                        Invoke(new Action(() =>
                        {
                            lblValidacion.Text = "Código inválido. Por favor, intente nuevamente.";
                            cleanTxtCodigo();
                            StopCamera();
                        }));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al procesar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    StopCamera();
                }
            });
        }

        private void btnInicioDescanso_Click(object sender, EventArgs e)
        {
            if (empleado == null)
            {
                MessageBox.Show("Debe validar primero el empleado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var fecha = fechaRepository.ObtenerOInsertarFecha(DateTime.Today);

            if (!registroDiarioRepository.ExisteEntrada(empleado.idEmpleado, fecha.idFecha))
            {
                MessageBox.Show("No existe una entrada registrada para este empleado en la fecha de hoy.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var registro = registroDiarioRepository.ObtenerRegistro(empleado.idEmpleado, fecha.idFecha);
            if (registro == null || registro.horaSalida != null)
            {
                MessageBox.Show("No se puede registrar el inicio de descanso porque ya existe una salida registrada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            registroDiarioRepository.RegistrarInicioDescanso(empleado.idEmpleado, fecha.idFecha, DateTime.Now.TimeOfDay);

            MessageBox.Show("Inicio de descanso registrado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DesactivarGroupBoxTipoAsistencia();
        }

        private void btnFinDescanso_Click(object sender, EventArgs e)
        {
            if (empleado == null)
            {
                MessageBox.Show("Debe validar primero el empleado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var fecha = fechaRepository.ObtenerOInsertarFecha(DateTime.Today);

            var registro = registroDiarioRepository.ObtenerRegistro(empleado.idEmpleado, fecha.idFecha);
            if (registro == null || registro.horaEntrada == null)
            {
                MessageBox.Show("No existe una entrada registrada para este empleado en la fecha de hoy.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (registro.inicioDescanso == null)
            {
                MessageBox.Show("No se ha registrado un inicio de descanso para este empleado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (registro.horaSalida != null)
            {
                MessageBox.Show("Ya existe una salida registrada para este empleado en la fecha de hoy.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            registroDiarioRepository.RegistrarFinDescanso(empleado.idEmpleado, fecha.idFecha, DateTime.Now.TimeOfDay);

            MessageBox.Show("Fin de descanso registrado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DesactivarGroupBoxTipoAsistencia();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            StopCamera();
            lblValidacion.Text = string.Empty;
            lblNombre.Text = string.Empty;
            lblTipoyHora.Text = string.Empty;
            cleanTxtCodigo();
            pbLogo.Visible = true;
            pbCamera.Visible = false;
            gbDescanso.Enabled = false;
        }

        private void cleanTxtCodigo() => txtCodigo.Clear();

        private void StopCamera()
        {
            try
            {
                if (pbCamera.InvokeRequired)
                {
                    pbCamera.Invoke((MethodInvoker)delegate { StopCameraInternal(); });
                }
                else
                {
                    StopCameraInternal();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al detener la cámara: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StopCameraInternal()
        {
            pbCamera.Visible = true;
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
                videoSource.NewFrame -= VideoSource_NewFrame;
            }
            pbCamera.Image?.Dispose();
            pbCamera.Image = null;

            pbLogo.Visible = true;
            lblValidacion.Text = string.Empty;
        }

        private void RunCamara()
        {
            try
            {
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (videoDevices.Count == 0)
                {
                    MessageBox.Show("No se encontró ninguna cámara.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                pbLogo.Visible = false;

                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                videoSource.NewFrame += VideoSource_NewFrame;
                videoSource.Start();

                pbCamera.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar la cámara: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StopCamera();
            }
        }

        private void VideoSource_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            try
            {
                Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();

                if (pbCamera.InvokeRequired)
                {
                    pbCamera.BeginInvoke((MethodInvoker)delegate
                    {
                        try
                        {
                            var oldImage = pbCamera.Image;
                            pbCamera.Image = (Bitmap)bitmap.Clone();
                            oldImage?.Dispose();
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine($"Error updating camera image: {ex.Message}");
                        }
                        finally
                        {
                            bitmap.Dispose();
                        }
                    });
                }
                else
                {
                    var oldImage = pbCamera.Image;
                    pbCamera.Image = (Bitmap)bitmap.Clone();
                    oldImage?.Dispose();
                    bitmap.Dispose();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in VideoSource_NewFrame: {ex.Message}");
            }
        }

        private void DesactivarGroupBoxTipoAsistencia()
        {
            empleado = null;
            lblValidacion.Text = string.Empty;
            cleanTxtCodigo();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Regex ValidarNumero = new Regex("^\\d+$");
                string texto = txtCodigo.Text;
                int selStart = txtCodigo.SelectionStart;
                if (!ValidarNumero.IsMatch(texto) || texto.Length > 8)
                {
                    if (texto.Length > 0)
                    {
                        txtCodigo.Text = texto.Remove(selStart - 1, 1);
                        txtCodigo.SelectionStart = selStart - 1;
                    }
                    else
                    {
                        txtCodigo.Text = "";
                        txtCodigo.SelectionStart = 0;
                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                ex = new Exception("Error al procesar el texto del código.", ex);
            }
        }
    }
}