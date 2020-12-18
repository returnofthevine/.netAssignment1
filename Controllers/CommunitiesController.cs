using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab4.Data;
using Lab4.Models;
using Lab4.Models.ViewModels;

namespace Lab4.Controllers
{
    public class CommunitiesController : Controller
    {
        private readonly SchoolCommunityContext _context;

        public CommunitiesController(SchoolCommunityContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string ID)
        {
            var viewModel = new CommunityViewModel();
            viewModel.Community = await _context.Community
                  .Include(i => i.CommunityMemberships)
                  .ThenInclude(i => i.Student)
                  .AsNoTracking()
                  .OrderBy(i => i.Title)
                  .ToListAsync();
            
            if (ID != null)
            {
 
                viewModel.CommunityMemberships = viewModel.Community.Where(
                    x => x.CommunityID == ID).Single().CommunityMemberships;
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var community = await _context.Community
                .FirstOrDefaultAsync(m => m.CommunityID == id);
            if (community == null)
            {
                return NotFound();
            }

            return View(community);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommunityID,Title,Budget")] Community community)
        {
            if (ModelState.IsValid)
            {
                _context.Add(community);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(community);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var community = await _context.Community.FindAsync(id);
            if (community == null)
            {
                return NotFound();
            }
            return View(community);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CommunityID,Title,Budget")] Community community)
        {
            if (id != community.CommunityID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(community);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommunityExists(community.CommunityID))
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
            return View(community);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var community = await _context.Community
                .FirstOrDefaultAsync(m => m.CommunityID == id);
            if (community == null)
            {
                return NotFound();
            }

            return View(community);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var community = await _context.Community.FindAsync(id);
            _context.Community.Remove(community);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommunityExists(string id)
        {
            return _context.Community.Any(e => e.CommunityID == id);
        }
    }
}
