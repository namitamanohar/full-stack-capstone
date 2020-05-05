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
using Microsoft.AspNetCore.Mvc.Rendering;
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

            var user = await GetCurrentUserAsync();

            var OppCartItems = await _context.OppCart
                .Where(oc => oc.UserId == user.Id)
                .ToListAsync(); 

            var opps = await _context.Opportunity.
                Include(o => o.Subject)
                .Include(o => o.ProgramType).ToListAsync();

            var ProgramTypes = await _context.ProgramType
          .Select(pt => new SelectListItem() { Text = pt.Title, Value = pt.Id.ToString() })
          .ToListAsync();

            var SubjectTypes = await _context.Subject
               .Select(s => new SelectListItem() { Text = s.Title, Value = s.Id.ToString() })
               .ToListAsync();

            var viewModel = new OppListAndCreateFormViewModel()
            {
                Opportunities = opps,
                OppForm = new OppFormViewModel()
                {
                    SubjectOptions = SubjectTypes, 
                    ProgramTypeOptions = ProgramTypes
                }, 
                OppCartItems = OppCartItems

            };
            return View(viewModel);


        }

        // GET: Opportunties/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        //GET: Opportunties/Create
        public async Task<ActionResult> Create()
        {

         

            return View();
        }

        // POST: Opportunties/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateOpp(OppListAndCreateFormViewModel OppViewForm)
        {
            try
            {
                var opp = new Opportunity
                {
                    Title = OppViewForm.OppForm.Title, 
                    Description = OppViewForm.OppForm.Description, 
                    ApplicationLink = OppViewForm.OppForm.ApplicationLink, 
                    StartDate = OppViewForm.OppForm.StartDate, 
                    EndDate = OppViewForm.OppForm.EndDate, 
                    AgeRange = OppViewForm.OppForm.AgeRange, 
                    SubjectId = OppViewForm.OppForm.SubjectId, 
                    ProgramTypeId = OppViewForm.OppForm.ProgramTypeId, 
                    IsActive = true, 
                    ApplicationDeadline = OppViewForm.OppForm.ApplicationDeadline

                };

                _context.Opportunity.Add(opp);
                await _context.SaveChangesAsync(); 

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
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