using MT.ModelEntities.Entities;

namespace MT.DomainLogic.AccountService
{
    public interface IAccountService
    {
        void RegisterUser(User user);
        void RegisterExternalUser(string id, string userName, string provider);
        bool CheckEmail(string email);
    }
}
