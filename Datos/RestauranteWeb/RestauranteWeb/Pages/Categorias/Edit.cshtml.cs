using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Logica.Clases;
using Entidades.Clases;

namespace RestauranteWeb.Pages.Categorias
{
    public class EditModel : PageModel
    {
        private readonly CategoriaLN _categoriaLN;

        public EditModel()
        {
            _categoriaLN = new CategoriaLN();
        }

        [BindProperty]
        public Categoria Categoria { get; set; } = new Categoria();

        public IActionResult OnGet(int id)
        {
            try
            {
                var categorias = _categoriaLN.ViewCategoria("");
                var categoria = categorias.FirstOrDefault(c => c.Idcategoria == id);

                if (categoria == null)
                {
                    return NotFound();
                }

                Categoria = categoria;
                return Page();
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al cargar categoría: " + ex.Message;
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
                _categoriaLN.UpdateCategoria(Categoria);
                TempData["Success"] = "Categoría actualizada exitosamente";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error al actualizar categoría: " + ex.Message;
                return Page();
            }
        }
    }
}