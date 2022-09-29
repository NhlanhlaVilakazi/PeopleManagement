using AutoMapper;
using PeopleManagement.Data.Person;
using PeopleManagement.Models.Person;

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
            });

            var mapper = config.CreateMapper();
            return mapper;
        });
        
    }
}
