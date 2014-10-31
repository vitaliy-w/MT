using System.Collections.Generic;
using System.Web.Mvc;
using MT.ModelEntities.Entities;

namespace MT.Web.Infrastructure
{
    public static class UTC
    {
        public static List<SelectListItem> UTCZones;

        static UTC()
        {
            UTCZones = new List<SelectListItem>
            {
                new SelectListItem() {Text = "UTC: -12", Value = "-12"},
                new SelectListItem() {Text = "UTC: -10", Value = "-10"},
                new SelectListItem() {Text = "UTC: -8", Value = "-8"},
                new SelectListItem() {Text = "UTC: -6", Value = "-6"},
                new SelectListItem() {Text = "UTC: -4", Value = "-4"},
                new SelectListItem() {Text = "UTC: -2", Value = "-2"},
                new SelectListItem() {Text = "UTC: +0", Value = "+0"},
                new SelectListItem() {Text = "UTC: +2", Value = "+2"},
                new SelectListItem() {Text = "UTC: +4", Value = "+4"},
                new SelectListItem() {Text = "UTC: +6", Value = "+6"},
                new SelectListItem() {Text = "UTC: +8", Value = "+8"},
                new SelectListItem() {Text = "UTC: +10", Value = "+10"},
                new SelectListItem() {Text = "UTC: +12", Value = "+12"}

            };
        }


    }
}