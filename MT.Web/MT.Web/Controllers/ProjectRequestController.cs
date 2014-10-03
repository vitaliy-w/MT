using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MT.DataAccess.EntityFramework;
using MT.ModelEntities.Entities;
using MT.DomainLogic;
namespace MT.Web.Controllers
{
    public class ProjectRequestController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProjectRequestService _projectRequestServicel;

        public ProjectRequestController(IUnitOfWork unitOfWork, IProjectRequestService projectRequestService)
        {
            _unitOfWork = unitOfWork;
            _projectRequestServicel = projectRequestService;
        }

        public ActionResult Create()
        {
            var projectYourRequest = new ProjectRequest();

            return View(projectYourRequest);
        }

        [HttpPost]
        public ActionResult SaveFormRequest(ProjectRequest projectYourRequest)
        {
            _projectRequestServicel.SaveOrUpdateRequest(projectYourRequest);
            _unitOfWork.Commit();
            
            return View("Index");
        }
    }
}