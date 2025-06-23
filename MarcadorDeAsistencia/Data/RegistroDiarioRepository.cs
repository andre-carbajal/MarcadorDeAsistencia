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

        public void RegistrarSalida(string idEmpleado, int idFecha, TimeSpan horaSalida)
        {
            try
            {
                var registro = db.RegistroDiario.FirstOrDefault(r => r.idEmpleado == idEmpleado && r.idFecha == idFecha && r.horaEntrada != null);
                if (registro != null)
                {
                    registro.horaSalida = horaSalida;
                    db.SubmitChanges();
                }
                else
                {
                    MessageBox.Show("No existe una entrada registrada para este empleado en la fecha de hoy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar la salida: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RegistrarInicioDescanso(string idEmpleado, int idFecha, TimeSpan horaInicioDescanso)
        {
            try
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
                else
                {
                    MessageBox.Show("No se puede registrar el inicio de descanso. Verifique que exista una entrada y no haya salida registrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el inicio de descanso: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RegistrarFinDescanso(string idEmpleado, int idFecha, TimeSpan horaFinDescanso)
        {
            try
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
                else
                {
                    MessageBox.Show("No se puede registrar el fin de descanso. Verifique que exista una entrada, un inicio de descanso y que no haya salida registrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el fin de descanso: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool ExisteEntrada(string idEmpleado, int idFecha)
        {
            return db.RegistroDiario.Any(r => r.idEmpleado.Equals(idEmpleado) && r.idFecha == idFecha && r.horaEntrada != null);
        }

        public RegistroDiario ObtenerRegistro(string idEmpleado, int idFecha)
        {
            return db.RegistroDiario.FirstOrDefault(r => r.idEmpleado == idEmpleado && r.idFecha == idFecha && r.horaEntrada != null);
        }

        public string ObtenerEstadoAsistencia(string idEmpleado, DateTime now)
        {
            var registro = (from r in db.RegistroDiario
                            join f in db.Fecha on r.idFecha equals f.idFecha
                            where r.idEmpleado == idEmpleado
                                  && f.dia.Equals(now.Day)
                                  && f.mes.Equals(now.Month)
                                  && f.Equals(now.Year)
                            select r).FirstOrDefault();

            if (registro == null)
                return "No registrado";
            if (registro.horaSalida != null)
                return "Salida";
            if (registro.horaEntrada != null)
                return "Entrada";
            return "No registrado";
        }
    }
}
