using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MT.ModelEntities.Entities;
using MT.DomainLogic;
namespace MT.Web.Controllers
{
    public class PostYourRequestController : Controller
    {
        // GET: PostYourRequest
        public ActionResult Index()
        {
            PostRequest postYourRequest = new PostRequest();

            return View(postYourRequest);
        }

        [HttpPost]
        public ActionResult SaveFormRequest(PostRequest postYourRequest)
        {
            PostYourRequestLogic logic = new PostYourRequestLogic();
            logic.SaveRequest(postYourRequest);
            TempData["Success"] = "Your Post Request Success";
            return View("Index");
        }
    }
}