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

namespace DR4AT.Pages.PacotesTuristicos
{
    public class EditModel : PageModel
    {
        private readonly TurismoAppContext _context;

        public EditModel(TurismoAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PacoteTuristico PacoteTuristico { get; set; } = default!;

        [BindProperty]
        public List<int> SelectedCidadeIds { get; set; } = new();

        public List<SelectListItem> CidadesDestinos { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            PacoteTuristico = await _context.PacoteTuristicos
                .Include(p => p.Destinos)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (PacoteTuristico == null)
                return NotFound();

       
            SelectedCidadeIds = PacoteTuristico.Destinos.Select(d => d.Id).ToList();

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
            var pacoteToUpdate = await _context.PacoteTuristicos
                .Include(p => p.Destinos)
                .FirstOrDefaultAsync(p => p.Id == PacoteTuristico.Id);

            if (pacoteToUpdate == null)
                return NotFound();

            if (!ModelState.IsValid)
            {
                await CarregarCidades();
                return Page();
            }

         
            pacoteToUpdate.Titulo = PacoteTuristico.Titulo;
            pacoteToUpdate.DataInicio = PacoteTuristico.DataInicio;
            pacoteToUpdate.CapacidadeMaxima = PacoteTuristico.CapacidadeMaxima;
            pacoteToUpdate.Preco = PacoteTuristico.Preco;

      
            pacoteToUpdate.Destinos.Clear();

            if (SelectedCidadeIds != null && SelectedCidadeIds.Any())
            {
                var cidades = await _context.CidadeDestinos
                    .Where(c => SelectedCidadeIds.Contains(c.Id))
                    .ToListAsync();

                foreach (var cidade in cidades)
                {
                    pacoteToUpdate.Destinos.Add(cidade);
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

        private async Task CarregarCidades()
        {
            CidadesDestinos = await _context.CidadeDestinos
                .Where(c => !c.IsDeleted)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = string.IsNullOrEmpty(c.Pais) ? c.Nome : $"{c.Nome} - {c.Pais}"
                }).ToListAsync();
        }
    }
}
