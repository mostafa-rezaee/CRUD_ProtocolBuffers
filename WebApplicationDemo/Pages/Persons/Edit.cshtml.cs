using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationDemo.Helpers;
using WebApplicationDemo.Model;
using WebApplicationDemo.Services.Persons;

namespace WebApplicationDemo.Pages.Persons
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IPersonService _personService;

        public EditModel(IPersonService personService)
        {
            _personService = personService;
        }

        public PersonModel PersonModel { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            PersonModel = await _personService.GetPersonById(id.Value);
            if (PersonModel == null)
            {
                return NotFound();
            }
            string birthDateString = PersonModel.BirthDate.ToPersianDateString();
            var _array = birthDateString.Split('/');
            PersonModel.BirthDate.Year = Convert.ToInt32(_array[0]);
            PersonModel.BirthDate.Month = Convert.ToInt32(_array[1]);
            PersonModel.BirthDate.Day = Convert.ToInt32(_array[2]);
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            PersonModel.BirthDate = PersonModel.BirthDate.ToPersonBirthDate();
            var model = await _personService.UpdatePerson(PersonModel);
            return RedirectToPage("./Index");

        }
    }
}
