using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestauranteMVC.Models;

namespace RestauranteMVC.Controllers
{
    public class CargosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CargosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cargos
        public async Task<IActionResult> Index()
        {
            var cargos = await _context.Cargos
                .Include(c => c.Empleados)
                .ToListAsync();
            return View(cargos);
        }

        // GET: Cargos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargo = await _context.Cargos
                .Include(c => c.Empleados)
                .FirstOrDefaultAsync(m => m.IdCargo == id);

            if (cargo == null)
            {
                return NotFound();
            }

            return View(cargo);
        }

        // GET: Cargos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cargos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCargo,Nombre,Descripcion")] Cargo cargo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cargo);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Cargo creado exitosamente";
                return RedirectToAction(nameof(Index));
            }
            return View(cargo);
        }

        // GET: Cargos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargo = await _context.Cargos.FindAsync(id);
            if (cargo == null)
            {
                return NotFound();
            }
            return View(cargo);
        }

        // POST: Cargos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCargo,Nombre,Descripcion")] Cargo cargo)
        {
            if (id != cargo.IdCargo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cargo);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Cargo actualizado exitosamente";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CargoExists(cargo.IdCargo))
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
            return View(cargo);
        }

        // GET: Cargos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargo = await _context.Cargos
                .Include(c => c.Empleados)
                .FirstOrDefaultAsync(m => m.IdCargo == id);

            if (cargo == null)
            {
                return NotFound();
            }

            return View(cargo);
        }

        // POST: Cargos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cargo = await _context.Cargos.FindAsync(id);
            if (cargo != null)
            {
                // Verificar si tiene empleados asociados
                var tieneEmpleados = await _context.Empleados.AnyAsync(e => e.IdCargo == id);
                if (tieneEmpleados)
                {
                    TempData["Error"] = "No se puede eliminar el cargo porque tiene empleados asociados";
                    return RedirectToAction(nameof(Index));
                }

                _context.Cargos.Remove(cargo);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Cargo eliminado exitosamente";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CargoExists(int id)
        {
            return _context.Cargos.Any(e => e.IdCargo == id);
        }
    }
}
