using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FullStackCapstone.Data;
using FullStackCapstone.Models;
using FullStackCapstone.Models.ViewModels;
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
                .ThenInclude(o => o.Subject)
                .OrderBy(o => o.Opportunity.ApplicationDeadline)
                .ToListAsync();

            var oppCartItemsComplete = await _context.OppCart
                .Where(o => o.UserId == user.Id)
                .Include(o => o.Opportunity)
                .ThenInclude(o => o.Subject)
                .Where(o => o.IsComplete == true)
                .ToListAsync();

            var viewModel = new OppCartViewModel
            {
                OppCarts = oppCartItems,
                OppCartsComplete = oppCartItemsComplete, 
              
            };


            if (oppCartItems.Count>0)
            {

                decimal division = Decimal.Divide(oppCartItemsComplete.Count, oppCartItems.Count);
                decimal progressBar = division * 100;
                viewModel.progressBar = progressBar;              
            }
            return View(viewModel);
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
        public async Task<ActionResult> AddToCart (int id, Opportunity opp)
        {
            try
            {
                var Opp = _context.Opportunity.FirstOrDefault(o => o.Id == id);
                var user = await GetCurrentUserAsync(); 

                var OppCart = new OppCart
                {
                    OpportunityId = Opp.Id, 
                    UserId = user.Id, 
                    IsComplete = false 
                };

                _context.OppCart.Add(OppCart);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Opportunities");
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

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CompleteOpp(int id)
        {
            try
            {
                var user = await GetCurrentUserAsync();
                var oppToEdit = await _context.OppCart.FirstOrDefaultAsync(oc => oc.OpportunityId == id && oc.UserId == user.Id);

                oppToEdit.IsComplete = true; 


                _context.OppCart.Update(oppToEdit);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
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
        public async Task<ActionResult> DeleteFromCart(int id, IFormCollection collection)
        {
            try
            {
                var user = await GetCurrentUserAsync();
                var UserOpps = await _context.OppCart.Where(oc => oc.UserId == user.Id).ToListAsync();
                var OppToDelete = UserOpps.FirstOrDefault(uo => uo.OpportunityId == id);

                _context.OppCart.Remove(OppToDelete);
                await _context.SaveChangesAsync();

                TempData["OppDeleted"] = "You deleted an opportunity from your cart"; 
                return RedirectToAction("Index", "OppCarts");

            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public async Task<ActionResult> DeleteFromOppCard(int id)
        {
            try
            {
                var user = await GetCurrentUserAsync();
                var UserOpps = await _context.OppCart.Where(oc => oc.UserId == user.Id).ToListAsync();
                var OppToDelete = UserOpps.FirstOrDefault(uo => uo.OpportunityId == id);

                _context.OppCart.Remove(OppToDelete);
                await _context.SaveChangesAsync();

                TempData["OppDeleted"] = "You deleted an opportunity from your cart";
                return RedirectToAction("Index", "Opportunities");

            }
            catch (Exception ex)
            {
                return View();
            }
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

    }
}