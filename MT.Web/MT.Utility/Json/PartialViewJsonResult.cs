using System.Web.Mvc;

namespace MT.Utility.Json
{
    public class PartialViewJsonResult : PartialViewResult
    {
        public ControllerContext ControllerContext { get; set; }

        public PartialViewJsonResult(ControllerContext controllerContext, string viewName, object model)
        {
            ControllerContext = controllerContext;
            ViewName = viewName;
            ViewData.Model = model;
        }
    }
}
