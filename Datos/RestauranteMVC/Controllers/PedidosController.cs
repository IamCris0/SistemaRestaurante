using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestauranteMVC.Models;

namespace RestauranteMVC.Controllers
{
    public class PedidosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PedidosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pedidos
        public async Task<IActionResult> Index()
        {
            var pedidos = await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Empleado)
                .Include(p => p.PedidoPlatos)
                    .ThenInclude(pp => pp.Plato)
                .OrderByDescending(p => p.Fecha)
                .ToListAsync();
            return View(pedidos);
        }

        // GET: Pedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Empleado)
                .Include(p => p.PedidoPlatos)
                    .ThenInclude(pp => pp.Plato)
                .FirstOrDefaultAsync(m => m.IdPedido == id);

            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedidos/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes.Select(c => new
            {
                c.IdCliente,
                NombreCompleto = c.Nombres + " " + c.Apellidos
            }), "IdCliente", "NombreCompleto");

            ViewData["IdEmpleado"] = new SelectList(_context.Empleados.Select(e => new
            {
                e.IdEmpleado,
                NombreCompleto = e.Nombres + " " + e.Apellidos
            }), "IdEmpleado", "NombreCompleto");

            ViewData["Platos"] = _context.Platos.Include(p => p.Categoria).ToList();

            return View();
        }

        // POST: Pedidos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPedido,Fecha,Total,Estado,IdCliente,IdEmpleado")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Pedido creado exitosamente";
                return RedirectToAction(nameof(Index));
            }

            ViewData["IdCliente"] = new SelectList(_context.Clientes.Select(c => new
            {
                c.IdCliente,
                NombreCompleto = c.Nombres + " " + c.Apellidos
            }), "IdCliente", "NombreCompleto", pedido.IdCliente);

            ViewData["IdEmpleado"] = new SelectList(_context.Empleados.Select(e => new
            {
                e.IdEmpleado,
                NombreCompleto = e.Nombres + " " + e.Apellidos
            }), "IdEmpleado", "NombreCompleto", pedido.IdEmpleado);

            return View(pedido);
        }

        // GET: Pedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }

            ViewData["IdCliente"] = new SelectList(_context.Clientes.Select(c => new
            {
                c.IdCliente,
                NombreCompleto = c.Nombres + " " + c.Apellidos
            }), "IdCliente", "NombreCompleto", pedido.IdCliente);

            ViewData["IdEmpleado"] = new SelectList(_context.Empleados.Select(e => new
            {
                e.IdEmpleado,
                NombreCompleto = e.Nombres + " " + e.Apellidos
            }), "IdEmpleado", "NombreCompleto", pedido.IdEmpleado);

            return View(pedido);
        }

        // POST: Pedidos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPedido,Fecha,Total,Estado,IdCliente,IdEmpleado")] Pedido pedido)
        {
            if (id != pedido.IdPedido)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Pedido actualizado exitosamente";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.IdPedido))
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
            }), "IdCliente", "NombreCompleto", pedido.IdCliente);

            ViewData["IdEmpleado"] = new SelectList(_context.Empleados.Select(e => new
            {
                e.IdEmpleado,
                NombreCompleto = e.Nombres + " " + e.Apellidos
            }), "IdEmpleado", "NombreCompleto", pedido.IdEmpleado);

            return View(pedido);
        }

        // GET: Pedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Empleado)
                .Include(p => p.PedidoPlatos)
                    .ThenInclude(pp => pp.Plato)
                .FirstOrDefaultAsync(m => m.IdPedido == id);

            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido != null)
            {
                // Eliminar primero los detalles del pedido
                var pedidoPlatos = await _context.PedidoPlatos
                    .Where(pp => pp.IdPedido == id)
                    .ToListAsync();

                _context.PedidoPlatos.RemoveRange(pedidoPlatos);
                _context.Pedidos.Remove(pedido);

                await _context.SaveChangesAsync();
                TempData["Success"] = "Pedido eliminado exitosamente";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.IdPedido == id);
        }
    }
}