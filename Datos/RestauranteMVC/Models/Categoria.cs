using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteMVC.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        [Display(Name = "ID Categoría")]
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(150)]
        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }

        // Relación con Platos
        public virtual ICollection<Plato>? Platos { get; set; }
    }
}
