using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TurismoApp.Data;
using TurismoApp.Models;

namespace DR4AT.Pages.CidadeDestinos
{
    public class EditModel : PageModel
    {
        private readonly TurismoApp.Data.TurismoAppContext _context;

        public EditModel(TurismoApp.Data.TurismoAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CidadeDestino CidadeDestino { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidadedestino =  await _context.CidadeDestinos.FirstOrDefaultAsync(m => m.Id == id);
            if (cidadedestino == null)
            {
                return NotFound();
            }
            CidadeDestino = cidadedestino;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CidadeDestino).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CidadeDestinoExists(CidadeDestino.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CidadeDestinoExists(int id)
        {
            return _context.CidadeDestinos.Any(e => e.Id == id);
        }
    }
}
