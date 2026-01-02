using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logica.Clases;
using Entidades.Clases;

namespace RestauranteWeb.Pages.Reservas
{
    public class DeleteModel : PageModel
    {
        private readonly ReservaLN _reservaLN;

        public DeleteModel()
        {
            _reservaLN = new ReservaLN();
        }

        [BindProperty]
        public Entidades.Clases.Reserva Reserva { get; set; } = new Entidades.Clases.Reserva();

        public IActionResult OnGet(int id)
        {
            try
            {
                var reservas = _reservaLN.ViewReserva("");
                var reserva = reservas.FirstOrDefault(r => r.Idreserva == id);

                if (reserva == null) return NotFound();

                Reserva = reserva;
                return Page();
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al cargar reserva: " + ex.Message;
                return RedirectToPage("./Index");
            }
        }

        public IActionResult OnPost()
        {
            try
            {
                _reservaLN.DeleteReserva(Reserva);
                TempData["Success"] = "Reserva eliminada exitosamente";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al eliminar reserva: " + ex.Message;
                return RedirectToPage("./Index");
            }
        }
    }
}