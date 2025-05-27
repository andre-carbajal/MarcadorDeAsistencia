using System;
using System.Globalization;

namespace MarcadorDeAsistencia.Clases
{
    internal class FechaUtil
    {
        public static string FormatearFechaLarga(DateTime fecha)
        {
            CultureInfo cultura = new CultureInfo("es-ES");
            string fechaFormateada = fecha.ToString("dddd, dd 'de' MMMM 'de' yyyy", cultura);
            return char.ToUpper(fechaFormateada[0]) + fechaFormateada.Substring(1).ToLower();
        }

        public static string FormatearHora(DateTime hora)
        {
            return hora.ToString("HH:mm:ss");
        }
    }
}
