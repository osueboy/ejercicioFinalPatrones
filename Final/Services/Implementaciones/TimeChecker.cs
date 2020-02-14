using Final.Services.Interfaces;
using Final.Services.Messages;
using System;

namespace Final.Services.Implementaciones
{
    public class TimeChecker : ITimeChecker
    {
        private readonly IClockReader _clockReader;
        public TimeChecker(IClockReader clockReader)
        {
            _clockReader = clockReader;
        }
        public TimeCheckerResponse CheckTime(DateTime dateToVerify)
        {
            DateTime currentTime = _clockReader.GetCurrentTime();
            bool past = false;
            if (dateToVerify < currentTime)
            {
                past = true;
            }

            TimeSpan timespan;
            if (past)
            {
                timespan = currentTime - dateToVerify;
            }
            else
            {
                timespan = dateToVerify - currentTime;
            }

            return new TimeCheckerResponse()
            {
                Past = past,
                TimePast = timespan
            };
        }
    }
}
