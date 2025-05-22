using MarcadorDeAsistencia.Clases;
using System;
using System.Windows.Forms;

namespace MarcadorDeAsistencia
{
    public partial class MarcadorDeAsistencia : Form
    {
        public MarcadorDeAsistencia()
        {
            InitializeComponent();
            lblFecha.Text = FechaUtils.FormatearFechaLarga(DateTime.Now);

            timerHora.Interval = 1000;
            timerHora.Tick += TimerHora_Tick;
            timerHora.Start();

            lblHora.Text = FechaUtils.FormatearHora(DateTime.Now);
        }

        private void TimerHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = FechaUtils.FormatearHora(DateTime.Now);
        }
    }
}