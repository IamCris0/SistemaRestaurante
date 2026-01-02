using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteMVC.Models
{
    [Table("Mesa")]
    public class Mesa
    {
        [Key]
        [Display(Name = "ID Mesa")]
        public int IdMesa { get; set; }

        [Required]
        [Display(Name = "Número")]
        public int Numero { get; set; }

        [Required]
        [Display(Name = "Capacidad")]
        public int Capacidad { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Estado")]
        public string Estado { get; set; } = string.Empty;

        // Relaciones
        public virtual ICollection<Reserva>? Reservas { get; set; }
    }
}
