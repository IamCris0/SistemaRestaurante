using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logica.Clases;
using Entidades.Clases;

namespace RestauranteWeb.Pages.Categorias
{
    public class CreateModel : PageModel
    {
        private readonly CategoriaLN _categoriaLN;

        public CreateModel()
        {
            _categoriaLN = new CategoriaLN();
        }

        [BindProperty]
        public Categoria Categoria { get; set; } = new Categoria();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _categoriaLN.CreateCategoria(Categoria);
                TempData["Success"] = "Categoría creada exitosamente";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al crear categoría: " + ex.Message;
                return Page();
            }
        }
    }
}