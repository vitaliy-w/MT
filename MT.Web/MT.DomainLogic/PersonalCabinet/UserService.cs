using System.Linq;
using MT.DataAccess.EntityFramework;
using MT.ModelEntities.Entities;

namespace MT.DomainLogic.PersonalCabinet
{

    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Edits entry using it's ID.
        /// </summary>
        private void Edit(UserInfo userInfo)
        {
            var oop = _unitOfWork.Get<UserInfo>().Single(x => x.UserEmail == userInfo.UserEmail);

            oop.IsMan = userInfo.IsMan;
            oop.Name = userInfo.Name;
            oop.SecondName = userInfo.SecondName;
            oop.DateOfBirth = userInfo.DateOfBirth;
            oop.City = userInfo.City;
            oop.CountryOfOrigin = userInfo.CountryOfOrigin;
            oop.UTCZone = userInfo.UTCZone;
        }

        /// <summary>
        /// Creates new userInfo or edit already existed entry.
        /// </summary>
        public void Add(UserInfo userInfo)
        {
            if (!IsPresent(userInfo.UserEmail))
            {
                _unitOfWork.Add(userInfo);
            }
            else Edit(userInfo);

        }

 
        /// <summary>
        /// Checks if item already present in database via string userEmail.
        /// </summary>
        public bool IsPresent(string userEmail)
        {
            
            bool isPresent = _unitOfWork.Get<UserInfo>().Any(x => x.UserEmail == userEmail);
            return isPresent;
        }

        
        /// <summary>
        /// Gets UserInfo via UserEmail
        /// </summary>
        public UserInfo Get(string userEmail)
        {
            UserInfo result = null;
            if(IsPresent(userEmail)) result = _unitOfWork.Get<UserInfo>().Single(x=>x.UserEmail==userEmail);
            return result;
        }


    }
}
