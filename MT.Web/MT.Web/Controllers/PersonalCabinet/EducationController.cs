using System.Collections.Generic;
using System.Web.Mvc;
using MT.DataAccess.EntityFramework;
using MT.DomainLogic;
using MT.DomainLogic.PersonalCabinet;
using MT.ModelEntities.Entities;
using MT.Utility.Json;
using MT.Utility.OtherTools;
using MT.Utility.Validation;
using MT.Web.Models;

namespace MT.Web.Controllers.PersonalCabinet
{

    [Authorize]
    public class EducationController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private IUserEducationService _userEducationService;
        private IUserLoginService _userLoginService;

        public EducationController(IUnitOfWork unitOfWork, IUserEducationService userEducationService, IUserLoginService userLoginService)
        {
            this._unitOfWork = unitOfWork;
            _userEducationService = userEducationService;
            _userLoginService = userLoginService;
        }

        public ActionResult Index()
        {
            var userEmail = Request.Cookies.GetUserMailFromFormsAuthentication();
            var currentUsersEducationList = PutRange(_userEducationService.GetList(userEmail));
            var viewModel = UserEducationViewModel.CreateList(currentUsersEducationList);
            return View(viewModel);
        }


        [HttpPost]
        public string AddUserEducation(IEnumerable<UserEducationViewModel> userEducationModelList)
        {
            if (!ModelState.IsValid)
            {
                return ServerValidationService.CreateErrorModelViaModelState(ModelState);
            }

            var mail = Request.Cookies.GetUserMailFromFormsAuthentication();
            if (_userLoginService.GetUserByEmail(mail) == null) return new ErrorModel("We cant find you in our DB", "DB error").ToJson();
            
            foreach (var userEducation in userEducationModelList)
            {
                var item = userEducation.ConvertToUserEducationItem(mail);
                _userEducationService.Add(item);
            }

            _unitOfWork.Commit();

            var succesResult = new JsonNetResult(new { header = "Succes", message = "Resources added succesfully" });
            return succesResult.ToJson();
        }


        /// We need this method cause View accepted only list of 3 not null items. Change View and you can del this method.
        private static IEnumerable<UserEducation> PutRange(IList<UserEducation> source)
        {
            var result = new List<UserEducation>() { new UserEducation(), new UserEducation(), new UserEducation() };
            if (source == null) return result;
            for (int i = 0; i < source.Count; i++)
            {
                result[i] = source[i];
            }

            return result;
        }

    }



}
