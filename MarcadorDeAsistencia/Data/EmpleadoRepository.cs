using System.Linq;

namespace MarcadorDeAsistencia.Data
{
    public class EmpleadoRepository
    {
        public Empleado ObtenerEmpleado(string idEmpleado)
        {
            using (var db = new DataClassesTablasDataContext())
            {
                return db.Empleado.Single(e => e.idEmpleado.Equals(idEmpleado));
            }
        }
    }
}
