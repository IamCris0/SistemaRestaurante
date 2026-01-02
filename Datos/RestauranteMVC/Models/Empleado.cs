using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteMVC.Models
{
    [Table("Empleado")]
    public class Empleado
    {
        [Key]
        [Display(Name = "ID Empleado")]
        public int IdEmpleado { get; set; }

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

        [StringLength(100)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Salario")]
        public decimal Salario { get; set; }

        [Required]
        [Display(Name = "Cargo")]
        public int IdCargo { get; set; }

        // Relaciones
        [ForeignKey("IdCargo")]
        public virtual Cargo? Cargo { get; set; }
        
        public virtual ICollection<Pedido>? Pedidos { get; set; }
    }
}
