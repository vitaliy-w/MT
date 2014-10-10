using System;
using System.Linq;
using System.Web.Mvc;
using MT.DataAccess.EntityFramework;
using MT.DomainLogic;
using MT.ModelEntities.Entities;
using MT.Web.Models;

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
        /// Регистрирует нового пользователя
        /// </summary>
        /// <param name="user">новый пользователь полученный с формы регистрации</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Register(RegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                _accountService.RegisterUser(RegisterModelToUser(user));
                _unitOfWork.Commit();
            }

            return View(user);
        }

        /// <summary>
        /// вызывается на стороне клиента и провиряет уникальность поля "Email" когда пользовательзаполняет форму регистрации 
        /// </summary>
        /// <param name="email">значение из поля "Email" которе вводит пользователь</param>
        /// <returns></returns>
        public JsonResult CheckEmail(string email)
        {
            var result = _accountService.CheckEmail(email);
            return Json(!result, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// делает маппинг из модели вьюхи (Register) в User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private User RegisterModelToUser(RegisterViewModel model)
        {
            return new User()
            {
                Email = model.Email,
                Password = model.Password

            };
        }
	}
}