using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TurismoApp.Data;
using TurismoApp.Models;

namespace DR4AT.Pages.PacotesTuristicos
{
    public class DetailsModel : PageModel
    {
        private readonly TurismoAppContext _context;

        public DetailsModel(TurismoAppContext context)
        {
            _context = context;
        }

        public PacoteTuristico PacoteTuristico { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            PacoteTuristico = await _context.PacoteTuristicos
                .Include(p => p.Destinos) // importante incluir os destinos
                .FirstOrDefaultAsync(m => m.Id == id);

            if (PacoteTuristico == null)
                return NotFound();

            return Page();
        }
    }
}
