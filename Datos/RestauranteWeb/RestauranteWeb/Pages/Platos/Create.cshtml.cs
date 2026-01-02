using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logica.Clases;
using Entidades.Clases;

namespace RestauranteWeb.Pages.Platos
{
    public class CreateModel : PageModel
    {
        private readonly PlatoLN _platoLN;
        private readonly CategoriaLN _categoriaLN;

        public CreateModel()
        {
            _platoLN = new PlatoLN();
            _categoriaLN = new CategoriaLN();
        }

        [BindProperty]
        public Plato Plato { get; set; } = new Plato();

        public List<Categoria> Categorias { get; set; } = new List<Categoria>();

        public void OnGet()
        {
            try
            {
                Categorias = _categoriaLN.ViewCategoria("");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al cargar categorías: " + ex.Message;
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Categorias = _categoriaLN.ViewCategoria("");
                return Page();
            }

            try
            {
                _platoLN.CreatePlato(Plato);
                TempData["Success"] = "Plato creado exitosamente";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al crear plato: " + ex.Message;
                Categorias = _categoriaLN.ViewCategoria("");
                return Page();
            }
        }
    }
}
