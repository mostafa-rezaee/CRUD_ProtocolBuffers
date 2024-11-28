using GRPC_Service.Data;
using GRPC_Service.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GRPC_Service.Repositories
{
    public class PersonService : IPersonService
    {
        private readonly DataContext _dataContext;

        public PersonService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Person> CreatePerson(Person person)
        {
            try
            {
                var addPerson = _dataContext.Persons.Add(person);
                await _dataContext.SaveChangesAsync();
                return addPerson.Entity;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<bool> DeletePerson(int id)
        {
            var person = _dataContext.Persons.Where(x => x.Id == id).FirstOrDefault();
            if (person == null) return false;
            var removePerson = _dataContext.Remove(person);
            await _dataContext.SaveChangesAsync();
            return (removePerson != null) ? true : false;

        }

        public async Task<List<Person>> GetAllPersons()
        {
            return await _dataContext.Persons.ToListAsync();
        }

        public async Task<Person?> GetPersonById(int id)
        {
            return await _dataContext.Persons.Where(x => x.Id == id).FirstOrDefaultAsync();

        }

        public async Task<Person> UpdatePerson(Person person)
        {
            var updatePerson = _dataContext.Persons.Update(person);
            await _dataContext.SaveChangesAsync();
            return updatePerson.Entity;
        }
    }
}
