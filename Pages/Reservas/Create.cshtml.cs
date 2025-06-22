using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TurismoApp.Data;
using TurismoApp.Models;

namespace DR4AT.Pages.Reservas
{
    public class CreateModel : PageModel
    {
        private readonly TurismoAppContext _context;

        public CreateModel(TurismoAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Reserva Reserva { get; set; } = new Reserva();

        // Propriedades para os selects
        public SelectList ClientesSelectList { get; set; }
        public SelectList PacotesSelectList { get; set; }

        // Carrega os dados dos selects
        private void LoadSelectLists()
        {
            var clientes = _context.Clientes.Where(c => !c.IsDeleted).ToList();
            var pacotes = _context.PacoteTuristicos.Where(p => !p.IsDeleted).ToList();

            ClientesSelectList = new SelectList(clientes, "Id", "Nome");
            PacotesSelectList = new SelectList(pacotes, "Id", "Titulo");
        }

        public IActionResult OnGet()
        {
            LoadSelectLists();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                LoadSelectLists();
                return Page();
            }

            _context.Reservas.Add(Reserva);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
