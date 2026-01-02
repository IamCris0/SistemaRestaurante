using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteMVC.Models
{
    [Table("Plato")]
    public class Plato
    {
        [Key]
        [Display(Name = "ID Plato")]
        public int IdPlato { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(150)]
        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Precio")]
        [Range(0.01, 10000, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal Precio { get; set; }

        [Required]
        [Display(Name = "Stock")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
        public int Stock { get; set; }

        [Required]
        [Display(Name = "Categoría")]
        public int IdCategoria { get; set; }

        // Relaciones
        [ForeignKey("IdCategoria")]
        public virtual Categoria? Categoria { get; set; }
        
        public virtual ICollection<PedidoPlato>? PedidoPlatos { get; set; }
        public virtual ICollection<Reserva>? Reservas { get; set; }
    }
}
