using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestauranteMVC.Models;

namespace RestauranteMVC.Controllers
{
    public class ReservasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reservas
        public async Task<IActionResult> Index()
        {
            var reservas = await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Mesa)
                .Include(r => r.Plato)
                .OrderByDescending(r => r.FechaHora)
                .ToListAsync();
            return View(reservas);
        }

        // GET: Reservas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Mesa)
                .Include(r => r.Plato)
                .FirstOrDefaultAsync(m => m.IdReserva == id);

            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // GET: Reservas/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes.Select(c => new
            {
                c.IdCliente,
                NombreCompleto = c.Nombres + " " + c.Apellidos
            }), "IdCliente", "NombreCompleto");

            ViewData["IdMesa"] = new SelectList(_context.Mesas.Select(m => new
            {
                m.IdMesa,
                Info = "Mesa " + m.Numero + " - Capacidad: " + m.Capacidad
            }), "IdMesa", "Info");

            ViewData["IdPlato"] = new SelectList(_context.Platos, "IdPlato", "Nombre");

            return View();
        }

        // POST: Reservas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReserva,FechaHora,IdCliente,IdMesa,IdPlato")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Reserva creada exitosamente";
                return RedirectToAction(nameof(Index));
            }

            ViewData["IdCliente"] = new SelectList(_context.Clientes.Select(c => new
            {
                c.IdCliente,
                NombreCompleto = c.Nombres + " " + c.Apellidos
            }), "IdCliente", "NombreCompleto", reserva.IdCliente);

            ViewData["IdMesa"] = new SelectList(_context.Mesas.Select(m => new
            {
                m.IdMesa,
                Info = "Mesa " + m.Numero + " - Capacidad: " + m.Capacidad
            }), "IdMesa", "Info", reserva.IdMesa);

            ViewData["IdPlato"] = new SelectList(_context.Platos, "IdPlato", "Nombre", reserva.IdPlato);

            return View(reserva);
        }

        // GET: Reservas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }

            ViewData["IdCliente"] = new SelectList(_context.Clientes.Select(c => new
            {
                c.IdCliente,
                NombreCompleto = c.Nombres + " " + c.Apellidos
            }), "IdCliente", "NombreCompleto", reserva.IdCliente);

            ViewData["IdMesa"] = new SelectList(_context.Mesas.Select(m => new
            {
                m.IdMesa,
                Info = "Mesa " + m.Numero + " - Capacidad: " + m.Capacidad
            }), "IdMesa", "Info", reserva.IdMesa);

            ViewData["IdPlato"] = new SelectList(_context.Platos, "IdPlato", "Nombre", reserva.IdPlato);

            return View(reserva);
        }

        // POST: Reservas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReserva,FechaHora,IdCliente,IdMesa,IdPlato")] Reserva reserva)
        {
            if (id != reserva.IdReserva)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Reserva actualizada exitosamente";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.IdReserva))
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

            ViewData["IdCliente"] = new SelectList(_context.Clientes.Select(c => new
            {
                c.IdCliente,
                NombreCompleto = c.Nombres + " " + c.Apellidos
            }), "IdCliente", "NombreCompleto", reserva.IdCliente);

            ViewData["IdMesa"] = new SelectList(_context.Mesas.Select(m => new
            {
                m.IdMesa,
                Info = "Mesa " + m.Numero + " - Capacidad: " + m.Capacidad
            }), "IdMesa", "Info", reserva.IdMesa);

            ViewData["IdPlato"] = new SelectList(_context.Platos, "IdPlato", "Nombre", reserva.IdPlato);

            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Mesa)
                .Include(r => r.Plato)
                .FirstOrDefaultAsync(m => m.IdReserva == id);

            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Reserva eliminada exitosamente";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return _context.Reservas.Any(e => e.IdReserva == id);
        }
    }
}