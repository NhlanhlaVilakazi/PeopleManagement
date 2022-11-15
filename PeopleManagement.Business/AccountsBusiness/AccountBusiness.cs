using PeopleManagement.Business.MappingBusiness;
using PeopleManagement.Data.DataModels.Accounts;
using PeopleManagement.Repository.Implementation;
using PeopleManagement.Repository.Interface;
using PeopleManagement.ViewModels.Accounts;

namespace PeopleManagement.Business.AccountsBusiness
{
    public class AccountBusiness
    {
        private readonly IAccountRepository _accountRepository;
        
        public AccountBusiness(IAccountRepository accountRepo)
        {
            _accountRepository = accountRepo;
        }
        public void CreatePersonAccount(AccountViewModel accountInfo)
        {
            _accountRepository.AddNewAccount(ObjectMapper.Mapper.Map<Account>(accountInfo));
        }

        public void UpdateAccountInformation(AccountViewModel accountInfo)
        {
            _accountRepository.UpdateAccount(ObjectMapper.Mapper.Map<Account>(accountInfo));
        }

        public AccountViewModel GetAccountInformation(int accountCode)
        {
            var accountInfo = _accountRepository.GetAccountInfomationByCode(accountCode);
            return ObjectMapper.Mapper.Map<AccountViewModel>(accountInfo);
        }

        public bool DoesAccountExist(string accountNumber, bool isUpdate)
        {
            return _accountRepository.AccountAlreadyExist(accountNumber, isUpdate);
        }
    }
}
