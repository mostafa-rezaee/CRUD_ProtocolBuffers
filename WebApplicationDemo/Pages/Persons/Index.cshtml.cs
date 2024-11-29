using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationDemo.Model;
using WebApplicationDemo.Services.Persons;

namespace WebApplicationDemo.Pages.Persons
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly IPersonService _personService;

        public IndexModel(IPersonService personService)
        {
            _personService = personService;
        }

        public PersonItems Persons { get; set; }
        public async Task OnGet()
        {
            Persons = await _personService.GetPersonList();

        }
    }
}
