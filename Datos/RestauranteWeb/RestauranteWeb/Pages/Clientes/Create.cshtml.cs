using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logica.Clases;
using Entidades.Clases;

namespace RestauranteWeb.Pages.Clientes
{
    public class CreateModel : PageModel
    {
        private readonly ClienteLN _clienteLN;

        public CreateModel()
        {
            _clienteLN = new ClienteLN();
        }

        [BindProperty]
        public Cliente Cliente { get; set; } = new Cliente();

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
                _clienteLN.CreateCliente(Cliente);
                TempData["Success"] = "Cliente creado exitosamente";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al crear cliente: " + ex.Message;
                return Page();
            }
        }
    }
}