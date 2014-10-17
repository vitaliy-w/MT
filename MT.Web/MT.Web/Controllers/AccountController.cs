using System;
using System.Linq;
using System.Web.Mvc;
using MT.DataAccess.EntityFramework;
using MT.DomainLogic;
using MT.ModelEntities.Entities;
using MT.Web.ViewModels;

namespace MT.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountService _accountService;

        public AccountController(IUnitOfWork unitOfWork, IAccountService accountService)
        {
            _unitOfWork = unitOfWork;
            _accountService = accountService;
        }

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Account/
        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="user">a new user which is passed from user form</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Register(RegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                _accountService.RegisterUser(new User(){Email = user.Email, Password = user.Password});
                _unitOfWork.Commit();
            }

            return View(user);
        }

        /// <summary>
        /// verifies the existence of such E-mail in the database 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public JsonResult CheckEmail(string email)
        {
            var result = _accountService.CheckEmail(email);
            return Json(!result, JsonRequestBehavior.AllowGet);
        }

	}
}