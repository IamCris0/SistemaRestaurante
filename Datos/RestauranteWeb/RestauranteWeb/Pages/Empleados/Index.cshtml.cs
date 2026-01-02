using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logica.Clases;
using Entidades.Clases;

namespace RestauranteWeb.Pages.Empleados
{
    public class IndexModel : PageModel
    {
        private readonly EmpleadoLN _empleadoLN;

        public IndexModel()
        {
            _empleadoLN = new EmpleadoLN();
        }

        public List<Empleado> Empleados { get; set; } = new List<Empleado>();

        [BindProperty(SupportsGet = true)]
        public string? Filtro { get; set; }

        public void OnGet()
        {
            try
            {
                Empleados = _empleadoLN.ViewEmpleado(Filtro ?? "");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al cargar empleados: " + ex.Message;
            }
        }
    }
}