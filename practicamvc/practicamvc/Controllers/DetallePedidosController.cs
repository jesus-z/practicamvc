using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using practicamvc.Data;
using practicamvc.Models;

namespace practicamvc.Controllers
{
    public class DetallePedidosController : Controller
    {
        private readonly practicamvcContext _context;

        public DetallePedidosController(practicamvcContext context)
        {
            _context = context;
        }

        // GET: DetallePedidoModels
        public async Task<IActionResult> Index()
        {
            var practicamvcContext = _context.DetallePedidoModel.Include(d => d.Pedido).Include(d => d.Producto);
            return View(await practicamvcContext.ToListAsync());
        }

        // GET: DetallePedidoModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallePedidoModel = await _context.DetallePedidoModel
                .Include(d => d.Pedido)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detallePedidoModel == null)
            {
                return NotFound();
            }

            return View(detallePedidoModel);
        }

        // GET: DetallePedidoModels/Create
        public IActionResult Create()
        {
            ViewData["PedidoId"] = new SelectList(_context.Set<Pedidos>(), "Id", "Estado");
            ViewData["ProductoId"] = new SelectList(_context.Set<Order>(), "Id", "Nombre");
            return View();
        }

        // POST: DetallePedidoModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PedidoId,ProductoId,Cantidad,PrecioUnitario")] DetallePedidos detallePedidoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detallePedidoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidoId"] = new SelectList(_context.Set<Pedidos>(), "Id", "Estado", detallePedidoModel.PedidoId);
            ViewData["ProductoId"] = new SelectList(_context.Set<Order>(), "Id", "Nombre", detallePedidoModel.ProductoId);
            return View(detallePedidoModel);
        }

        // GET: DetallePedidoModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallePedidoModel = await _context.DetallePedidoModel.FindAsync(id);
            if (detallePedidoModel == null)
            {
                return NotFound();
            }
            ViewData["PedidoId"] = new SelectList(_context.Set<Pedidos>(), "Id", "Estado", detallePedidoModel.PedidoId);
            ViewData["ProductoId"] = new SelectList(_context.Set<Order>(), "Id", "Nombre", detallePedidoModel.ProductoId);
            return View(detallePedidoModel);
        }

        // POST: DetallePedidoModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PedidoId,ProductoId,Cantidad,PrecioUnitario")] DetallePedidos detallePedidoModel)
        {
            if (id != detallePedidoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detallePedidoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetallePedidoModelExists(detallePedidoModel.Id))
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
            ViewData["PedidoId"] = new SelectList(_context.Set<Pedidos>(), "Id", "Estado", detallePedidoModel.PedidoId);
            ViewData["ProductoId"] = new SelectList(_context.Set<Order>(), "Id", "Nombre", detallePedidoModel.ProductoId);
            return View(detallePedidoModel);
        }

        // GET: DetallePedidoModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallePedidoModel = await _context.DetallePedidoModel
                .Include(d => d.Pedido)
                .Include(d => d.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detallePedidoModel == null)
            {
                return NotFound();
            }

            return View(detallePedidoModel);
        }

        // POST: DetallePedidoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detallePedidoModel = await _context.DetallePedidoModel.FindAsync(id);
            if (detallePedidoModel != null)
            {
                _context.DetallePedidoModel.Remove(detallePedidoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetallePedidoModelExists(int id)
        {
            return _context.DetallePedidoModel.Any(e => e.Id == id);
        }
    }
}
