using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteMVC.Models
{
    [Table("PedidoPlato")]
    public class PedidoPlato
    {
        [Key]
        public int IdPedidoPlato { get; set; }

        [Required]
        public int IdPedido { get; set; }

        [Required]
        public int IdPlato { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Subtotal { get; set; }

        // Relaciones
        [ForeignKey("IdPedido")]
        public virtual Pedido? Pedido { get; set; }

        [ForeignKey("IdPlato")]
        public virtual Plato? Plato { get; set; }
    }
}
