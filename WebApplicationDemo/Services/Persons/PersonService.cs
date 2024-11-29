using WebApplicationDemo.Helpers;
using WebApplicationDemo.Model;

namespace WebApplicationDemo.Services.Persons
{
    public class PersonService : IPersonService
    {
        private readonly HttpClient _httpClient;

        public PersonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PersonModel?> CreatePerson(PersonModel person)
        {
            var response = await _httpClient.PostAsJsonAsync<PersonModel>("person", person);
            return await response.Content.ReadFromJsonAsync<PersonModel>();
        }

        public async Task<DeletePersonResponse?> DeletePerson(int id)
        {
            var response = await _httpClient.DeleteAsync($"person/{id}");
            return await response.Content.ReadFromJsonAsync<DeletePersonResponse?>();
        }

        public async Task<PersonModel?> GetPersonById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<PersonModel>($"person/{id}");
            return response;
        }

        public async Task<PersonItems?> GetPersonList()
        {
            var response = await _httpClient.GetFromJsonAsync<PersonItems>("person/all/");
            return response;
        }

        public async Task<PersonModel?> UpdatePerson(PersonModel person)
        {
            var response = await _httpClient.PutAsJsonAsync<PersonModel>("person", person);
            return await response.Content.ReadFromJsonAsync<PersonModel>();
        }
    }
}
