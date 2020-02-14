using Final.Services.Interfaces;
using System;

namespace Final.Services.Implementaciones
{
    public class Clock : IClockReader
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}
