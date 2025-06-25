using System;
using System.Linq;

namespace MarcadorDeAsistencia.Data
{
    public class FechaRepository
    {
        public Fecha ObtenerOInsertarFecha(DateTime fecha)
        {
            using (var db = new DataClassesTablasDataContext())
            {
                int dia = fecha.Day;
                int mes = fecha.Month;
                int anio = fecha.Year;

                var fechaDb = db.Fecha.FirstOrDefault(f => f.dia.Equals(dia) && f.mes.Equals(mes) && f.ano.Equals(anio));
                if (fechaDb == null)
                {
                    fechaDb = new Fecha { dia = dia.ToString(), mes = mes.ToString(), ano = anio.ToString() };
                    db.Fecha.InsertOnSubmit(fechaDb);
                    db.SubmitChanges();
                }
                return fechaDb;
            }
        }
    }
}
