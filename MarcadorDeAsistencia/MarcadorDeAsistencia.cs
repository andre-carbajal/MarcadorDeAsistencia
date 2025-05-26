using Emgu.CV;
using MarcadorDeAsistencia.Clases;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MarcadorDeAsistencia
{
    public partial class MarcadorDeAsistencia : Form
    {
        private bool isCapturing = false;
        private VideoCapture capture;

        public MarcadorDeAsistencia()
        {
            InitializeComponent();
            lblFecha.Text = FechaUtils.FormatearFechaLarga(DateTime.Now);

            timerHora.Interval = 1000;
            timerHora.Tick += TimerHora_Tick;
            timerHora.Start();

            lblHora.Text = FechaUtils.FormatearHora(DateTime.Now);

            gbTipoAsistencia.Enabled = false;
        }

        private void TimerHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = FechaUtils.FormatearHora(DateTime.Now);
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
                    lblValidacion.Text = "Validando código en la base de datos...";
                    // TODO: Aquí se debe realizar la validación del código ingresado en la base de datos. (API)
                    // if ( ' Validacion ' == txtCodigo.Text )
                    //     lblValidacion.Text = "Código válido. Por favor, espere...";
                    //     sleep(3000);
                    //     lblValidacion.Text = "Iniciando Cámara...";
                    //     RunCamara();
                    // TODO : Hacer la consulta a la API de la foto
                    //     if (VALIDACION DE CAMARA)
                    // else
                    //     lblValidacion.Text = "Código inválido. Por favor, intente nuevamente.";
                    //     txtCodigo.Clear();
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