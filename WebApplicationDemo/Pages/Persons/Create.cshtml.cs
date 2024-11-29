using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationDemo.Helpers;
using WebApplicationDemo.Model;
using WebApplicationDemo.Services.Persons;

namespace WebApplicationDemo.Pages.Persons
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IPersonService _personService;

        public CreateModel(IPersonService personService)
        {
            _personService = personService;
        }

        public PersonModel PersonModel { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            PersonModel.BirthDate = PersonModel.BirthDate.ToPersonBirthDate();
            var model = await _personService.CreatePerson(PersonModel);
            return RedirectToPage("./Index");

        }
    }
}
