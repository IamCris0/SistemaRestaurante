using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logica.Clases;
using Entidades.Clases;

namespace RestauranteWeb.Pages.Platos
{
    public class DeleteModel : PageModel
    {
        private readonly PlatoLN _platoLN;

        public DeleteModel()
        {
            _platoLN = new PlatoLN();
        }

        [BindProperty]
        public Plato Plato { get; set; } = new Plato();

        public IActionResult OnGet(int id)
        {
            try
            {
                var platos = _platoLN.ViewPlato("");
                var plato = platos.FirstOrDefault(p => p.Idplato == id);

                if (plato == null)
                {
                    return NotFound();
                }

                Plato = plato;
                return Page();
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al cargar plato: " + ex.Message;
                return RedirectToPage("./Index");
            }
        }

        public IActionResult OnPost()
        {
            try
            {
                _platoLN.DeletePlato(Plato);
                TempData["Success"] = "Plato eliminado exitosamente";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al eliminar plato: " + ex.Message;
                return RedirectToPage("./Index");
            }
        }
    }
}