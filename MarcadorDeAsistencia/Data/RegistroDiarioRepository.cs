using System;
using System.Linq;

namespace MarcadorDeAsistencia.Data
{
    public class RegistroDiarioRepository
    {
        public void registrarRegistroDiario(RegistroDiario registro)
        {
            using (var db = new DataClassesTablasDataContext())
            {
                db.RegistroDiario.InsertOnSubmit(registro);
                db.SubmitChanges();
            }
        }

        public void RegistrarSalida(string idEmpleado, int idFecha, TimeSpan horaSalida)
        {
            using (var db = new DataClassesTablasDataContext())
            {
                var registro = db.RegistroDiario.FirstOrDefault(r => r.idEmpleado == idEmpleado && r.idFecha == idFecha && r.horaEntrada != null);
                if (registro != null)
                {
                    registro.horaSalida = horaSalida;
                    db.SubmitChanges();
                }
            }
        }

        public void RegistrarInicioDescanso(string idEmpleado, int idFecha, TimeSpan horaInicioDescanso)
        {
            using (var db = new DataClassesTablasDataContext())
            {
                var registro = db.RegistroDiario.FirstOrDefault(r =>
                    r.idEmpleado == idEmpleado &&
                    r.idFecha == idFecha &&
                    r.horaEntrada != null &&
                    r.horaSalida == null);

                if (registro != null)
                {
                    registro.horaEntrada = horaInicioDescanso;
                    db.SubmitChanges();
                }
            }
        }

        public void RegistrarFinDescanso(string idEmpleado, int idFecha, TimeSpan horaFinDescanso)
        {
            using (var db = new DataClassesTablasDataContext())
            {
                var registro = db.RegistroDiario.FirstOrDefault(r =>
                    r.idEmpleado == idEmpleado &&
                    r.idFecha == idFecha &&
                    r.horaEntrada != null &&
                    r.inicioDescanso != null &&
                    r.horaSalida == null);

                if (registro != null)
                {
                    registro.finDescanso = horaFinDescanso;
                    db.SubmitChanges();
                }
            }
        }

        public bool ExisteEntrada(string idEmpleado, int idFecha)
        {
            using (var db = new DataClassesTablasDataContext())
            {
                return db.RegistroDiario.Any(r => r.idEmpleado.Equals(idEmpleado) && r.idFecha == idFecha && r.horaEntrada != null);
            }
        }

        public RegistroDiario ObtenerRegistro(string idEmpleado, int idFecha)
        {
            using (var db = new DataClassesTablasDataContext())
            {
                return db.RegistroDiario.FirstOrDefault(r => r.idEmpleado == idEmpleado && r.idFecha == idFecha && r.horaEntrada != null);
            }
        }

        public string ObtenerEstadoAsistencia(string idEmpleado, DateTime now)
        {
            using (var db = new DataClassesTablasDataContext())
            {
                var nombreEstadoAsistencia = (from r in db.RegistroDiario
                                              join estado in db.EstadoAsistencia
                                              on r.idEstadoAsistencia equals estado.idEvento
                                              where r.idEmpleado == idEmpleado
                                              && r.Fecha.dia.Equals(now.Day) && r.Fecha.mes.Equals(now.Month) && r.Fecha.ano.Equals(now.Year)
                                              select estado.nombreEvento).FirstOrDefault();

                if (nombreEstadoAsistencia == null) return "No registrado";
                return nombreEstadoAsistencia;
            }

        }
    }
}
