using Entidades.Clases;
using Logica.Clases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RestauranteWeb.Pages.Cargos
{
    public class DeleteModel : PageModel
    {
        private readonly CargoLN _cargoLN;

        public DeleteModel()
        {
            _cargoLN = new CargoLN();
        }

        [BindProperty]
        public Cargo Cargo { get; set; } = new Cargo();

        public IActionResult OnGet(int id)
        {
            try
            {
                var cargos = _cargoLN.ViewCargo("");
                var cargo = cargos.FirstOrDefault(c => c.Idcargo == id);

                if (cargo == null)
                {
                    return NotFound();
                }

                Cargo = cargo;
                return Page();
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al cargar cargo: " + ex.Message;
                return RedirectToPage("./Index");
            }
        }

        public IActionResult OnPost()
        {
            try
            {
                _cargoLN.DeleteCargo(Cargo);
                TempData["Success"] = "Cargo eliminado exitosamente";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al eliminar cargo: " + ex.Message;
                return RedirectToPage("./Index");
            }
        }
    }
}
