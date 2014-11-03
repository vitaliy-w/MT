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
            var oop = _unitOfWork.Get<UserInfo>().Single(x => x.Id == userInfo.Id);

            oop.IsMan = userInfo.IsMan;
            oop.Name = userInfo.Name;
            oop.SecondName = userInfo.SecondName;
            oop.DateOfBirth = userInfo.DateOfBirth;
            oop.City = userInfo.City;
            oop.CountryOfOrigin = userInfo.CountryOfOrigin;
        }

        /// <summary>
        /// Creates new userInfo or edit already existed entry.
        /// </summary>
        public void Add(UserInfo userInfo)
        {
            if (!IsPresent(userInfo.Id))
            {
                _unitOfWork.Add(userInfo);
            }
            else Edit(userInfo);

        }

        /// <summary>
        /// Checks if item already present in database.
        /// </summary>
        public bool IsPresent(int id)
        {
            bool isPresent = _unitOfWork.Get<UserInfo>().Any(x => x.Id == id);
            return isPresent;
        }


    }
}
