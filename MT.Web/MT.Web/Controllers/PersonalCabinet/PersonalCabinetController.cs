using System;
using System.Web.Mvc;
using MT.DataAccess.EntityFramework;
using MT.DomainLogic;
using MT.DomainLogic.PersonalCabinet;
using MT.ModelEntities.Entities;
using MT.Utility.Json;
using MT.Utility.OtherTools;
using MT.Web.ViewModels;

namespace MT.Web.Controllers.PersonalCabinet
{
    [Authorize]
    public class PersonalCabinetController : Controller
    {
        private IUnitOfWork db;
        private IUserService _userService;
        private IUserLoginService _userLoginService;

        public PersonalCabinetController(IUnitOfWork unitOfWork, IUserService userService, IUserLoginService userLoginService)
        {
            this.db = unitOfWork;
            _userService = userService;
            _userLoginService = userLoginService;

        }

        /// <summary>
        /// Main page for Personal Cabinet.
        /// </summary>
        public ActionResult Index()
        {
            var userMail = Request.Cookies.GetUserMailFromFormsAuthentication();
            if (_userLoginService.GetUserByEmail(userMail) == null) return View();
            var model = UserInfoViewModel.CreateFromUserInfo(_userService.Get(userMail));

            return View(model);
        }


        /// <summary>
        /// Creates partial view with navigation list.
        /// </summary>
        [ChildActionOnly]
        public ViewResult _leftSide()
        {
            return View();
        }


        /// <summary>
        /// Adds new UserInfo to DB or edit Users already existed information and returns status.
        /// </summary>
        [HttpPost]
        public string Create(UserInfoViewModel userInfo)
        {

            if (!ModelState.IsValid)
            {
                return ErrorModel.CreateErrorModelViaModelState(ModelState);
            }

            var userMail = Request.Cookies.GetUserMailFromFormsAuthentication();
            if (_userLoginService.GetUserByEmail(userMail) == null) return new ErrorModel( "We cant find you in our DB" , "DB error").ToJson();

            UserInfo result = userInfo.ConvertToUserInfoItem(userMail);
            result.UserEmail = userMail;

            try
            {
                _userService.Add(result);
                db.Commit();
            }
            catch (Exception)
            {
                var errorAddingtoDB = new ErrorModel("Some troubles with DB happened, try to add your info later." ,"DataBaseError" );
                return errorAddingtoDB.ToJson();
            }

            var succesResult = new JsonNetResult(new { header = "Succes", message = "Resources added succesfully" });
            return succesResult.ToJson();


        }


    }
}