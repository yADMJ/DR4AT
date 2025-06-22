using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TurismoApp.Models
{
    public class Reserva
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; } = false;

        public DateTime DataReserva { get; set; } = DateTime.Now;

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }

        [ValidateNever]
        public Cliente? Cliente { get; set; }

        [ForeignKey("PacoteTuristico")]
        public int PacoteTuristicoId { get; set; }

        [ValidateNever]
        public PacoteTuristico? PacoteTuristico { get; set; }
    }
}
