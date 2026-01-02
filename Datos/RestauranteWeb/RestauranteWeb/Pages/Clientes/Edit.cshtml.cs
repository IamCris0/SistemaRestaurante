using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logica.Clases;
using Entidades.Clases;

namespace RestauranteWeb.Pages.Clientes
{
    public class EditModel : PageModel
    {
        private readonly ClienteLN _clienteLN;

        public EditModel()
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _clienteLN.UpdateCliente(Cliente);
                TempData["Success"] = "Cliente actualizado exitosamente";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al actualizar cliente: " + ex.Message;
                return Page();
            }
        }
    }
}