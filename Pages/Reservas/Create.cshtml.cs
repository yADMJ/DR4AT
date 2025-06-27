using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TurismoApp.Data;
using TurismoApp.Models;
using Microsoft.EntityFrameworkCore;

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

            var pacote = await _context.PacoteTuristicos.FindAsync(Reserva.PacoteTuristicoId);

            if (pacote == null || pacote.IsDeleted)
            {
                ModelState.AddModelError(string.Empty, "Pacote turístico inválido.");
                LoadSelectLists();
                return Page();
            }

            var reservasExistentes = await _context.Reservas
                .CountAsync(r =>
                    r.PacoteTuristicoId == Reserva.PacoteTuristicoId &&
                    !r.IsDeleted);

            if (reservasExistentes >= pacote.CapacidadeMaxima)
            {
                ModelState.AddModelError(string.Empty, "Não é possível realizar a reserva. Capacidade máxima atingida.");
                LoadSelectLists();
                return Page();
            }

            bool clienteJaReservouNaData = await _context.Reservas
                .AnyAsync(r =>
                    r.ClienteId == Reserva.ClienteId &&
                    r.DataReserva.Date == Reserva.DataReserva.Date &&
                    !r.IsDeleted);

            if (clienteJaReservouNaData)
            {
                ModelState.AddModelError(string.Empty, "Este cliente já possui uma reserva para esta data.");
                LoadSelectLists();
                return Page();
            }

            _context.Reservas.Add(Reserva);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }



    }
}
