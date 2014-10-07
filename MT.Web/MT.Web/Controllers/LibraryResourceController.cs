using System.Linq;
using System.Web.Mvc;
using MT.DomainLogic;
using MT.ModelEntities.Entities;
using MT.DataAccess.EntityFramework;

namespace MT.Web.Controllers
{
    public class LibraryResourceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILibraryResourceService _libraryResourceService;


        public LibraryResourceController(IUnitOfWork unitOfWork, ILibraryResourceService libraryResourceService)
        {
            _unitOfWork = unitOfWork;
            _libraryResourceService = libraryResourceService;
        }

        public ActionResult Index()
        {
            var model = _unitOfWork.Get<LibraryResource>().ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates a new library resource.
        /// </summary>
        /// <param name="libraryResource">A new library resource which is passed from a user form.</param>
        [HttpPost]
        public ActionResult Create(LibraryResource libraryResource)
        {
            if (!ModelState.IsValid) 
                return View(libraryResource);


            _libraryResourceService.Create(libraryResource);
            _unitOfWork.Commit();
            return RedirectToAction("Index");
        }
    }
}
