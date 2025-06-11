using System.Linq;

namespace MarcadorDeAsistencia.Data
{
    internal class TurnoRepository
    {
        DataClassesTablasDataContext db = new DataClassesTablasDataContext();

        public Turno ObtenerTurno(int idTurno)
        {
            return db.Turno.FirstOrDefault(t => t.idTurno.Equals(idTurno));
        }
    }
}
