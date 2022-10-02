using PeopleManagement.Business.MappingBusiness;
using PeopleManagement.Data.DataModels.Accounts;
using PeopleManagement.Repository.Implementation;
using PeopleManagement.ViewModels.Accounts;

namespace PeopleManagement.Business.AccountsBusiness
{
    public class AccountBusiness
    {
        public void CreatePersonAccount(AccountViewModel accountInfo)
        {
            using var repo = new AccountRepository();
            repo.AddNewAccount(ObjectMapper.Mapper.Map<Account>(accountInfo));
        }
    }
}
