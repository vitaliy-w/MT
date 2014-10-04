using System.Web.Mvc;
using MT.Utility.Localization.Services;

namespace MT.Web.Controllers
{
    public class ControlsController : Controller
    {
        //
        // GET: /Controls/
        public ActionResult Alert()
        {
            return View();
        }

        public ActionResult ResetCache()
        {
            LocalizationResourceServiceSingleton.Reset();
            return Content("~");
        }
    }
}