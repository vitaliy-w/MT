using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MT.ModelEntities.Entities;
using MT.DataAccess.EntityFramework;

namespace MT.Web.Controllers
{
    public class ResourceController : Controller
    {
        private UnitOfWork db = new UnitOfWork(new MentorDataContext());

        // GET: /Resource/
        public ActionResult Index()
        {
            return View(db.Get<Resource>().ToList());
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
            if (ModelState.IsValid)
            {
                db.Add<Resource>(resource);
                db.Commit();
                return RedirectToAction("Index");
            }

            return View(resource);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
