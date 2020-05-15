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
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly UserManager<ApplicationUser> _userManager;

        public OpportunitiesController(SignInManager<ApplicationUser> signInManager, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {

            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;

        }

        // GET: Opportunties
        public async Task<ActionResult> Index(string searchBar)
        {

            var user = await GetCurrentUserAsync();


            var opps = await _context.Opportunity.
                Include(o => o.Subject)
                .Include(o => o.ProgramType)
                .OrderBy(o => o.ApplicationDeadline)
                .ToListAsync();

            var InactiveOpps = await _context.Opportunity.
               Include(o => o.Subject)
               .Include(o => o.ProgramType)
               .Where(o => o.IsActive == false || o.ApplicationDeadline < DateTime.Now )
               .OrderBy(o => o.ApplicationDeadline)
               .ToListAsync();

            var ActiveOpps = await _context.Opportunity.
               Include(o => o.Subject)
               .Include(o => o.ProgramType)
               .Where(o => o.IsActive == true)
               .OrderBy(o => o.ApplicationDeadline)
               .Where(o => o.ApplicationDeadline > DateTime.Now)
               .ToListAsync();



            var ProgramTypes = await _context.ProgramType
          .Select(pt => new SelectListItem() { Text = pt.Title, Value = pt.Id.ToString() })
          .ToListAsync();

            var SubjectTypes = await _context.Subject
               .Select(s => new SelectListItem() { Text = s.Title, Value = s.Id.ToString() })
               .ToListAsync();

            var viewModel = new OppListAndCreateFormViewModel()
            {
                Opportunities = opps,
                InActiveOpportunities = InactiveOpps, 
                ActiveOpportunities = ActiveOpps, 
                OppForm = new OppFormViewModel()
                {
                    SubjectOptions = SubjectTypes,
                    ProgramTypeOptions = ProgramTypes
                }

            };


            if (searchBar != null)
            {

                var filteredOpps = await _context.Opportunity
                    .Include(o => o.Subject)
                    .Include(o => o.ProgramType)
                    .Where(o => o.Subject.Title
                    .Contains(searchBar) || o.Description.Contains(searchBar) || o.Title.Contains(searchBar) || o.ProgramType.Title.Contains(searchBar) ).ToListAsync();

                viewModel.ActiveOpportunities = filteredOpps;
                viewModel.InActiveOpportunities = null; 
            }

            //if the user is a student; then get there lastLogInTime which is currently stored in a TempData["LogInDate"]. OppDateCreated > lastLogIn

            if (_signInManager.IsSignedIn(User) && user.IsAdmin == false && TempData.ContainsKey("LoginDate"))
            {
                var lastLogin = TempData.Peek("LogInDate").ToString();


                DateTime lastLoginDate = DateTime.Parse(lastLogin);

                var newOpps = await _context.Opportunity
                    .Where(o => o.DateCreated > lastLoginDate)
                    .ToListAsync();

                viewModel.NewOpportunities = newOpps; 


            }
            if (user != null)
            {

                var OppCartItems = await _context.OppCart
                    .Where(oc => oc.UserId == user.Id)
                    .ToListAsync();
                viewModel.OppCartItems = OppCartItems; 

            }
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
                    ApplicationDeadline = OppViewForm.OppForm.ApplicationDeadline, 
                    DateCreated = DateTime.Now

                };

                _context.Opportunity.Add(opp);
                await _context.SaveChangesAsync();

                TempData["OppCreated"] = "You have added a summer program"; 


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
            var oppItem = await _context.Opportunity.FirstOrDefaultAsync(o => o.Id == id);

            var user = await GetCurrentUserAsync();

            var ProgramTypes = await _context.ProgramType
        .Select(pt => new SelectListItem() { Text = pt.Title, Value = pt.Id.ToString() })
        .ToListAsync();

            var SubjectTypes = await _context.Subject
               .Select(s => new SelectListItem() { Text = s.Title, Value = s.Id.ToString() })
               .ToListAsync();

            var viewModel = new OppFormViewModel()
            {
                Id = id, 
                Title = oppItem.Title, 
                Description = oppItem.Description, 
                StartDate = oppItem.StartDate, 
                EndDate = oppItem.EndDate, 
                ApplicationLink = oppItem.ApplicationLink, 
                ApplicationDeadline = oppItem.ApplicationDeadline, 
                AgeRange = oppItem.AgeRange,
                IsActive = oppItem.IsActive,
                ProgramTypeOptions = ProgramTypes, 
                ProgramTypeId = oppItem.ProgramTypeId, 
                SubjectOptions = SubjectTypes, 
                SubjectId = oppItem.SubjectId, 
                DateCreated = oppItem.DateCreated
                
            };
//return the JSon representation

            return Ok(viewModel);
        }

        // POST: Opportunties/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditOpp( OppListAndCreateFormViewModel OppListandForm)
        {
            try
            {
                //var oppItem = await _context.Opportunity.FirstOrDefaultAsync(o => o.Id == OppListandForm.OppForm.Id);

                var editedOpp = new Opportunity()
                {
                    Id = OppListandForm.OppForm.Id, 
                    Title = OppListandForm.OppForm.Title, 
                    Description = OppListandForm.OppForm.Description, 
                    ApplicationLink = OppListandForm.OppForm.ApplicationLink,
                    AgeRange = OppListandForm.OppForm.AgeRange, 
                    SubjectId = OppListandForm.OppForm.SubjectId, 
                    ProgramTypeId = OppListandForm.OppForm.ProgramTypeId, 
                    ApplicationDeadline = OppListandForm.OppForm.ApplicationDeadline, 
                    StartDate = OppListandForm.OppForm.StartDate, 
                    EndDate = OppListandForm.OppForm.EndDate, 
                    IsActive = true, 
                    DateCreated = OppListandForm.OppForm.DateCreated

                };

                _context.Opportunity.Update(editedOpp);
                await _context.SaveChangesAsync();

                TempData["OppEdited"] = "You have edited a summer program";


                return RedirectToAction("Index", "Opportunities");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Opportunties/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MakeOppInactive(int id)
        {
            try
            {
                var OppToMakeInactive = await _context.Opportunity.FirstOrDefaultAsync(o => o.Id == id);

                OppToMakeInactive.IsActive = false; 

            
                _context.Opportunity.Update(OppToMakeInactive);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Opportunities");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MakeOppActive(int id)
        {
            try
            {
                var OppToMakeInactive = await _context.Opportunity.FirstOrDefaultAsync(o => o.Id == id);

                OppToMakeInactive.IsActive = true;


                _context.Opportunity.Update(OppToMakeInactive);
                await _context.SaveChangesAsync();

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