using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TurismoApp.Data;
using TurismoApp.Models;

namespace DR4AT.Pages.CidadeDestinos
{
    public class CreateModel : PageModel
    {
        private readonly TurismoApp.Data.TurismoAppContext _context;

        public CreateModel(TurismoApp.Data.TurismoAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CidadeDestino CidadeDestino { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.CidadeDestinos.Add(CidadeDestino);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
