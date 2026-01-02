using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logica.Clases;
using Entidades.Clases;

namespace RestauranteWeb.Pages.Platos
{
    public class IndexModel : PageModel
    {
        private readonly PlatoLN _platoLN;

        public IndexModel()
        {
            _platoLN = new PlatoLN();
        }

        public List<Plato> Platos { get; set; } = new List<Plato>();

        [BindProperty(SupportsGet = true)]
        public string? Filtro { get; set; }

        public void OnGet()
        {
            try
            {
                Platos = _platoLN.ViewPlato(Filtro ?? "");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al cargar platos: " + ex.Message;
            }
        }
    }
}