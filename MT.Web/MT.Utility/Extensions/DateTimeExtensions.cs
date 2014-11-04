using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Utility.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Return period by type period.
        /// Exception, param LastYear! This method always returns:
        ///  the start date equals today minus 1 year and
        ///  the end date equals now datetime
        /// </summary>
        /// <param name="datetime"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        public static DateTimePeriod DateOfPeriod(this DateTime datetime, DateTimePeriodType period)
        {
            var firstDayOfFirstQuarter = new DateTime(datetime.Year, 1, 1);

            switch (period)
            {
                case DateTimePeriodType.NoValue:
                    return new DateTimePeriod(null, null);
                case DateTimePeriodType.Today:
                    return new DateTimePeriod(DateTime.Today, DateTime.Today.AddDays(1).AddMilliseconds(-1));
                case DateTimePeriodType.Yesterday:
                    return new DateTimePeriod(DateTime.Today.AddDays(-1), DateTime.Today.AddMilliseconds(-1));
                case DateTimePeriodType.CurrentQuarter:
                    return new DateTimePeriod(datetime.StartDayOfQuarter(), datetime.EndDayOfQuarter());
                case DateTimePeriodType.PreviousQuarter:
                    return new DateTimePeriod(datetime.StartDayOfPreviousQuarter(), datetime.EndDayOfPreviousQuarter());
                case DateTimePeriodType.CurrentWeekMonday:
                    return new DateTimePeriod(datetime.StartOfWeek(DayOfWeek.Monday), datetime.EndOfWeek(DayOfWeek.Monday));
                case DateTimePeriodType.WeekPreviousMonday:
                    return new DateTimePeriod(datetime.StartOfPreviousWeek(DayOfWeek.Monday), datetime.EndOfPreviousWeek(DayOfWeek.Monday));
                case DateTimePeriodType.CurrentMonth:
                    return new DateTimePeriod(datetime.StartOfMonth(), datetime.EndOfMonth());
                case DateTimePeriodType.PreviousMonth:
                    return new DateTimePeriod(datetime.StartOfPreviousMonth(), datetime.EndOfPreviousMonth());
                case DateTimePeriodType.CurrentYear:
                    return new DateTimePeriod(datetime.StartOfYear(), datetime.EndOfYear());
                case DateTimePeriodType.PreviousYear:
                    return new DateTimePeriod(datetime.StartOfPreviousYear(), datetime.EndOfPreviousYear());
                case DateTimePeriodType.LastYear:
                    return new DateTimePeriod(DateTime.Today.AddYears(-1), DateTime.Now);
                case DateTimePeriodType.Quarter1:
                    return firstDayOfFirstQuarter.DateOfPeriod(DateTimePeriodType.CurrentQuarter);
                case DateTimePeriodType.Quarter2:
                    return firstDayOfFirstQuarter.AddMonths(3).DateOfPeriod(DateTimePeriodType.CurrentQuarter);
                case DateTimePeriodType.Quarter3:
                    return firstDayOfFirstQuarter.AddMonths(6).DateOfPeriod(DateTimePeriodType.CurrentQuarter);
                case DateTimePeriodType.Quarter4:
                    return firstDayOfFirstQuarter.AddMonths(9).DateOfPeriod(DateTimePeriodType.CurrentQuarter);

                default:
                    throw new ArgumentOutOfRangeException("Time period is not supported");
            }
        }

        #region Month

        private static DateTime StartOfPreviousMonth(this DateTime dateTime)
        {
            return StartOfMonth(dateTime.AddMonths(-1));
        }

        private static DateTime EndOfPreviousMonth(this DateTime dateTime)
        {
            return EndOfMonth(dateTime.AddMonths(-1));
        }

        private static DateTime StartOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1, 0, 0, 0, 0);
        }

        private static DateTime EndOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1).AddMonths(1).AddMilliseconds(-1);
        }

        #endregion

        #region Weeks

        private static DateTime StartOfPreviousWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            dt = dt.AddDays(-7);
            return dt.StartOfWeek(startOfWeek);
        }

        private static DateTime EndOfPreviousWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            dt = dt.AddDays(-7);
            return dt.EndOfWeek(startOfWeek);
        }

        private static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }

            return dt.AddDays(-1 * diff).Date;
        }

        private static DateTime EndOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }

            return dt.AddDays(-1 * diff).AddDays(7).AddMilliseconds(-1);
        }

        #endregion

        #region Years
        private static DateTime StartOfYear(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, 1, 1, 0, 0, 0, 0);
        }

        private static DateTime EndOfYear(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, 12, DateTime.DaysInMonth(dateTime.Year, 12), 23, 59, 59, 999);
        }

        private static DateTime StartOfPreviousYear(this DateTime dateTime)
        {
            return StartOfYear(dateTime.AddYears(-1));
        }

        private static DateTime EndOfPreviousYear(this DateTime dateTime)
        {
            return EndOfYear(dateTime.AddYears(-1));
        }

        #endregion

        #region Quarter

        private static DateTime StartDayOfQuarter(this DateTime dateTime)
        {
            int quarterNumber = (dateTime.Month - 1) / 3 + 1;
            var firstDayOfQuarter = new DateTime(dateTime.Year, (quarterNumber - 1) * 3 + 1, 1);
            return firstDayOfQuarter;
        }

        private static DateTime EndDayOfQuarter(this DateTime dateTime)
        {
            var lastDayOfQuarter = dateTime.StartDayOfQuarter().AddMonths(3).AddMilliseconds(-1);
            return lastDayOfQuarter;
        }

        private static DateTime StartDayOfPreviousQuarter(this DateTime dateTime)
        {
            var firstDayOfPreviousQuarter = dateTime.StartDayOfQuarter().AddMonths(-3);
            return firstDayOfPreviousQuarter;
        }

        private static DateTime EndDayOfPreviousQuarter(this DateTime dateTime)
        {
            var lastDayOfPreviousQuarter = dateTime.StartDayOfQuarter().AddMilliseconds(-1);
            return lastDayOfPreviousQuarter;
        }

        #endregion


        public enum Month
        {
            First = 1,
            January = 1,
            February = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6,
            July = 7,
            August = 8,
            September = 9,
            October = 10,
            November = 11,
            December = 12,
            Last = 12
        }
    }
}