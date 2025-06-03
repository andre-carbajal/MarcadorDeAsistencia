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

        public bool ExisteEntrada(string idEmpleado, int idFecha)
        {
            return db.RegistroDiario.Any(r => r.idEmpleado.Equals(idEmpleado) && r.idFecha == idFecha && r.horaEntrada != null);
        }
    }
}
