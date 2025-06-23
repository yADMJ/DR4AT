using System.ComponentModel.DataAnnotations;

namespace TurismoApp.Models
{
    public class Cliente
    {
        public int Id { get; set; }


        [Required, MinLength(3)]
        public string Nome { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
        public bool IsDeleted { get; set; } = false;
    }
}
