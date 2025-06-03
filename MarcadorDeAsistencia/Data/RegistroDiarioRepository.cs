using System;
using System.Linq;
using System.Windows.Forms;

namespace MarcadorDeAsistencia.Data
{
    public class RegistroDiarioRepository
    {
        DataClassesTablasDataContext db = new DataClassesTablasDataContext();

        public void registrarRegistroDiario(RegistroDiario registro)
        {
            try
            {
                db.RegistroDiario.InsertOnSubmit(registro);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar asistencia: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RegistrarSalida(string idEmpleado, int idFecha, TimeSpan horaSalida)
        {
            try
            {
                var registro = db.RegistroDiario.FirstOrDefault(r => r.idEmpleado == idEmpleado && r.idFecha == idFecha && r.horaEntrada != null);
                if (registro != null)
                {
                    registro.horaSalida = horaSalida;
                    db.SubmitChanges();
                }
                else
                {
                    MessageBox.Show("No existe una entrada registrada para este empleado en la fecha de hoy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar la salida: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool ExisteEntrada(string idEmpleado, int idFecha)
        {
            return db.RegistroDiario.Any(r => r.idEmpleado.Equals(idEmpleado) && r.idFecha == idFecha && r.horaEntrada != null);
        }
    }
}
