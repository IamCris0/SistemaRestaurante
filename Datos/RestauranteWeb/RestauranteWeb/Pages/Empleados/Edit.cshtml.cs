using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logica.Clases;
using Entidades.Clases;

namespace RestauranteWeb.Pages.Empleados
{
    public class EditModel : PageModel
    {
        private readonly EmpleadoLN _empleadoLN;
        private readonly CargoLN _cargoLN;

        public EditModel()
        {
            _empleadoLN = new EmpleadoLN();
            _cargoLN = new CargoLN();
        }

        [BindProperty]
        public Empleado Empleado { get; set; } = new Empleado();

        public List<Cargo> Cargos { get; set; } = new List<Cargo>();

        public IActionResult OnGet(int id)
        {
            try
            {
                Cargos = _cargoLN.ViewCargo("");
                var empleados = _empleadoLN.ViewEmpleado("");
                var empleado = empleados.FirstOrDefault(e => e.Idempleado == id);

                if (empleado == null)
                {
                    return NotFound();
                }

                Empleado = empleado;
                return Page();
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al cargar empleado: " + ex.Message;
                return RedirectToPage("./Index");
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
                _empleadoLN.UpdateEmpleado(Empleado);
                TempData["Success"] = "Empleado actualizado exitosamente";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al actualizar empleado: " + ex.Message;
                Cargos = _cargoLN.ViewCargo("");
                return Page();
            }
        }
    }
}