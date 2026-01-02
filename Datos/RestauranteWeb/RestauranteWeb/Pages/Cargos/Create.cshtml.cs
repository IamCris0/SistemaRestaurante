using Entidades.Clases;
using Logica.Clases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RestauranteWeb.Pages.Cargos
{
    public class CreateModel : PageModel
    {
        private readonly CargoLN _cargoLN;

        public CreateModel()
        {
            _cargoLN = new CargoLN();
        }

        [BindProperty]
        public Cargo Cargo { get; set; } = new Cargo();

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
                _cargoLN.CreateCargo(Cargo);
                TempData["Success"] = "Cargo creado exitosamente";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al crear cargo: " + ex.Message;
                return Page();
            }
        }
    }
}
