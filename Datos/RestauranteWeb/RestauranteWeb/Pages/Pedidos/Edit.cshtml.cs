using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logica.Clases;
using Entidades.Clases;

namespace RestauranteWeb.Pages.Pedidos
{
    public class EditModel : PageModel
    {
        private readonly PedidoLN _pedidoLN;
        private readonly ClienteLN _clienteLN;
        private readonly EmpleadoLN _empleadoLN;

        public EditModel()
        {
            _pedidoLN = new PedidoLN();
            _clienteLN = new ClienteLN();
            _empleadoLN = new EmpleadoLN();
        }

        [BindProperty]
        public Pedido Pedido { get; set; } = new Pedido();

        public List<Cliente> Clientes { get; set; } = new List<Cliente>();
        public List<Empleado> Empleados { get; set; } = new List<Empleado>();

        public IActionResult OnGet(int id)
        {
            try
            {
                Clientes = _clienteLN.ViewCliente("");
                Empleados = _empleadoLN.ViewEmpleado("");

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
            if (!ModelState.IsValid)
            {
                Clientes = _clienteLN.ViewCliente("");
                Empleados = _empleadoLN.ViewEmpleado("");
                return Page();
            }

            try
            {
                _pedidoLN.UpdatePedido(Pedido);
                TempData["Success"] = "Pedido actualizado exitosamente";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al actualizar pedido: " + ex.Message;
                Clientes = _clienteLN.ViewCliente("");
                Empleados = _empleadoLN.ViewEmpleado("");
                return Page();
            }
        }
    }
}
