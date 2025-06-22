using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TurismoApp.Data;
using TurismoApp.Models;

namespace DR4AT.Pages.PacotesTuristicos
{
    public class DeleteModel : PageModel
    {
        private readonly TurismoAppContext _context;

        public DeleteModel(TurismoAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PacoteTuristico PacoteTuristico { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacoteTuristico = await _context.PacoteTuristicos
                .FirstOrDefaultAsync(m => m.Id == id && !m.IsDeleted);

            if (pacoteTuristico == null)
            {
                return NotFound();
            }

            PacoteTuristico = pacoteTuristico;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacoteTuristico = await _context.PacoteTuristicos.FindAsync(id);

            if (pacoteTuristico != null)
            {
                pacoteTuristico.IsDeleted = true; 
                _context.PacoteTuristicos.Update(pacoteTuristico);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
