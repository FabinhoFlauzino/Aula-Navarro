using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lojinha.Data;
using Lojinha.Models;

namespace Lojinha.Controllers
{
    public class ItensController : Controller
    {
        private readonly LojinhaContext _context;

        public ItensController(LojinhaContext context)
        {
            _context = context;
        }

        // GET: Itens
        public async Task<IActionResult> Index()
        {
            var lojinhaContext = _context.Itens.Include(i => i.Pedido).Include(i => i.Produto);
            return View(await lojinhaContext.ToListAsync());
        }

        // GET: Itens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itens = await _context.Itens
                .Include(i => i.Pedido)
                .Include(i => i.Produto)
                .SingleOrDefaultAsync(m => m.PedidoId == id);
            if (itens == null)
            {
                return NotFound();
            }

            return View(itens);
        }

        // GET: Itens/Create
        public IActionResult Create()
        {
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "Id", "Nome");
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Nome");
            return View();
        }

        // POST: Itens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PedidoId,Quantidade,ProdutoId")] Itens itens)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itens);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "Id", "Id", itens.PedidoId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Id", itens.ProdutoId);
            return View(itens);
        }

        // GET: Itens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itens = await _context.Itens.SingleOrDefaultAsync(m => m.PedidoId == id);
            if (itens == null)
            {
                return NotFound();
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "Id", "Id", itens.PedidoId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Id", itens.ProdutoId);
            return View(itens);
        }

        // POST: Itens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PedidoId,Quantidade,ProdutoId")] Itens itens)
        {
            if (id != itens.PedidoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itens);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItensExists(itens.PedidoId))
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
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "Id", "Id", itens.PedidoId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Id", itens.ProdutoId);
            return View(itens);
        }

        // GET: Itens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itens = await _context.Itens
                .Include(i => i.Pedido)
                .Include(i => i.Produto)
                .SingleOrDefaultAsync(m => m.PedidoId == id);
            if (itens == null)
            {
                return NotFound();
            }

            return View(itens);
        }

        // POST: Itens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itens = await _context.Itens.SingleOrDefaultAsync(m => m.PedidoId == id);
            _context.Itens.Remove(itens);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItensExists(int id)
        {
            return _context.Itens.Any(e => e.PedidoId == id);
        }
    }
}
