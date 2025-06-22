using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TurismoApp.Data;
using TurismoApp.Models;

namespace DR4AT.Pages.CidadeDestinos
{
    public class DetailsModel : PageModel
    {
        private readonly TurismoApp.Data.TurismoAppContext _context;

        public DetailsModel(TurismoApp.Data.TurismoAppContext context)
        {
            _context = context;
        }

        public CidadeDestino CidadeDestino { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidadedestino = await _context.CidadeDestinos.FirstOrDefaultAsync(m => m.Id == id);
            if (cidadedestino == null)
            {
                return NotFound();
            }
            else
            {
                CidadeDestino = cidadedestino;
            }
            return Page();
        }
    }
}
