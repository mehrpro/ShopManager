using System;

namespace SPS.Services
{
    public static class ExtentionMethod
    {
        public static string PersianConvertor(this DateTime dateTime)
        {
            var ps = new System.Globalization.PersianCalendar();
            var ps_year = ps.GetYear(dateTime);
            var ps_month = ps.GetMonth(dateTime);
            var ps_day = ps.GetDayOfMonth(dateTime);
            return $"{ps_year}/{ps_month}/{ps_day}";
        }
        public static string PersianConvertorFull(this DateTime dateTime)
        {
            var ps = new System.Globalization.PersianCalendar();
            var ps_year = ps.GetYear(dateTime);
            var ps_month = ps.GetMonth(dateTime);
            var ps_day = ps.GetDayOfMonth(dateTime);
            return $"{ps_year}/{ps_month}/{ps_day} {dateTime.Hour}:{dateTime.Minute}";
        }
    }
}