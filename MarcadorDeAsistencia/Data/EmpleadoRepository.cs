using System;
using System.Linq;
using System.Windows.Forms;

namespace MarcadorDeAsistencia.Data
{
    public class EmpleadoRepository
    {
        DataClassesTablasDataContext db = new DataClassesTablasDataContext();

        public Empleado ObtenerEmpleado(string idEmpleado)
        {
            try
            {
                return db.Empleado.FirstOrDefault(e => e.idEmpleado.Equals(idEmpleado));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
