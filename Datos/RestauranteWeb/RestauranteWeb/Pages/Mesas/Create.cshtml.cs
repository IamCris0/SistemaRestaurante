using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logica.Clases;
using Entidades.Clases;

namespace RestauranteWeb.Pages.Mesas
{
    public class CreateModel : PageModel
    {
        private readonly MesaLN _mesaLN;

        public CreateModel()
        {
            _mesaLN = new MesaLN();
        }

        [BindProperty]
        public Mesa Mesa { get; set; } = new Mesa();

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
                _mesaLN.CreateMesa(Mesa);
                TempData["Success"] = "Mesa creada exitosamente";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al crear mesa: " + ex.Message;
                return Page();
            }
        }
    }
}