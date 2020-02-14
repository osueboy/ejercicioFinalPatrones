using Final.Services.Implementaciones.Ranges;
using Final.Services.Interfaces;
using Final.Services.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Final.Services.Implementaciones
{
    public class RangoDeTiempoProvider : IRangoDeTiempoProvider
    {
        private List<IRangeValidator> _rangeValidators = new List<IRangeValidator>();
        public RangoDeTiempoProvider()
        {
            //Crear Cadena
            _rangeValidators.Add(new MinutesRangeValidator());
            _rangeValidators.Add(new HoursRangeValidator());
            _rangeValidators.Add(new DaysRangeValidator());
            _rangeValidators.Add(new MonthsRangeValidator());


            for(int i = 0; i < _rangeValidators.Count - 1; i++)
            {
                _rangeValidators.ElementAt(i).Next = _rangeValidators.ElementAt(i + 1);
            }

        }
        public RangoResponse GetValorPorRango(TimeSpan timeSpan)
        {
            return _rangeValidators.ElementAt(0).Validate(timeSpan);
        }
    }
}
