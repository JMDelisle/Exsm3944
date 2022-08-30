using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Exsm3945_Assignment.Data;
using Exsm3945_Assignment.Models;

namespace Exsm3945_Assignment.Controllers
{
    public class AccountTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AccountType
        public async Task<IActionResult> Index()
        {
              return _context.AccountTypes != null ? 
                          View(await _context.AccountTypes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.AccountTypes'  is null.");
        }

        // GET: AccountType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AccountTypes == null)
            {
                return NotFound();
            }

            var accountType = await _context.AccountTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountType == null)
            {
                return NotFound();
            }

            return View(accountType);
        }

        // GET: AccountType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccountType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,InterestRate")] AccountType accountType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accountType);
        }

        // GET: AccountType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AccountTypes == null)
            {
                return NotFound();
            }

            var accountType = await _context.AccountTypes.FindAsync(id);
            if (accountType == null)
            {
                return NotFound();
            }
            return View(accountType);
        }

        // POST: AccountType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,InterestRate")] AccountType accountType)
        {
            if (id != accountType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountTypeExists(accountType.Id))
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
            return View(accountType);
        }

        // GET: AccountType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AccountTypes == null)
            {
                return NotFound();
            }

            var accountType = await _context.AccountTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (accountType == null)
            {
                return NotFound();
            }

            return View(accountType);
        }

        // POST: AccountType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AccountTypes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.AccountTypes'  is null.");
            }
            var accountType = await _context.AccountTypes.FindAsync(id);
            if (accountType != null)
            {
                _context.AccountTypes.Remove(accountType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountTypeExists(int id)
        {
          return (_context.AccountTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
