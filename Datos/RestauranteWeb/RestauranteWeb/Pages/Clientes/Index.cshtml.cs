using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logica.Clases;
using Entidades.Clases;

namespace RestauranteWeb.Pages.Clientes
{
    public class IndexModel : PageModel
    {
        private readonly ClienteLN _clienteLN;

        public IndexModel()
        {
            _clienteLN = new ClienteLN();
        }

        public List<Cliente> Clientes { get; set; } = new List<Cliente>();

        [BindProperty(SupportsGet = true)]
        public string? Filtro { get; set; }

        public void OnGet()
        {
            try
            {
                Clientes = _clienteLN.ViewCliente(Filtro ?? "");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al cargar clientes: " + ex.Message;
            }
        }
    }
}