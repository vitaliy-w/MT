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
            var model = _db.Get<Resource>().ToList();
            return View(model);
        }

        // GET: /Resource/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: /Resource/Create
        /// <summary>
        /// Action for creating new Resource
        /// </summary>
        /// <param name="resource">Data represent new Resource getting from form</param>
        [HttpPost]
        public ActionResult Create(Resource resource)
        {
            if (!ModelState.IsValid) return View(resource);
            var service = new ResourceService();
            service.SaveResource(_db, resource);
            return RedirectToAction("Index");
        }
    }
}
