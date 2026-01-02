using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logica.Clases;
using Entidades.Clases;

namespace RestauranteWeb.Pages.Platos
{
    public class EditModel : PageModel
    {
        private readonly PlatoLN _platoLN;
        private readonly CategoriaLN _categoriaLN;

        public EditModel()
        {
            _platoLN = new PlatoLN();
            _categoriaLN = new CategoriaLN();
        }

        [BindProperty]
        public Plato Plato { get; set; } = new Plato();

        public List<Categoria> Categorias { get; set; } = new List<Categoria>();

        public IActionResult OnGet(int id)
        {
            try
            {
                Categorias = _categoriaLN.ViewCategoria("");
                var platos = _platoLN.ViewPlato("");
                var plato = platos.FirstOrDefault(p => p.Idplato == id);

                if (plato == null)
                {
                    return NotFound();
                }

                Plato = plato;
                return Page();
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al cargar plato: " + ex.Message;
                return RedirectToPage("./Index");
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Categorias = _categoriaLN.ViewCategoria("");
                return Page();
            }

            try
            {
                _platoLN.UpdatePlato(Plato);
                TempData["Success"] = "Plato actualizado exitosamente";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al actualizar plato: " + ex.Message;
                Categorias = _categoriaLN.ViewCategoria("");
                return Page();
            }
        }
    }
}