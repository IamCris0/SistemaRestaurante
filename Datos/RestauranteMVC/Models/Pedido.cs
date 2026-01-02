using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteMVC.Models
{
    [Table("Pedido")]
    public class Pedido
    {
        [Key]
        [Display(Name = "ID Pedido")]
        public int IdPedido { get; set; }

        [Required]
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Total")]
        public decimal Total { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Estado")]
        public string Estado { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Cliente")]
        public int IdCliente { get; set; }

        [Required]
        [Display(Name = "Empleado")]
        public int IdEmpleado { get; set; }

        // Relaciones
        [ForeignKey("IdCliente")]
        public virtual Cliente? Cliente { get; set; }

        [ForeignKey("IdEmpleado")]
        public virtual Empleado? Empleado { get; set; }
        
        public virtual ICollection<PedidoPlato>? PedidoPlatos { get; set; }
    }
}
