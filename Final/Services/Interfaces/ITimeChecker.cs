using Final.Services.Messages;
using System;

namespace Final.Services.Interfaces
{
    public interface ITimeChecker
    {
        TimeCheckerResponse CheckTime(DateTime dateToVerify);
    }
}
