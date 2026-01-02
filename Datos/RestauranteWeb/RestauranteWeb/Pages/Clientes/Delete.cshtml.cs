using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logica.Clases;
using Entidades.Clases;

namespace RestauranteWeb.Pages.Clientes
{
    public class DeleteModel : PageModel
    {
        private readonly ClienteLN _clienteLN;

        public DeleteModel()
        {
            _clienteLN = new ClienteLN();
        }

        [BindProperty]
        public Cliente Cliente { get; set; } = new Cliente();

        public IActionResult OnGet(int id)
        {
            try
            {
                var clientes = _clienteLN.ViewCliente("");
                var cliente = clientes.FirstOrDefault(c => c.Idcliente == id);

                if (cliente == null)
                {
                    return NotFound();
                }

                Cliente = cliente;
                return Page();
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al cargar cliente: " + ex.Message;
                return RedirectToPage("./Index");
            }
        }

        public IActionResult OnPost()
        {
            try
            {
                _clienteLN.DeleteCliente(Cliente);
                TempData["Success"] = "Cliente eliminado exitosamente";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al eliminar cliente: " + ex.Message;
                return RedirectToPage("./Index");
            }
        }
    }
}