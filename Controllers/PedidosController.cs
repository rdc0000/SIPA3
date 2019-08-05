﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SIPA.Models;

namespace SIPA.Controllers
{
    public class PedidosController : Controller
    {
        private readonly SIPAContext _context;

        public PedidosController(SIPAContext context)
        {
            _context = context;
        }

        // GET: Pedidos
        public async Task<IActionResult> Index()
        {
            var sIPAContext = _context.Pedido.Include(p => p.Autoservicio).Include(p => p.Cliente).Include(p => p.Domicilio).Include(p => p.Empleado).Include(p => p.MetodoPago);
            return View(await sIPAContext.ToListAsync());
        }

        // GET: Pedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido
                .Include(p => p.Autoservicio)
                .Include(p => p.Cliente)
                .Include(p => p.Domicilio)
                .Include(p => p.Empleado)
                .Include(p => p.MetodoPago)
                .FirstOrDefaultAsync(m => m.PedidoID == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedidos/Create
        public IActionResult Create()
        {
            ViewData["AutoservicioID"] = new SelectList(_context.Autoservicio, "AutoservicioID", "Direccion");
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ClienteID", "Apellido");
            ViewData["DomicilioID"] = new SelectList(_context.Domicilio, "DomicilioID", "DomicilioID");
            ViewData["EmpleadoID"] = new SelectList(_context.Empleado, "EmpleadoID", "Apellido");
            ViewData["MetodoPagoID"] = new SelectList(_context.MetodoPago, "MetodoPagoID", "NumeroReferencia");
            return View();
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PedidoID,EmpleadoID,AutoservicioID,ClienteID,MetodoPagoID,DomicilioID,FechaHora,Direccion,Total")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutoservicioID"] = new SelectList(_context.Autoservicio, "AutoservicioID", "Direccion", pedido.AutoservicioID);
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ClienteID", "Apellido", pedido.ClienteID);
            ViewData["DomicilioID"] = new SelectList(_context.Domicilio, "DomicilioID", "DomicilioID", pedido.DomicilioID);
            ViewData["EmpleadoID"] = new SelectList(_context.Empleado, "EmpleadoID", "Apellido", pedido.EmpleadoID);
            ViewData["MetodoPagoID"] = new SelectList(_context.MetodoPago, "MetodoPagoID", "NumeroReferencia", pedido.MetodoPagoID);
            return View(pedido);
        }

        // GET: Pedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            ViewData["AutoservicioID"] = new SelectList(_context.Autoservicio, "AutoservicioID", "Direccion", pedido.AutoservicioID);
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ClienteID", "Apellido", pedido.ClienteID);
            ViewData["DomicilioID"] = new SelectList(_context.Domicilio, "DomicilioID", "DomicilioID", pedido.DomicilioID);
            ViewData["EmpleadoID"] = new SelectList(_context.Empleado, "EmpleadoID", "Apellido", pedido.EmpleadoID);
            ViewData["MetodoPagoID"] = new SelectList(_context.MetodoPago, "MetodoPagoID", "NumeroReferencia", pedido.MetodoPagoID);
            return View(pedido);
        }

        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PedidoID,EmpleadoID,AutoservicioID,ClienteID,MetodoPagoID,DomicilioID,FechaHora,Direccion,Total")] Pedido pedido)
        {
            if (id != pedido.PedidoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.PedidoID))
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
            ViewData["AutoservicioID"] = new SelectList(_context.Autoservicio, "AutoservicioID", "Direccion", pedido.AutoservicioID);
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ClienteID", "Apellido", pedido.ClienteID);
            ViewData["DomicilioID"] = new SelectList(_context.Domicilio, "DomicilioID", "DomicilioID", pedido.DomicilioID);
            ViewData["EmpleadoID"] = new SelectList(_context.Empleado, "EmpleadoID", "Apellido", pedido.EmpleadoID);
            ViewData["MetodoPagoID"] = new SelectList(_context.MetodoPago, "MetodoPagoID", "NumeroReferencia", pedido.MetodoPagoID);
            return View(pedido);
        }

        // GET: Pedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido
                .Include(p => p.Autoservicio)
                .Include(p => p.Cliente)
                .Include(p => p.Domicilio)
                .Include(p => p.Empleado)
                .Include(p => p.MetodoPago)
                .FirstOrDefaultAsync(m => m.PedidoID == id);
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
            var pedido = await _context.Pedido.FindAsync(id);
            _context.Pedido.Remove(pedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedido.Any(e => e.PedidoID == id);
        }
    }
}
