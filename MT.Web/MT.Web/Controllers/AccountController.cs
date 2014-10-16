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
        private readonly IUserLoginService _userLoginService;

        public AccountController(IUnitOfWork unitOfWork, IUserLoginService userLoginService)
        {
            _unitOfWork = unitOfWork;
            _userLoginService = userLoginService;
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
                _unitOfWork.Add(user);
                _unitOfWork.Commit();
                return RedirectToAction("LoginHistory", "Account");
            }

            return View(user);
        }

        public JsonResult CheckUserName(string userName)
        {
            var result = _unitOfWork.Get<User>().Any(u => u.UserName == userName);
            return Json(!result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckEmail(string email)
        {
            var result = _unitOfWork.Get<User>().Any(u => u.Email == email);
            return Json(!result, JsonRequestBehavior.AllowGet);
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