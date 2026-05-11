namespace Application.Common.Helpers
{
    internal static class DateHelper
    {
        public static string TiempoTranscurrido(DateTime fechaInicio, DateTime fechaFin)
        {
            if (fechaFin < fechaInicio) return string.Empty;

            int anios = fechaFin.Year - fechaInicio.Year;
            int meses = fechaFin.Month - fechaInicio.Month;
            int dias = fechaFin.Day - fechaInicio.Day;

            if (dias < 0)
            {
                meses--;
                DateTime mesAnterior = fechaFin.AddMonths(-1);
                dias += DateTime.DaysInMonth(mesAnterior.Year, mesAnterior.Month);
            }

            if (meses < 0)
            {
                anios--;
                meses += 12;
            }

            var componentes = new List<string>();
            if (anios > 0) componentes.Add($"{anios} año{(anios != 1 ? "s" : "")}");
            if (meses > 0) componentes.Add($"{meses} mes{(meses != 1 ? "es" : "")}");
            if (dias > 0) componentes.Add($"{dias} día{(dias != 1 ? "s" : "")}");

            return componentes.Count > 0 ? string.Join(", ", componentes) : "0 días";
        }
    }
}
