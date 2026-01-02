using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logica.Clases;
using Entidades.Clases;

namespace RestauranteWeb.Pages.Mesas
{
    public class IndexModel : PageModel
    {
        private readonly MesaLN _mesaLN;

        public IndexModel()
        {
            _mesaLN = new MesaLN();
        }

        public List<Mesa> Mesas { get; set; } = new List<Mesa>();

        [BindProperty(SupportsGet = true)]
        public string? Filtro { get; set; }

        public void OnGet()
        {
            try
            {
                Mesas = _mesaLN.ViewMesa(Filtro ?? "");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al cargar mesas: " + ex.Message;
            }
        }
    }
}
