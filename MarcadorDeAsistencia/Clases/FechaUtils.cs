using System;
using System.Globalization;

namespace MarcadorDeAsistencia.Clases
{
    internal class FechaUtils
    {
        public static string FormatearFechaLarga(DateTime fecha)
        {
            CultureInfo cultura = new CultureInfo("es-ES");
            return fecha.ToString("dddd, dd 'de' MMMM 'de' yyyy", cultura);
        }

        public static string FormatearHora(DateTime hora)
        {
            return hora.ToString("HH:mm:ss");
        }
    }
}
