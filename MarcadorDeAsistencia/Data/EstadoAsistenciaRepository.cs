using System.Linq;

namespace MarcadorDeAsistencia.Data
{
    internal class EstadoAsistenciaRepository
    {
        public EstadoAsistencia obtenerEstado(string estado)
        {
            using (var db = new DataClassesTablasDataContext())
            {
                return db.EstadoAsistencia.FirstOrDefault(e => e.nombreEvento.Equals(estado));
            }
        }
    }
}
