using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logica.Clases;
using Entidades.Clases;

namespace RestauranteWeb.Pages.Ingredientes
{
    public class CreateModel : PageModel
    {
        private readonly IngredienteLN _ingredienteLN;

        public CreateModel()
        {
            _ingredienteLN = new IngredienteLN();
        }

        [BindProperty]
        public Ingrediente Ingrediente { get; set; } = new Ingrediente();

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
                _ingredienteLN.CreateIngrediente(Ingrediente);
                TempData["Success"] = "Ingrediente creado exitosamente";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al crear ingrediente: " + ex.Message;
                return Page();
            }
        }
    }
}