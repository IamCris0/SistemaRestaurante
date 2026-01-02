using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logica.Clases;
using Entidades.Clases;

namespace RestauranteWeb.Pages.Reservas
{
    public class EditModel : PageModel
    {
        private readonly ReservaLN _reservaLN;
        private readonly ClienteLN _clienteLN;
        private readonly MesaLN _mesaLN;
        private readonly PlatoLN _platoLN;

        public EditModel()
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

        public IActionResult OnGet(int id)
        {
            try
            {
                Clientes = _clienteLN.ViewCliente("");
                Mesas = _mesaLN.ViewMesa("");
                Platos = _platoLN.ViewPlato("");

                var reservas = _reservaLN.ViewReserva("");
                var reserva = reservas.FirstOrDefault(r => r.Idreserva == id);

                if (reserva == null) return NotFound();

                Reserva = reserva;
                return Page();
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al cargar reserva: " + ex.Message;
                return RedirectToPage("./Index");
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
                _reservaLN.UpdateReserva(Reserva);
                TempData["Success"] = "Reserva actualizada exitosamente";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al actualizar reserva: " + ex.Message;
                Clientes = _clienteLN.ViewCliente("");
                Mesas = _mesaLN.ViewMesa("");
                Platos = _platoLN.ViewPlato("");
                return Page();
            }
        }
    }
}