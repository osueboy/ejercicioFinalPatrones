using System;
using System.Globalization;

namespace Final
{
    public static class DateParser
    {
        public const string isoDateFormat = "dd-MM-yyyy HH:mm:ss";
        public static DateTime ParseDate(string date)
        {
            DateTime.TryParseExact(date, isoDateFormat, null, DateTimeStyles.None, out DateTime datetime);
            return datetime;

        }
    }
}
