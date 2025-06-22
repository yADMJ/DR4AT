using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TurismoApp.Models;

namespace DR4AT.Pages.CidadeDestinos
{
    public class DeleteModel : PageModel
    {
        private readonly TurismoApp.Data.TurismoAppContext _context;

        public DeleteModel(TurismoApp.Data.TurismoAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CidadeDestino CidadeDestino { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CidadeDestinos == null)
            {
                return NotFound();
            }

            var cidade = await _context.CidadeDestinos.FirstOrDefaultAsync(m => m.Id == id);

            if (cidade == null || cidade.IsDeleted)
            {
                return NotFound();
            }

            CidadeDestino = cidade;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var cidade = await _context.CidadeDestinos.FindAsync(CidadeDestino.Id);

            if (cidade != null)
            {
                cidade.IsDeleted = true;
                _context.CidadeDestinos.Update(cidade);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
