using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SIPA.Models;

namespace SIPA.Controllers
{
    public class DetallePedidosController : Controller
    {
        private readonly SIPAContext _context;

        public DetallePedidosController(SIPAContext context)
        {
            _context = context;
        }

        // GET: DetallePedidos
        public async Task<IActionResult> Index()
        {
            var sIPAContext = _context.DetallePedido.Include(d => d.Articulo).Include(d => d.Pedido);
            return View(await sIPAContext.ToListAsync());
        }

        // GET: DetallePedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallePedido = await _context.DetallePedido
                .Include(d => d.Articulo)
                .Include(d => d.Pedido)
                .FirstOrDefaultAsync(m => m.DetallePedidoID == id);
            if (detallePedido == null)
            {
                return NotFound();
            }

            return View(detallePedido);
        }

        // GET: DetallePedidos/Create
        public IActionResult Create()
        {
            ViewData["ArticuloID"] = new SelectList(_context.Articulo, "ArticuloID", "ArticuloID");
            ViewData["ArticuloID"] = new SelectList(_context.Articulo, "ArticuloID", "PrecioVenta");
            ViewData["PedidoID"] = new SelectList(_context.Pedido, "PedidoID", "PedidoID");
            return View();
        }

        // POST: DetallePedidos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DetallePedidoID,ArticuloID,PrecioVenta,PedidoID,Cantidad,Monto")] DetallePedido detallePedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detallePedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArticuloID"] = new SelectList(_context.Articulo, "ArticuloID", "Nombre", detallePedido.ArticuloID);
            ViewData["ArticuloID"] = new SelectList(_context.Articulo, "ArticuloID", "PrecioVenta", detallePedido.ArticuloID);
            ViewData["PedidoID"] = new SelectList(_context.Pedido, "PedidoID", "PedidoID", detallePedido.PedidoID);
            return View(detallePedido);
        }

        // GET: DetallePedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallePedido = await _context.DetallePedido.FindAsync(id);
            if (detallePedido == null)
            {
                return NotFound();
            }
            ViewData["ArticuloID"] = new SelectList(_context.Articulo, "ArticuloID", "Nombre", detallePedido.ArticuloID);
            ViewData["ArticuloID"] = new SelectList(_context.Articulo, "ArticuloID", "PrecioVenta", detallePedido.ArticuloID);
            ViewData["PedidoID"] = new SelectList(_context.Pedido, "PedidoID", "PedidoID", detallePedido.PedidoID);
            return View(detallePedido);
        }

        // POST: DetallePedidos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DetallePedidoID,ArticuloID,ArticuloID,PedidoID,Cantidad,Monto")] DetallePedido detallePedido)
        {
            if (id != detallePedido.DetallePedidoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detallePedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetallePedidoExists(detallePedido.DetallePedidoID))
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
            ViewData["ArticuloID"] = new SelectList(_context.Articulo, "ArticuloID", "Nombre", detallePedido.ArticuloID);
            ViewData["ArticuloID"] = new SelectList(_context.Articulo, "ArticuloID", "PrecioVenta", detallePedido.ArticuloID);
            ViewData["PedidoID"] = new SelectList(_context.Pedido, "PedidoID", "PedidoID", detallePedido.PedidoID);
            return View(detallePedido);
        }

        // GET: DetallePedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallePedido = await _context.DetallePedido
                .Include(d => d.Articulo)
                .Include(d => d.Pedido)
                .FirstOrDefaultAsync(m => m.DetallePedidoID == id);
            if (detallePedido == null)
            {
                return NotFound();
            }

            return View(detallePedido);
        }

        // POST: DetallePedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detallePedido = await _context.DetallePedido.FindAsync(id);
            _context.DetallePedido.Remove(detallePedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetallePedidoExists(int id)
        {
            return _context.DetallePedido.Any(e => e.DetallePedidoID == id);
        }
    }
}
