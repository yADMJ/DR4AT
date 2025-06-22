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

namespace DR4AT.Pages.CidadeDestinos
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly TurismoApp.Data.TurismoAppContext _context;

        public IndexModel(TurismoApp.Data.TurismoAppContext context)
        {
            _context = context;
        }

        public IList<CidadeDestino> CidadeDestino { get;set; } = default!;

        public async Task OnGetAsync()
        {
            CidadeDestino = await _context.CidadeDestinos
                .Where(cd => !cd.IsDeleted)
                .ToListAsync();
        }
    }
}
