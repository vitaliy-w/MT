using System.Linq;
using MT.DataAccess.EntityFramework;
using MT.ModelEntities.Entities;

namespace MT.DomainLogic.PersonalCabinet
{
    
    public class UserInfoService : IUserInfoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserInfoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Edits entry using it's ID.
        /// </summary>
        
        public void Edit(UserInfo userInfo)
        {
            var oop = _unitOfWork.Get<UserInfo>().First(x => x.Id == userInfo.Id);
            oop = userInfo;
        }


        /// <summary>
        /// Creates new userInfo or edit already existed entry.
        /// </summary>
        public void Add(UserInfo userInfo)
        {
            if (!IsPresent(userInfo))
            {
                _unitOfWork.Add(userInfo);
            }
            else Edit(userInfo);

        }

        /// <summary>
        /// Checks if item already present in database.
        /// </summary>
        public bool IsPresent(UserInfo userInfo)
        {
            var isPresent = _unitOfWork.Get<UserInfo>().Any(x => x.Id == userInfo.Id);
            return isPresent;
        }


    }
}
