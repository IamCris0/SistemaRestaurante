using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteMVC.Models
{
    [Table("Reserva")]
    public class Reserva
    {
        [Key]
        [Display(Name = "ID Reserva")]
        public int IdReserva { get; set; }

        [Required]
        [Display(Name = "Fecha y Hora")]
        public DateTime FechaHora { get; set; }

        [Required]
        [Display(Name = "Cliente")]
        public int IdCliente { get; set; }

        [Required]
        [Display(Name = "Mesa")]
        public int IdMesa { get; set; }

        [Required]
        [Display(Name = "Plato")]
        public int IdPlato { get; set; }

        // Relaciones
        [ForeignKey("IdCliente")]
        public virtual Cliente? Cliente { get; set; }

        [ForeignKey("IdMesa")]
        public virtual Mesa? Mesa { get; set; }

        [ForeignKey("IdPlato")]
        public virtual Plato? Plato { get; set; }
    }
}
