using System.Linq;

namespace MarcadorDeAsistencia.Data
{
    internal class EstadoAsistenciaRepository
    {
        DataClassesTablasDataContext db = new DataClassesTablasDataContext();

        public EstadoAsistencia obtenerEstado(string estado)
        {
            return db.EstadoAsistencia.FirstOrDefault(e => e.nombreEvento.Equals(estado));
        }
    }
}
