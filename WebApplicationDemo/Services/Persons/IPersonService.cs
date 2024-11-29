using WebApplicationDemo.Model;

namespace WebApplicationDemo.Services.Persons
{
    public interface IPersonService
    {
        Task<PersonItems?> GetPersonList();
        Task<PersonModel?> GetPersonById(int id);



        Task<PersonModel?> CreatePerson(PersonModel person);
        Task<PersonModel?> UpdatePerson(PersonModel person);
        Task<DeletePersonResponse?> DeletePerson(int id);



    }
}
