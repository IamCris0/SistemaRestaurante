using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteMVC.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        [Display(Name = "ID Cliente")]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "La cédula es requerida")]
        [StringLength(10)]
        [Display(Name = "Cédula")]
        public string Cedula { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50)]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es requerido")]
        [StringLength(50)]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; } = string.Empty;

        [StringLength(15)]
        [Display(Name = "Teléfono")]
        public string? Telefono { get; set; }

        [StringLength(150)]
        [Display(Name = "Dirección")]
        public string? Direccion { get; set; }

        [StringLength(100)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        // Relaciones
        public virtual ICollection<Pedido>? Pedidos { get; set; }
        public virtual ICollection<Reserva>? Reservas { get; set; }
    }
}
