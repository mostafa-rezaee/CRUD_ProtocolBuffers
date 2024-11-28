using Grpc.Net.Client;
using GRPC_Service.Protos;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly GrpcChannel _grpcChannel;
        private readonly PersonService.PersonServiceClient _personServiceClient;
        private readonly IConfiguration _configuration;

        public PersonController(IConfiguration configuration)
        {
            _configuration = configuration;
            _grpcChannel = GrpcChannel.ForAddress(_configuration.GetValue<string>("GrpcSettings:PersonServiceUrl"));
            _personServiceClient = new PersonService.PersonServiceClient(_grpcChannel);
            
        }

        [HttpGet("all")]
        public async Task<Persons?> GetPersonList()
        {
            try
            {
                var data = await _personServiceClient.GetPersonsListAsync(new Empty { });
                return data;
            }
            catch
            {

            }
            return null;
        }

        [HttpGet]
        public async Task<PersonModel?> GetPersonById(int id)
        {
            try
            {
                var request = new GetPersonRequest { PersonId = id };
                var data = await _personServiceClient.GetPersonAsync(request);
                return data;
            }
            catch
            {

            }
            return null;
        }

        [HttpPost]
        public async Task<PersonModel?> CreatePerson(Person person)
        {
            try
            {
                var personModel = new PersonModel
                {
                    //Id = person.Id,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    NationalCode = person.NationalCode,
                    BirthDate = new Date
                    {
                        Year = person.BirthDate.Year,
                        Month = person.BirthDate.Month,
                        Day = person.BirthDate.Day
                    }
                };
                var data = await _personServiceClient.CreatePersonAsync(new CreatePersonRequest { Person = personModel });
                return data;
            }
            catch
            {

            }

            return null;
        }

        [HttpPut]
        public async Task<PersonModel?> UpdatePerson(Person person)
        {
            try
            {
                var personModel = new PersonModel
                {
                    Id = person.Id,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    NationalCode = person.NationalCode,
                    BirthDate = new Date
                    {
                        Year = person.BirthDate.Year,
                        Month = person.BirthDate.Month,
                        Day = person.BirthDate.Day
                    }
                };
                var data = await _personServiceClient.UpdatePersonAsync(new UpdatePersonRequest { Person = personModel });
                return data;
            }
            catch
            {

            }
            return null;
        }

        [HttpDelete]
        public async Task<DeletePersonResponse?> DeletePerson(int id)
        {
            try
            {
                var request = new DeletePersonRequest { PersonId = id };
                var data = await _personServiceClient.DeletePersonAsync(request);
                return data;
            }
            catch
            {
            }
            return null;
        }
    }
}
