using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TurismoApp.Models;

namespace TurismoApp.Pages.CidadeDestino
{
    public class CreateCidadeDestinoModel : PageModel
    {
        [BindProperty]
        public TurismoApp.Models.CidadeDestino CidadeDestino { get; set; }


        public string Message { get; set; }

        public void OnGet()
        {
            // Página de cadastro
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); 
            }

            // Salvar no banco de dados 
            // dbContext.Cidades.Add(CidadeDestino);
            // dbContext.SaveChanges();

            TempData["SuccessMessage"] = "Cidade cadastrada com sucesso!";
            return RedirectToPage("/Index");
        }
    }
}
