using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TurismoApp.Data;
using TurismoApp.Models;

namespace DR4AT.Pages.Reservas
{
    public class DeleteModel : PageModel
    {
        private readonly TurismoAppContext _context;

        public DeleteModel(TurismoAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Reserva Reserva { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.PacoteTuristico)
                .FirstOrDefaultAsync(m => m.Id == id && !m.IsDeleted);

            if (reserva == null)
            {
                return NotFound();
            }

            Reserva = reserva;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var reserva = await _context.Reservas.FindAsync(Reserva.Id);

            if (reserva != null)
            {
                reserva.IsDeleted = true;
                _context.Reservas.Update(reserva);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
