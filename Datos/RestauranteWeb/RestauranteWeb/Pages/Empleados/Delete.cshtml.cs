using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logica.Clases;
using Entidades.Clases;

namespace RestauranteWeb.Pages.Empleados
{
    public class DeleteModel : PageModel
    {
        private readonly EmpleadoLN _empleadoLN;

        public DeleteModel()
        {
            _empleadoLN = new EmpleadoLN();
        }

        [BindProperty]
        public Empleado Empleado { get; set; } = new Empleado();

        public IActionResult OnGet(int id)
        {
            try
            {
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
            try
            {
                _empleadoLN.DeleteEmpleado(Empleado);
                TempData["Success"] = "Empleado eliminado exitosamente";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al eliminar empleado: " + ex.Message;
                return RedirectToPage("./Index");
            }
        }
    }
}