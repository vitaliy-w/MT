using MT.ModelEntities.Entities;

namespace MT.DomainLogic
{
    public interface IAccountService
    {
        void RegisterUser(User user);
        bool CheckEmail(string email);
    }
}
