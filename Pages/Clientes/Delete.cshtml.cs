using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TurismoApp.Models;

namespace DR4AT.Pages.Clientes
{
    public class DeleteModel : PageModel
    {
        private readonly TurismoApp.Data.TurismoAppContext _context;

        public DeleteModel(TurismoApp.Data.TurismoAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cliente Cliente { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FirstOrDefaultAsync(m => m.Id == id);

            if (cliente == null || cliente.IsDeleted)
            {
                return NotFound();
            }

            Cliente = cliente;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var cliente = await _context.Clientes.FindAsync(Cliente.Id);

            if (cliente != null)
            {
                cliente.IsDeleted = true;
                _context.Clientes.Update(cliente);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
