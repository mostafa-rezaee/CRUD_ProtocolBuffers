using AutoMapper;
using GRPC_Service.Entities;

namespace GRPC_Service.Mapper
{
    public class PersonMapper : Profile
    {
        public PersonMapper()
        {
            CreateMap<Person, PersonModel>().ReverseMap();
        }
    }
}
