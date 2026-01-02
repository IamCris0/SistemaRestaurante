using Entidades.Clases;
using Logica.Clases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RestauranteWeb.Pages.Cargos
{
    public class IndexModel : PageModel
    {
        private readonly CargoLN _cargoLN;

        public IndexModel()
        {
            _cargoLN = new CargoLN();
        }

        public List<Cargo> Cargos { get; set; } = new List<Cargo>();

        [BindProperty(SupportsGet = true)]
        public string? Filtro { get; set; }

        public void OnGet()
        {
            try
            {
                Cargos = _cargoLN.ViewCargo(Filtro ?? "");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al cargar cargos: " + ex.Message;
            }
        }
    }
}
