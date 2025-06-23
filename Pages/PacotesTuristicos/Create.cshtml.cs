using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TurismoApp.Data;
using TurismoApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DR4AT.Pages.PacotesTuristicos
{
    public class CreateModel : PageModel
    {
        private readonly TurismoAppContext _context;

        public CreateModel(TurismoAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PacoteTuristico PacoteTuristico { get; set; } = default!;

        public List<SelectListItem> CidadesDestinos { get; set; } = new List<SelectListItem>();

        [BindProperty]
        public List<int> SelectedCidadeIds { get; set; } = new List<int>();

        public async Task<IActionResult> OnGetAsync()
        {
            CidadesDestinos = await _context.CidadeDestinos
                .Where(c => !c.IsDeleted)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = string.IsNullOrEmpty(c.Pais) ? c.Nome : $"{c.Nome} - {c.Pais}"
                }).ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (PacoteTuristico.DataInicio.Date < DateTime.Today)
            {
                ModelState.AddModelError("PacoteTuristico.DataInicio", "A data de início não pode ser no passado.");
            }

            if (!ModelState.IsValid)
            {
                await OnGetAsync();
                return Page();
            }

            if (SelectedCidadeIds != null && SelectedCidadeIds.Any())
            {
                var cidadesSelecionadas = await _context.CidadeDestinos
                    .Where(c => SelectedCidadeIds.Contains(c.Id))
                    .ToListAsync();

                foreach (var cidade in cidadesSelecionadas)
                {
                    PacoteTuristico.Destinos.Add(cidade);
                }
            }

            _context.PacoteTuristicos.Add(PacoteTuristico);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
