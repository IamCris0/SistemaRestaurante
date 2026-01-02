using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logica.Clases;
using Entidades.Clases;

namespace RestauranteWeb.Pages.Cargos
{
    public class EditModel : PageModel
    {
        private readonly CargoLN _cargoLN;

        public EditModel()
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _cargoLN.UpdateCargo(Cargo);
                TempData["Success"] = "Cargo actualizado exitosamente";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al actualizar cargo: " + ex.Message;
                return Page();
            }
        }
    }
}