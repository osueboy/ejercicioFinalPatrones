using Final.Services.Interfaces;
using Final.Services.Messages;
using System;

namespace Final.Services.Implementaciones.Ranges
{
    public class HoursRangeValidator : IRangeValidator
    {
        public IRangeValidator Next { get; set; }

        public string Range => TiposRangos.Horas;

        public RangoResponse Validate(TimeSpan timeSpan)
        {
            if (timeSpan.TotalHours > 23)
            {
                if (Next != null)
                {
                    return Next.Validate(timeSpan);
                }
            }
            return new RangoResponse()
            {
                Rango = Range,
                Valor = (int)timeSpan.TotalHours
            };
        }
    }
}
