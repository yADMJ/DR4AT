using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using TurismoApp.Data;
using TurismoApp.Models;
using System.Threading.Tasks;

namespace TurismoApp.Pages.Clientes
{
    [Authorize]
    public class ClienteDeleteModel : PageModel
    {
        private readonly TurismoAppContext _context;

        public ClienteDeleteModel(TurismoAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cliente Cliente { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Cliente = await _context.Clientes.FindAsync(id);

            if (Cliente == null || Cliente.IsDeleted)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Cliente == null || Cliente.Id == 0)
            {
                return NotFound();
            }

            var clienteDb = await _context.Clientes.FindAsync(Cliente.Id);

            if (clienteDb == null)
            {
                return NotFound();
            }

            // Exclusão lógica
            clienteDb.IsDeleted = true;
            _context.Attach(clienteDb).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
