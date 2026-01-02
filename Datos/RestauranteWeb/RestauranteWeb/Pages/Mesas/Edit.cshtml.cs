using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logica.Clases;
using Entidades.Clases;

namespace RestauranteWeb.Pages.Mesas
{
    public class EditModel : PageModel
    {
        private readonly MesaLN _mesaLN;

        public EditModel()
        {
            _mesaLN = new MesaLN();
        }

        [BindProperty]
        public Mesa Mesa { get; set; } = new Mesa();

        public IActionResult OnGet(int id)
        {
            try
            {
                var mesas = _mesaLN.ViewMesa("");
                var mesa = mesas.FirstOrDefault(m => m.Idmesa == id);

                if (mesa == null)
                {
                    return NotFound();
                }

                Mesa = mesa;
                return Page();
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al cargar mesa: " + ex.Message;
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
                _mesaLN.UpdateMesa(Mesa);
                TempData["Success"] = "Mesa actualizada exitosamente";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al actualizar mesa: " + ex.Message;
                return Page();
            }
        }
    }
}