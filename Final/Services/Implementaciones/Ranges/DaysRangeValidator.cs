using Final.Services.Interfaces;
using Final.Services.Messages;
using System;

namespace Final.Services.Implementaciones.Ranges
{
    public class DaysRangeValidator : IRangeValidator
    {
        public IRangeValidator Next { get; set; }

        public string Range => TiposRangos.Dias;

        public RangoResponse Validate(TimeSpan timeSpan)
        {
            if (timeSpan.TotalDays > 29)
            {
                if (Next != null)
                {
                    return Next.Validate(timeSpan);
                }
            }
            return new RangoResponse()
            {
                Rango = Range,
                Valor = (int)timeSpan.TotalDays
            };
        }
    }
}
