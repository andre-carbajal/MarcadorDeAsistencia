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
                int año = fecha.Year;

                var fechaDb = db.Fecha.FirstOrDefault(f => f.dia.Equals(dia) && f.mes.Equals(mes) && f.ano.Equals(año));
                if (fechaDb == null)
                {
                    fechaDb = new Fecha { dia = dia.ToString(), mes = mes.ToString(), ano = año.ToString() };
                    db.Fecha.InsertOnSubmit(fechaDb);
                    db.SubmitChanges();
                }
                return fechaDb;
            }
        }
    }
}
