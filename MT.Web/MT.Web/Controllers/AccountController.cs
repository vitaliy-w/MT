using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using MT.DataAccess.EntityFramework;
using MT.DomainLogic;
using MT.DomainLogic.AccountService;
using MT.ModelEntities.Entities;

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
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                _accountService.RegisterUser(user);
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

        #region Регистрация через сервисы

        [HttpPost]
        public ActionResult ExternalRegister(string provider)
        {

            return new ExternalLoginResult(provider, Url.Action("ExternalRegisterCallback"));
        }

        public ActionResult ExternalRegisterCallback()
        {
            AuthenticationResult result = OAuthWebSecurity.VerifyAuthentication(Url.Action("ExternalRegisterCallback"));
            if (result.IsSuccessful)
            {
                _accountService.RegisterExternalUser(result.ProviderUserId, result.UserName, result.Provider);
                _unitOfWork.Commit();
            }
            return View();
        }

        internal class ExternalLoginResult : ActionResult
        {
            public ExternalLoginResult(string provider, string returnUrl)
            {
                Provider = provider;
                ReturnUrl = returnUrl;
            }

            public string Provider { get; private set; }
            public string ReturnUrl { get; private set; }

            public override void ExecuteResult(ControllerContext context)
            {
                OAuthWebSecurity.RequestAuthentication(Provider, ReturnUrl);
            }
        }
        #endregion
    }
}