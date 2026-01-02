using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logica.Clases;
using Entidades.Clases;

namespace RestauranteWeb.Pages.Categorias
{
    public class IndexModel : PageModel
    {
        private readonly CategoriaLN _categoriaLN;

        public IndexModel()
        {
            _categoriaLN = new CategoriaLN();
        }

        public List<Categoria> Categorias { get; set; } = new List<Categoria>();

        [BindProperty(SupportsGet = true)]
        public string? Filtro { get; set; }

        public void OnGet()
        {
            try
            {
                Categorias = _categoriaLN.ViewCategoria(Filtro ?? "");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al cargar categorías: " + ex.Message;
            }
        }
    }
}