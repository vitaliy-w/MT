using System;
using System.Linq;
using System.Web.Mvc;
using MT.DataAccess.EntityFramework;
using MT.ModelEntities.Entities;

namespace MT.Web.Controllers
{
    public class AccountController : Controller
    {

        private IUnitOfWork db;

        public AccountController(IUnitOfWork unitOfWork)
        {
            this.db = unitOfWork;
        }

        //
        // GET: /Account/
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                user.Created = DateTime.Now;
                db.Add(user);
                db.Commit();
                return RedirectToAction("Index", "Test");
            }

            return View(user);
        }

        public JsonResult CheckUserName(string userName)
        {
            var result = db.Get<User>().Any(u => u.UserName == userName);
            return Json(!result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckEmail(string email)
        {
            var result = db.Get<User>().Any(u => u.Email == email);
            return Json(!result, JsonRequestBehavior.AllowGet);
        }
	}
}