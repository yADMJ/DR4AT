using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TurismoApp.Models;
using TurismoApp.Data; 

namespace TurismoApp.Pages.Clientes
{
    public class ClienteDetailsModel : PageModel
    {
        private readonly TurismoAppContext _context;

        public ClienteDetailsModel(TurismoAppContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public Cliente Cliente { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (Id == 0)
                return NotFound();

            Cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == Id);

            if (Cliente == null)
                return NotFound();

            return Page();
        }
    }
}
