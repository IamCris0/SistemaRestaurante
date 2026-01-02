using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logica.Clases;
using Entidades.Clases;

namespace RestauranteWeb.Pages.Reservas
{
    public class IndexModel : PageModel
    {
        private readonly ReservaLN _reservaLN;

        public IndexModel()
        {
            _reservaLN = new ReservaLN();
        }

        public List<Entidades.Clases.Reserva> Reservas { get; set; } = new List<Entidades.Clases.Reserva>();

        [BindProperty(SupportsGet = true)]
        public string? Filtro { get; set; }

        public void OnGet()
        {
            try
            {
                Reservas = _reservaLN.ViewReserva(Filtro ?? "");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al cargar reservas: " + ex.Message;
            }
        }
    }
}