using System.Collections.Generic;
using System.Linq;

namespace MarcadorDeAsistencia.Data
{
    internal class EstadoAsistenciaRepository
    {
        public List<EstadoAsistencia> ObtenerEstadosAsistencia()
        {
            using (var db = new DataClassesTablasDataContext())
            {
                return db.EstadoAsistencia.ToList();
            }
        }
    }
}
