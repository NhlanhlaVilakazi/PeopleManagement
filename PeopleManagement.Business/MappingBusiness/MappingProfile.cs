using AutoMapper;
using PeopleManagement.Data.DataModels.Accounts;
using PeopleManagement.Data.DataModels.Persons;
using PeopleManagement.Data.DataModels.Transaction;
using PeopleManagement.Data.Person;
using PeopleManagement.Models.Person;
using PeopleManagement.ViewModels.Accounts;
using PeopleManagement.ViewModels.Persons;
using PeopleManagement.ViewModels.Transaction;

namespace PeopleManagement.Business.MappingBusiness
{
    public static class ObjectMapper
    {
        public static IMapper Mapper => Lazy.Value;

        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PersonViewModel, Person>().ReverseMap();
                cfg.CreateMap<PersonAccountViewModel, PersonAccount>().ReverseMap();
                cfg.CreateMap<AccountViewModel, Account>().ReverseMap();
                cfg.CreateMap<TransactionViewModel, Transaction>().ReverseMap();
                cfg.CreateMap<AccountTransactionViewModel, AccountTransaction>().ReverseMap();
            });

            var mapper = config.CreateMapper();
            return mapper;
        });
        
    }
}
