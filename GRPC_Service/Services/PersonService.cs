using AutoMapper;
using Grpc.Core;
using GRPC_Service.Helpers;
using GRPC_Service.Protos;
using GRPC_Service.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GRPC_Service.Services
{
    public class PersonService : GRPC_Service.Protos.PersonService.PersonServiceBase
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonService(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            this._mapper = mapper;
        }

        public override async Task<Persons> GetPersonsList(Empty request, ServerCallContext context)
        {
            var data = await _personService.GetAllPersons();
            Persons persons = new Persons();
            foreach (var person in data)
            {
                persons.Items.Add(person.ConvertToProtoPerson());
            }
            return persons;
        }

        public override async Task<PersonModel> GetPerson(GetPersonRequest request, ServerCallContext context)
        {
            var data = await _personService.GetPersonById(request.PersonId);
            //return _mapper.Map<PersonModel>(data);
            return data.ConvertToProtoPerson();
        }

        public override async Task<PersonModel> CreatePerson(CreatePersonRequest request, ServerCallContext context)
        {
            var entityPerson = request.Person.ConvertToPerson();
            await _personService.CreatePerson(entityPerson);
            return entityPerson.ConvertToProtoPerson();
        }

        public override async Task<PersonModel> UpdatePerson(UpdatePersonRequest request, ServerCallContext context)
        {
            var entityPerson = request.Person.ConvertToPerson();
            await _personService.UpdatePerson(entityPerson);
            return entityPerson.ConvertToProtoPerson();
        }

        public override async Task<DeletePersonResponse> DeletePerson(DeletePersonRequest request, ServerCallContext context)
        {
            var deleteResult = await _personService.DeletePerson(request.PersonId);
            return new DeletePersonResponse { IsDelete = deleteResult };
        }
    }
}
