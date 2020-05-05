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
    public class OppCartsController : Controller
    {


        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        public OppCartsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {

            _context = context;
            _userManager = userManager;
        }
        // GET: OppCarts
        public async Task<ActionResult> Index()
        {
            var user = await GetCurrentUserAsync();

            var oppCartItems = await _context.OppCart
                .Where(o => o.UserId == user.Id)
                .Include(o => o.Opportunity)
                .ToListAsync(); 

            return View(oppCartItems);
        }

        // GET: OppCarts/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        // GET: OppCarts/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: OppCarts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddToCart (Opportunity opp)
        {
            try
            {
                
                var OppCart = new OppCart
                {

                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OppCarts/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: OppCarts/Edit/5
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

        // GET: OppCarts/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: OppCarts/Delete/5
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