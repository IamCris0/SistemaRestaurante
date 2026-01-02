using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logica.Clases;
using Entidades.Clases;

namespace RestauranteWeb.Pages.Pedidos
{
    public class DeleteModel : PageModel
    {
        private readonly PedidoLN _pedidoLN;

        public DeleteModel()
        {
            _pedidoLN = new PedidoLN();
        }

        [BindProperty]
        public Pedido Pedido { get; set; } = new Pedido();

        public IActionResult OnGet(int id)
        {
            try
            {
                var pedidos = _pedidoLN.ViewPedido("");
                var pedido = pedidos.FirstOrDefault(p => p.Idpedido == id);

                if (pedido == null) return NotFound();

                Pedido = pedido;
                return Page();
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al cargar pedido: " + ex.Message;
                return RedirectToPage("./Index");
            }
        }

        public IActionResult OnPost()
        {
            try
            {
                _pedidoLN.DeletePedido(Pedido);
                TempData["Success"] = "Pedido eliminado exitosamente";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al eliminar pedido: " + ex.Message;
                return RedirectToPage("./Index");
            }
        }
    }
}