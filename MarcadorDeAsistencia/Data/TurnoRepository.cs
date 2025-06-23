using System.Linq;

namespace MarcadorDeAsistencia.Data
{
    internal class TurnoRepository
    {
        public Turno ObtenerTurno(int idTurno)
        {
            using (var db = new DataClassesTablasDataContext())
            {
                return db.Turno.FirstOrDefault(t => t.idTurno.Equals(idTurno));
            }
        }
    }
}
