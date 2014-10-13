using System.Linq;
using System.Net;
using System.Web.Mvc;
using MT.DomainLogic;
using MT.Utility.Json;
using MT.Utility.Localization.Services;

namespace MT.Web.Controllers
{
    public class ControlsController : Controller
    {
        private ITechnologyService _technologyService;
        public ControlsController(ITechnologyService technologyService)
        {
            _technologyService = technologyService;
        }

        public ActionResult Alert()
        {
            return View();
        }

        public ActionResult ResetCache()
        {
            LocalizationResourceServiceSingleton.Reset();
            return Content("~");
        }

        public ActionResult Tag()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Tags(string query)
        {
            var list = _technologyService.Find(query).ToArray();
            return new JsonNetResult(list, HttpStatusCode.OK);
        }
    }
}