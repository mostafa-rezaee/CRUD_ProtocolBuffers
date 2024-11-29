using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationDemo.Model;
using WebApplicationDemo.Services.Persons;

namespace WebApplicationDemo.Pages.Persons
{
    public class DeleteModel : PageModel
    {
        private readonly IPersonService _personService;

        public DeleteModel(IPersonService personService)
        {
            _personService = personService;
        }

        [BindProperty]
        public PersonModel PersonModel { get; set; }
        public string ErrorMessage { get; set; }
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
            return Page();
        }

        public async Task<IActionResult> OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var response = await _personService.DeletePerson(id.Value);
            if (response == null || !response.IsDelete)
            {
                ErrorMessage = $"Delete {id} faild! Try again.";
                return RedirectToAction("./Delete", new { id = id});
            }
            return RedirectToPage("./Index");

        }
    }
}
