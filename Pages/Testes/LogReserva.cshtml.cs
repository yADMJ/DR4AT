using Microsoft.AspNetCore.Mvc.RazorPages;
using TurismoApp.Services;
using System;

namespace TurismoApp.Pages
{
    public class LogReservaModel : PageModel
    {
        public string Mensagem { get; set; }

        public void OnGet()
        {
            Action<string> logDelegate = null;

            logDelegate += LoggerService.LogToConsole;
            logDelegate += LoggerService.LogToFile;
            logDelegate += LoggerService.LogToMemory;

            string operacao = $"Reserva criada para cliente X em {DateTime.Now}";
            logDelegate(operacao);

            Mensagem = operacao;
        }
    }
}
