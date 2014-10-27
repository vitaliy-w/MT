using MT.ModelEntities.Entities;

namespace MT.DomainLogic.PersonalCabinet
{
    public interface IUserService
    {

        void Add(UserInfo userInfo);
        bool IsPresent(UserInfo userInfo);

    }
}
