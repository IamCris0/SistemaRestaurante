using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logica.Clases;
using Entidades.Clases;

namespace RestauranteWeb.Pages.Ingredientes
{
    public class DeleteModel : PageModel
    {
        private readonly IngredienteLN _ingredienteLN;

        public DeleteModel()
        {
            _ingredienteLN = new IngredienteLN();
        }

        [BindProperty]
        public Ingrediente Ingrediente { get; set; } = new Ingrediente();

        public IActionResult OnGet(int id)
        {
            try
            {
                var ingredientes = _ingredienteLN.ViewIngrediente("");
                var ingrediente = ingredientes.FirstOrDefault(i => i.Idingrediente == id);

                if (ingrediente == null)
                {
                    return NotFound();
                }

                Ingrediente = ingrediente;
                return Page();
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al cargar ingrediente: " + ex.Message;
                return RedirectToPage("./Index");
            }
        }

        public IActionResult OnPost()
        {
            try
            {
                _ingredienteLN.DeleteIngrediente(Ingrediente);
                TempData["Success"] = "Ingrediente eliminado exitosamente";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al eliminar ingrediente: " + ex.Message;
                return RedirectToPage("./Index");
            }
        }
    }
}