using Final.Services.Messages;
using System;

namespace Final.Services.Interfaces
{
    public interface IRangeValidator
    {
        IRangeValidator Next { get; set; }
        string Range { get; }
        RangoResponse Validate(TimeSpan timeSpan);
    }
}
