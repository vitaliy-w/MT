using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MT.DataAccess.EntityFramework;
using MT.DomainLogic;
using MT.ModelEntities.Entities;

namespace MT.Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly IUnitOfWork _db;

        public AccountController(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }

        //
        // GET: /Account/
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        public ActionResult Register(User user)
        {
            var service = new RegisterService();
            if (ModelState.IsValid)
            {
                service.SaveUser(_db, user);
            }

            return View(user);
        }

        public JsonResult CheckUserName(string userName)
        {
            var result = _db.Get<User>().Any(u => u.UserName == userName);
            return Json(!result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckEmail(string email)
        {
            var result = _db.Get<User>().Any(u => u.Email == email);
            return Json(!result, JsonRequestBehavior.AllowGet);
        }
	}
}