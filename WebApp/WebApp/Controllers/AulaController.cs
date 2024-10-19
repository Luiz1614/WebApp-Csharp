using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.AppData;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AulaController : Controller
    {
        private readonly ApplicationContext _context;

        public AulaController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Aula
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aula.ToListAsync());
        }

        // GET: Aula/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aulaModel = await _context.Aula
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aulaModel == null)
            {
                return NotFound();
            }

            return View(aulaModel);
        }

        // GET: Aula/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aula/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Turma")] AulaModel aulaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aulaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aulaModel);
        }

        // GET: Aula/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aulaModel = await _context.Aula.FindAsync(id);
            if (aulaModel == null)
            {
                return NotFound();
            }
            return View(aulaModel);
        }

        // POST: Aula/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Turma")] AulaModel aulaModel)
        {
            if (id != aulaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aulaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AulaModelExists(aulaModel.Id))
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
            return View(aulaModel);
        }

        // GET: Aula/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aulaModel = await _context.Aula
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aulaModel == null)
            {
                return NotFound();
            }

            return View(aulaModel);
        }

        // POST: Aula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aulaModel = await _context.Aula.FindAsync(id);
            if (aulaModel != null)
            {
                _context.Aula.Remove(aulaModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AulaModelExists(int id)
        {
            return _context.Aula.Any(e => e.Id == id);
        }
    }
}
