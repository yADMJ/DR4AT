
using System;
using System.Collections.Generic;

namespace TurismoApp.Models
{
    public class PacoteTuristico
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime DataInicio { get; set; }
        public int CapacidadeMaxima { get; set; }
        public decimal Preco { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<Reserva> Reservas { get; set; } = new List<Reserva>();


        public ICollection<CidadeDestino> Destinos { get; set; } = new List<CidadeDestino>();


        public event EventHandler CapacityReached;

        public void AdicionarReserva(Reserva reserva)
        {
            if (Reservas.Count >= CapacidadeMaxima)
            {
                CapacityReached?.Invoke(this, EventArgs.Empty);
                return;
            }

            Reservas.Add(reserva);
        }
    }

}