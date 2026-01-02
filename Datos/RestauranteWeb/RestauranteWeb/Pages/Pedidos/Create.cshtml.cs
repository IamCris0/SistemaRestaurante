using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logica.Clases;
using Entidades.Clases;

namespace RestauranteWeb.Pages.Pedidos
{
    public class CreateModel : PageModel
    {
        private readonly PedidoLN _pedidoLN;
        private readonly ClienteLN _clienteLN;
        private readonly EmpleadoLN _empleadoLN;

        public CreateModel()
        {
            _pedidoLN = new PedidoLN();
            _clienteLN = new ClienteLN();
            _empleadoLN = new EmpleadoLN();
        }

        [BindProperty]
        public Pedido Pedido { get; set; } = new Pedido();

        public List<Cliente> Clientes { get; set; } = new List<Cliente>();
        public List<Empleado> Empleados { get; set; } = new List<Empleado>();

        public void OnGet()
        {
            try
            {
                Clientes = _clienteLN.ViewCliente("");
                Empleados = _empleadoLN.ViewEmpleado("");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al cargar datos: " + ex.Message;
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
                _pedidoLN.CreatePedido(Pedido);
                TempData["Success"] = "Pedido creado exitosamente";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al crear pedido: " + ex.Message;
                Clientes = _clienteLN.ViewCliente("");
                Empleados = _empleadoLN.ViewEmpleado("");
                return Page();
            }
        }
    }
}
