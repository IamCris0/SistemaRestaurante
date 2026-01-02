using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logica.Clases;
using Entidades.Clases;

namespace RestauranteWeb.Pages.Reservas
{
    public class CreateModel : PageModel
    {
        private readonly ReservaLN _reservaLN;
        private readonly ClienteLN _clienteLN;
        private readonly MesaLN _mesaLN;
        private readonly PlatoLN _platoLN;

        public CreateModel()
        {
            _reservaLN = new ReservaLN();
            _clienteLN = new ClienteLN();
            _mesaLN = new MesaLN();
            _platoLN = new PlatoLN();
        }

        [BindProperty]
        public Entidades.Clases.Reserva Reserva { get; set; } = new Entidades.Clases.Reserva();

        public List<Cliente> Clientes { get; set; } = new List<Cliente>();
        public List<Mesa> Mesas { get; set; } = new List<Mesa>();
        public List<Plato> Platos { get; set; } = new List<Plato>();

        public void OnGet()
        {
            try
            {
                Clientes = _clienteLN.ViewCliente("");
                Mesas = _mesaLN.ViewMesa("");
                Platos = _platoLN.ViewPlato("");
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
                Mesas = _mesaLN.ViewMesa("");
                Platos = _platoLN.ViewPlato("");
                return Page();
            }

            try
            {
                _reservaLN.CreateReserva(Reserva);
                TempData["Success"] = "Reserva creada exitosamente";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al crear reserva: " + ex.Message;
                Clientes = _clienteLN.ViewCliente("");
                Mesas = _mesaLN.ViewMesa("");
                Platos = _platoLN.ViewPlato("");
                return Page();
            }
        }
    }
}
