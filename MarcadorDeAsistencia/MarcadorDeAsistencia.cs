using Emgu.CV;
using MarcadorDeAsistencia.Clases;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarcadorDeAsistencia
{
    public partial class MarcadorDeAsistencia : Form
    {
        private bool isCapturing = false;
        private VideoCapture capture;

        private FaceDetectionService fds = new FaceDetectionService();

        public MarcadorDeAsistencia()
        {
            InitializeComponent();
            lblFecha.Text = FechaUtil.FormatearFechaLarga(DateTime.Now);

            timerHora.Interval = 1000;
            timerHora.Tick += TimerHora_Tick;
            timerHora.Start();

            lblHora.Text = FechaUtil.FormatearHora(DateTime.Now);

            lblValidacion.Text = string.Empty;

            gbTipoAsistencia.Enabled = false;
        }

        private void TimerHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = FechaUtil.FormatearHora(DateTime.Now);
        }

        private void RunCamara()
        {
            try
            {
                if (isCapturing) return;

                capture = new VideoCapture(0); // Camara por defecto (0)

                if (!capture.IsOpened)
                {
                    MessageBox.Show("No se pudo abrir la cámara.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                isCapturing = true;

                Application.Idle += ProcessFrame;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error iniciando la cámara: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MarcadorDeAsistencia_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopCamera();
        }

        private void StopCamera()
        {
            if (isCapturing)
            {
                Application.Idle -= ProcessFrame;
                isCapturing = false;
                capture?.Dispose();
                capture = null;
            }
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            if (capture != null && isCapturing)
            {
                try
                {
                    using (Mat frame = new Mat())
                    {
                        capture.Read(frame);

                        if (!frame.IsEmpty) pbCamera.Image = frame.ToBitmap();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing frame: {ex.Message}");
                }
            }
        }

        private void cleanTxtCodigo()
        {
            txtCodigo.Clear();
            txtCodigo.Focus();
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("Por favor, ingrese un código.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (txtCodigo.Text.Length == 8 && txtCodigo.Text.All(char.IsDigit))
                {
                    lblValidacion.Text = "Validando código con reconocimiento facial...";
                    RunCamara();
                    using (Mat frame = new Mat()) 
                    { 
                        capture.Read(frame);

                        if (!frame.IsEmpty)
                        {
                            var bitmap = frame.ToBitmap();
                            fds.SetFrame(bitmap);
                            fds.SetIdEmpleado(txtCodigo.Text);

                            Task.Run( async () =>
                            {
                                var result = await fds.DetectPerson();
                                
                                if (result != null && result.result)
                                {
                                    Invoke(new Action(() =>
                                    {
                                        lblValidacion.Text = "Código válido. Por favor, espere...";
                                        gbTipoAsistencia.Enabled = true;
                                        cleanTxtCodigo();
                                        StopCamera();
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
                            });
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El código debe tener exactamente 8 numeros.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCodigo.Clear();
                }
            }
        }
    }
}