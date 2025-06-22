using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TurismoApp.Models;

namespace TurismoApp.Pages.Clientes
{
    public class CreateClienteModel : PageModel
    {
        [BindProperty]
        public Cliente Cliente { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Aqui você pode salvar no banco com EF Core
            // dbContext.Clientes.Add(Cliente);
            // dbContext.SaveChanges();


            TempData["SuccessMessage"] = "Cliente cadastrado com sucesso!";
            return RedirectToPage("/Index");
        }
    }
}
