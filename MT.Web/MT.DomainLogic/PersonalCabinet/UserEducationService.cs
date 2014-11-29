using System.Collections.Generic;
using System.Linq;
using MT.DataAccess.EntityFramework;
using MT.ModelEntities.Entities;

namespace MT.DomainLogic.PersonalCabinet
{
    public class UserEducationService : IUserEducationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserEducationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Adds new entry or edit existed entry.
        /// </summary>
        public void Add(UserEducation userEducationFromClient)
        {

            if (IsPresent(userEducationFromClient.UserEmail, userEducationFromClient.EducationId))
            {
                var userEducationFromDB = _unitOfWork.Get<UserEducation>().First(x => (x.EducationId == userEducationFromClient.EducationId) && (x.UserEmail == userEducationFromClient.UserEmail));
                Edit(userEducationFromDB, userEducationFromClient);
            }

            else { _unitOfWork.Add(userEducationFromClient); }

        }


        /// <summary>
        /// Returns list of UserEducation's using userEmail as a key.
        /// </summary>
        public List<UserEducation> GetList(string userEmail)
        {
            if (!IsPresent(userEmail, 1)) return null;
            List<UserEducation> result = _unitOfWork.Get<UserEducation>().Where(x => x.UserEmail == userEmail).ToList();
    
            return result;
        }

        /// <summary>
        /// Edits entry in DB.
        /// </summary>
        private void Edit(UserEducation userEducationFromDB, UserEducation userEducationFromClient)
        {

            userEducationFromDB.EducationLevel = userEducationFromClient.EducationLevel;
            userEducationFromDB.Specialization = userEducationFromClient.Specialization;
            userEducationFromDB.NameOfSchool = userEducationFromClient.NameOfSchool;

            userEducationFromDB.MonthStartsFrom = userEducationFromClient.MonthStartsFrom;
            userEducationFromDB.YearStartsFrom = userEducationFromClient.YearStartsFrom;

            userEducationFromDB.YearEndsFrom = userEducationFromClient.YearEndsFrom;
            userEducationFromDB.MonthEndsFrom = userEducationFromClient.MonthEndsFrom;

            userEducationFromDB.AdditionalInformation = userEducationFromClient.AdditionalInformation;
        }



        /// <summary>
        /// Checks if entry already added in DB using userId and educationId. 
        /// </summary>
        private bool IsPresent(string userEmail, int educationId)
        {
            return _unitOfWork.Get<UserEducation>().Any(x => (x.EducationId == educationId) && (x.UserEmail == userEmail));

        }

      
    }
}
