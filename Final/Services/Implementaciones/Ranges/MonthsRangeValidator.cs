using Final.Services.Interfaces;
using Final.Services.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final.Services.Implementaciones.Ranges
{
    public class MonthsRangeValidator : IRangeValidator
    {
        public IRangeValidator Next { get; set; }

        public string Range => TiposRangos.Meses;

        public RangoResponse Validate(TimeSpan timeSpan)
        {
            return new RangoResponse()
            {
                Rango = Range,
                Valor = (int)(timeSpan.TotalDays / 30)
            };
        }
    }
}
