using System.Linq;
using System.Web.Mvc;
using MT.ModelEntities.Entities;
using MT.DataAccess.EntityFramework;
using MT.DomainLogic;

namespace MT.Web.Controllers
{
    public class ResourceController : Controller
    {
        private readonly IUnitOfWork _db;

        public ResourceController(IUnitOfWork db)
        {
            _db = db;
        }

        // GET: /Resource/
        public ActionResult Index()
        {
            return View(_db.Get<Resource>().ToList());
        }

        // GET: /Resource/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: /Resource/Create
        [HttpPost]
        public ActionResult Create(Resource resource)
        {
            if (!ModelState.IsValid) return View(resource);
            ResourceLogic.SaveResource(_db, resource);
            return RedirectToAction("Index");
        }
    }
}
