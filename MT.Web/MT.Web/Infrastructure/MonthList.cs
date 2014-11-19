using System.Collections.Generic;
using System.Web.Mvc;

namespace MT.Web.Infrastructure
{
    public class MonthList
    {
        private static List<SelectListItem> _monthList;
        public static List<SelectListItem> Months
        {
            get { return _monthList; }
        }

        static MonthList()
        {
            _monthList = new List<SelectListItem>()
            {
                new SelectListItem() {Text = "January", Value = "January"},
                new SelectListItem() {Text = "February", Value = "February"},
                new SelectListItem() {Text = "March", Value = "March"},
                new SelectListItem() {Text = "April", Value = "April"},
                new SelectListItem() {Text = "May", Value = "May"},
                new SelectListItem() {Text = "June", Value = "June"},
                new SelectListItem() {Text = "Jule", Value = "Jule"},
                new SelectListItem() {Text = "August", Value = "August"},
                new SelectListItem() {Text = "September", Value = "September"},
                new SelectListItem() {Text = "October", Value = "October"},
                new SelectListItem() {Text = "November", Value = "November"},
                new SelectListItem() {Text = "December", Value = "December"},



            };
        }

    }
}