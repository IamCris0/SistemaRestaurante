using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logica.Clases;
using Entidades.Clases;

namespace RestauranteWeb.Pages.Empleados
{
    public class CreateModel : PageModel
    {
        private readonly EmpleadoLN _empleadoLN;
        private readonly CargoLN _cargoLN;

        public CreateModel()
        {
            _empleadoLN = new EmpleadoLN();
            _cargoLN = new CargoLN();
        }

        [BindProperty]
        public Empleado Empleado { get; set; } = new Empleado();

        public List<Cargo> Cargos { get; set; } = new List<Cargo>();

        public void OnGet()
        {
            try
            {
                Cargos = _cargoLN.ViewCargo("");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al cargar cargos: " + ex.Message;
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cargos = _cargoLN.ViewCargo("");
                return Page();
            }

            try
            {
                _empleadoLN.CreateEmpleado(Empleado);
                TempData["Success"] = "Empleado creado exitosamente";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al crear empleado: " + ex.Message;
                Cargos = _cargoLN.ViewCargo("");
                return Page();
            }
        }
    }
}
