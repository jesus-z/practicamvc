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
    public class PedidosController : Controller
    {
        private readonly practicamvcContext _context;

        public PedidosController(practicamvcContext context)
        {
            _context = context;
        }

        // GET: PedidoModels
        public async Task<IActionResult> Index()
        {
            var practicamvcContext = _context.PedidoModel.Include(p => p.Cliente);
            return View(await practicamvcContext.ToListAsync());
        }

        // GET: PedidoModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoModel = await _context.PedidoModel
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedidoModel == null)
            {
                return NotFound();
            }

            return View(pedidoModel);
        }

        // GET: PedidoModels/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.ClientesModel, "Id", "NombreCompleto");
            return View();
        }

        // POST: PedidoModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaPedido,ClienteId,Estado,MontoDecimal")] Pedidos pedidoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedidoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.ClientesModel, "Id", "NombreCompleto", pedidoModel.ClienteId);
            return View(pedidoModel);
        }

        // GET: PedidoModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoModel = await _context.PedidoModel.FindAsync(id);
            if (pedidoModel == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.ClientesModel, "Id", "NombreCompleto", pedidoModel.ClienteId);
            return View(pedidoModel);
        }

        // POST: PedidoModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaPedido,ClienteId,Estado,MontoDecimal")] Pedidos pedidoModel)
        {
            if (id != pedidoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedidoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoModelExists(pedidoModel.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.ClientesModel, "Id", "NombreCompleto", pedidoModel.ClienteId);
            return View(pedidoModel);
        }

        // GET: PedidoModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoModel = await _context.PedidoModel
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedidoModel == null)
            {
                return NotFound();
            }

            return View(pedidoModel);
        }

        // POST: PedidoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedidoModel = await _context.PedidoModel.FindAsync(id);
            if (pedidoModel != null)
            {
                _context.PedidoModel.Remove(pedidoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoModelExists(int id)
        {
            return _context.PedidoModel.Any(e => e.Id == id);
        }
    }
}
