using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logica.Clases;
using Entidades.Clases;

namespace RestauranteWeb.Pages.Ingredientes
{
    public class IndexModel : PageModel
    {
        private readonly IngredienteLN _ingredienteLN;

        public IndexModel()
        {
            _ingredienteLN = new IngredienteLN();
        }

        public List<Ingrediente> Ingredientes { get; set; } = new List<Ingrediente>();

        [BindProperty(SupportsGet = true)]
        public string? Filtro { get; set; }

        public void OnGet()
        {
            try
            {
                Ingredientes = _ingredienteLN.ViewIngrediente(Filtro ?? "");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al cargar ingredientes: " + ex.Message;
            }
        }
    }
}
