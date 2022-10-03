using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace test.Utilities
{
    public static class DateUtility
    {
        public static DateTime JalaliToMiladi(string tarikh)
        {
            var Jalali = tarikh.Split('/');
            var pc = new PersianCalendar();
            var date = new DateTime(Convert.ToInt32(Jalali[0]), Convert.ToInt32(Jalali[1]), Convert.ToInt32(Jalali[2]), pc);
            return date;
        }
    }
}
