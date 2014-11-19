using System.Collections.Generic;
using System.Web.Mvc;

namespace MT.Web.Infrastructure
{
    public class EducationLevel
    {
        private static List<SelectListItem> _educationLeveList;
        public static List<SelectListItem> EducationLeveList
        {
            get { return _educationLeveList; }
        }

        static EducationLevel()
        {
            _educationLeveList = new List<SelectListItem>()
            {
                new SelectListItem() {Text = "Higher education", Value = "Higher education"},
                new SelectListItem() {Text = "Incomplete higher education", Value = "Incomplete higher education"},
                new SelectListItem() {Text = "Technical college", Value = "Technical college"},
                new SelectListItem() {Text = "Secondary education", Value = "Secondary education"}
                
            };
        }

    }
}