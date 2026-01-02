using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestauranteMVC.Models;

namespace RestauranteMVC.Controllers
{
    public class PlatosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlatosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Platos
        public async Task<IActionResult> Index()
        {
            var platos = await _context.Platos
                .Include(p => p.Categoria)
                .ToListAsync();
            return View(platos);
        }

        // GET: Platos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plato = await _context.Platos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(m => m.IdPlato == id);

            if (plato == null)
            {
                return NotFound();
            }

            return View(plato);
        }

        // GET: Platos/Create
        public IActionResult Create()
        {
            ViewData["IdCategoria"] = new SelectList(_context.Categorias, "IdCategoria", "Nombre");
            return View();
        }

        // POST: Platos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPlato,Nombre,Descripcion,Precio,Stock,IdCategoria")] Plato plato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plato);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Plato creado exitosamente";
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategoria"] = new SelectList(_context.Categorias, "IdCategoria", "Nombre", plato.IdCategoria);
            return View(plato);
        }

        // GET: Platos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plato = await _context.Platos.FindAsync(id);
            if (plato == null)
            {
                return NotFound();
            }
            ViewData["IdCategoria"] = new SelectList(_context.Categorias, "IdCategoria", "Nombre", plato.IdCategoria);
            return View(plato);
        }

        // POST: Platos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPlato,Nombre,Descripcion,Precio,Stock,IdCategoria")] Plato plato)
        {
            if (id != plato.IdPlato)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plato);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Plato actualizado exitosamente";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlatoExists(plato.IdPlato))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategoria"] = new SelectList(_context.Categorias, "IdCategoria", "Nombre", plato.IdCategoria);
            return View(plato);
        }

        // GET: Platos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plato = await _context.Platos
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(m => m.IdPlato == id);

            if (plato == null)
            {
                return NotFound();
            }

            return View(plato);
        }

        // POST: Platos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plato = await _context.Platos.FindAsync(id);
            if (plato != null)
            {
                var tienePedidos = await _context.PedidoPlatos.AnyAsync(pp => pp.IdPlato == id);
                var tieneReservas = await _context.Reservas.AnyAsync(r => r.IdPlato == id);

                if (tienePedidos || tieneReservas)
                {
                    TempData["Error"] = "No se puede eliminar el plato porque tiene pedidos o reservas asociadas";
                    return RedirectToAction(nameof(Index));
                }

                _context.Platos.Remove(plato);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Plato eliminado exitosamente";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool PlatoExists(int id)
        {
            return _context.Platos.Any(e => e.IdPlato == id);
        }
    }
}