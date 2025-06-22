using System.ComponentModel.DataAnnotations;

namespace TurismoApp.Models
{
    public class CidadeDestino
    {
        public int Id { get; set; }

        [Required, MinLength(3)]
        public string Nome { get; set; }

        public ICollection<PacoteTuristico> Pacotes { get; set; } = new List<PacoteTuristico>();
    }
}
