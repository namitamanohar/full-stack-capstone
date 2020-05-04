using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullStackCapstone.Data;
using FullStackCapstone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStackCapstone.Controllers
{
    public class OpportunitiesController : Controller
    {

        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public OpportunitiesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {

            _context = context;
            _userManager = userManager;
        }

        // GET: Opportunties
        public async Task<ActionResult> Index()
        {
            var opps = await _context.Opportunity.
                Include(o => o.Subject)
                .Include(o => o.ProgramType).ToListAsync(); 
                            
            return View(opps);


        }

        // GET: Opportunties/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        // GET: Opportunties/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: Opportunties/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Opportunties/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: Opportunties/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Opportunties/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: Opportunties/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}