using System.Collections.Generic;
using System.Linq;

namespace MarcadorDeAsistencia.Data
{
    internal class TurnoRepository
    {
        public List<Turno> ObtenerTurnos()
        {
            using (var db = new DataClassesTablasDataContext())
            {
                return db.Turno.ToList();
            }
        }

        public Turno ObtenerTurno(int idTurno)
        {
            using (var db = new DataClassesTablasDataContext())
            {
                return db.Turno.FirstOrDefault(t => t.idTurno.Equals(idTurno));
            }
        }
    }
}
