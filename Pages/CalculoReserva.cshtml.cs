using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace TurismoApp.Pages
{
    public class CalculoReservaModel : PageModel
    {
        [BindProperty]
        public int NumeroDiarias { get; set; }

        [BindProperty]
        public int ValorDiaria { get; set; }

        public decimal TotalReserva { get; set; }

        public bool ResultadoCalculado { get; set; }

        public void OnPost()
        {
            Func<int, int, decimal> calcularTotal =
                (diarias, valor) => diarias * valor;

            TotalReserva = calcularTotal(NumeroDiarias, ValorDiaria);
            ResultadoCalculado = true;
        }

        public void OnGet()
        {
            ResultadoCalculado = false;
        }
    }
}
