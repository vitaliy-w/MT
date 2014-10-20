using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
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
		private readonly IUserLoginService _userLoginService;
		
		public AccountController(IUnitOfWork unitOfWork, IAccountService accountService, IUserLoginService userLoginService)
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
	
	//----------------------------------------------------------------------------------------
        //User Authorization Section

        public ActionResult LoginHistory()
        {
            var model = _unitOfWork.Get<UserLoginHistory>().ToList();
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        /// <summary>
        /// Provides the authorization functionality for registered users
        /// </summary>
        /// <param name="userAuth">The UserAuthorization instance that is sent from the login form</param>
        /// <param name="returnUrl">The Url where user is went from</param>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(UserAuthorization userAuth, string returnUrl)
        {
            if (!ModelState.IsValid) return View(userAuth);

            var userId = _userLoginService.GetUserIdFromEmail(userAuth.Email);
            var message = new { text = "Login success!", status = true };

            if (userId < 0)
            {
                message = new { text = "Current user is not registered", status = false };
                return Json(message);
            }

            var userIsBan = _userLoginService.UserIsBan(userId);
            var banTime = _userLoginService.GetBanTime(userId).Hours;
            var validateUser = _userLoginService.ValidateUser(userAuth.Email, userAuth.Password);
            var countAttempt = _userLoginService.GetCountAttempt(userId);
            
            if (userIsBan)
            {
                if (banTime < 2)
                {
                    message = new { text = "Current user is banned", status = false};
                    return Json(message);
                }
            }

            if (!validateUser)
            {
                _userLoginService.SetUserLoginHistory(userId, DateTime.Now, false);
                if (countAttempt < 5)
                {
                    _userLoginService.SetCountAttemptToPlusOne(userId);
                    _unitOfWork.Commit();

                    message = new { text = "The user name or password provided is incorrect", status = false };
                    return Json(message);
                }

                _userLoginService.SetUserBan(userId, true);
                _userLoginService.SetStartBanTime(userId);
                _userLoginService.SetCountAttemptToZero(userId);
                _unitOfWork.Commit();

                message = new { text = "Current user is banned", status = false };
                return Json(message);
            }

            FormsAuthentication.SetAuthCookie(userAuth.Email, false);
            _userLoginService.SetUserBan(userId, false);
            _userLoginService.SetCountAttemptToZero(userId);
            _userLoginService.SetUserLoginHistory(userId, DateTime.Now, true);
            _unitOfWork.Commit();

            return Json(message);
        }
    }

}