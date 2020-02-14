using System;

namespace Final.Services.Messages
{
    public class TimeCheckerResponse
    {
        public bool Past { get; set; }
        public TimeSpan TimePast { get; set; }
    }
}
