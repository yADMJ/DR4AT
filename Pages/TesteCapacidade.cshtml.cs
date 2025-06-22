using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using TurismoApp.Models;

namespace TurismoApp.Pages
{
    public class TesteCapacidadeModel : PageModel
    {
        public string Mensagem { get; set; }

        public void OnGet()
        {
            var pacote = new PacoteTuristico
            {
                Titulo = "Pacote Serra Gaúcha",
                CapacidadeMaxima = 3
            };
       
            pacote.CapacityReached += OnCapacityReached;

            for (int i = 1; i <= 5; i++)
            {
                pacote.AdicionarReserva(new Reserva { Id = i });
            }

            Mensagem = $"Reservas feitas: {pacote.Reservas.Count}";
        }

        private void OnCapacityReached(object sender, EventArgs e)
        {
            Console.WriteLine("⚠️ Capacidade máxima do pacote atingida!");
        }
    }
}
