using System.Collections.Generic;
using System.Web.Mvc;

namespace MT.Web.Infrastructure
{
    public  class UTC
    {
        private static List<SelectListItem> _UTCZones;

        public static List<SelectListItem> UTCZones { get { return _UTCZones;  } }


        static UTC()
        {
            _UTCZones = new List<SelectListItem>
            {
                new SelectListItem() {Text = "UTC: -12", Value = "-12"},
                new SelectListItem() {Text = "UTC: -10", Value = "-10"},
                new SelectListItem() {Text = "UTC: -8", Value = "-8"},
                new SelectListItem() {Text = "UTC: -6", Value = "-6"},
                new SelectListItem() {Text = "UTC: -4", Value = "-4"},
                new SelectListItem() {Text = "UTC: -2", Value = "-2"},
                new SelectListItem() {Text = "UTC: 0", Value = "0",  Selected = true},
                new SelectListItem() {Text = "UTC: 2", Value = "+2"},
                new SelectListItem() {Text = "UTC: 4", Value = "+4"},
                new SelectListItem() {Text = "UTC: 6", Value = "+6"},
                new SelectListItem() {Text = "UTC: 8", Value = "+8"},
                new SelectListItem() {Text = "UTC: 10", Value = "+10"},
                new SelectListItem() {Text = "UTC: 12", Value = "+12"}

            };
        }


    }
}