using System.Linq;
using System.Net;
using System.Web.Mvc;
using MT.DomainLogic;
using MT.Utility.Json;

namespace MT.Web.Controllers
{
    public class TechnologyController : Controller
    {
        private ITechnologyService _technologyService;
        public TechnologyController(ITechnologyService technologyService)
        {
            _technologyService = technologyService;
        }

        [HttpPost]
        public ActionResult Search(string query)
        {
            var list = _technologyService.Find(query).ToArray();
            return new JsonNetResult(list, HttpStatusCode.OK);
        }
	}
}