using Final.Services.Interfaces;
using Final.Services.Messages;
using System;

namespace Final.Services.Implementaciones.Ranges
{
    public class MinutesRangeValidator : IRangeValidator
    {
        public IRangeValidator Next { get; set; }
        public string Range => TiposRangos.Minutos;

        public RangoResponse Validate(TimeSpan timeSpan)
        {
            if (timeSpan.TotalMinutes > 59)
            {
                if (Next != null)
                {
                    return Next.Validate(timeSpan);
                }
            }
            return new RangoResponse()
            {
                Rango = Range,
                Valor = (int)timeSpan.TotalMinutes
            };
        }
    }
}
