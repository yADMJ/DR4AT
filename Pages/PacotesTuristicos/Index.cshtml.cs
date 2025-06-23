using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TurismoApp.Data;
using TurismoApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace DR4AT.Pages.PacotesTuristicos
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly TurismoAppContext _context;

        public IndexModel(TurismoAppContext context)
        {
            _context = context;
        }

        public IList<PacoteTuristico> PacoteTuristico { get; set; } = default!;

        public async Task OnGetAsync()
        {
            PacoteTuristico = await _context.PacoteTuristicos
                .Include(p => p.Destinos) 
                .Where(p => !p.IsDeleted)
                .ToListAsync();
        }
    }
}
