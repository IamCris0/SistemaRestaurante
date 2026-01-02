using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logica.Clases;
using Entidades.Clases;

namespace RestauranteWeb.Pages.Pedidos
{
    public class IndexModel : PageModel
    {
        private readonly PedidoLN _pedidoLN;

        public IndexModel()
        {
            _pedidoLN = new PedidoLN();
        }

        public List<Pedido> Pedidos { get; set; } = new List<Pedido>();

        [BindProperty(SupportsGet = true)]
        public string? Filtro { get; set; }

        public void OnGet()
        {
            try
            {
                Pedidos = _pedidoLN.ViewPedido(Filtro ?? "");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al cargar pedidos: " + ex.Message;
            }
        }
    }
}