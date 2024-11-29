using System.Globalization;
using WebApplicationDemo.Model;

namespace WebApplicationDemo.Helpers
{
    public static class PersianDateTools
    {
        public static string ToPersianDateString(this PersonBirthDate dateObj)
        {
            DateTime date = new DateTime(dateObj.Year, dateObj.Month, dateObj.Day);
            var persianCalendar = new PersianCalendar();
            var persianYear = persianCalendar.GetYear(date);
            var persianMonth = persianCalendar.GetMonth(date);
            var persianDay = persianCalendar.GetDayOfMonth(date);
            return $"{persianYear}/{persianMonth.ToString("00")}/{persianDay.ToString("00")}";
        }

        public static PersonBirthDate ToPersonBirthDate(this PersonBirthDate persianDateObj)
        {
            var persianCalendar = new PersianCalendar();
            var date = persianCalendar.ToDateTime(persianDateObj.Year, persianDateObj.Month, persianDateObj.Day,0,0,0,0);
            return new PersonBirthDate { Year = date.Year, Month = date.Month, Day = date.Day };
        }
    }
}
