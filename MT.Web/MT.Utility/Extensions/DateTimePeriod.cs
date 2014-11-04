using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.Utility.Extensions
{
    /// <summary>
    /// Date time wrapper for period. 
    /// </summary>
    public class DateTimePeriod
    {
        public DateTimePeriod(DateTime? startPeriod, DateTime? endPeriod)
            : this()
        {
            StartPeriod = startPeriod;
            EndPeriod = endPeriod;
        }

        public DateTimePeriod()
        {
            StartPeriod = null;
            EndPeriod = null;
        }

        public DateTime? StartPeriod { get; set; }
        public DateTime? EndPeriod { get; set; }

    }
}
