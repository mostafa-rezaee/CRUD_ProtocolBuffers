using GRPC_Service.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GRPC_Service.Repositories
{
    public interface IPersonService
    {
        public Task<Person?> GetPersonById(int id);
        public Task<Person> CreatePerson(Person person);
        public Task<Person> UpdatePerson(Person person);
        public Task<bool> DeletePerson(int id);
        public Task<List<Person>> GetAllPersons();

    }
}
