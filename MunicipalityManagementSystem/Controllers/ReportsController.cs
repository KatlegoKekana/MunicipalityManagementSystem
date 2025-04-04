using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MunicipalityManagementSystem.Data;
using MunicipalityManagementSystem.Models;

namespace MunicipalityManagementSystem.Controllers
{
    //Is responsible for all actions related to Reports
    public class ReportsController : Controller
    {
        //private readonly field to store database context
        private readonly MunicipalityManagementSystemContext _context;

        //Constructor
        public ReportsController(MunicipalityManagementSystemContext context)
        {
            _context = context; //Inject the database context
        }

        //GET: Reports
        //Display a list of Reports
        public async Task<IActionResult> Index()
        {
            //Get all Reports from the database
            var reports = await _context.Reports.ToListAsync(); //Include the Citizen navigation property
            return View(reports); //Pass the list of Reports to the view
        }

        //GET: Reports/Create
        //Display a form to create a new Report
        public IActionResult Create()
        {
            //Pass the list of Citizens to the view
            return View();
        }

        //POST: Reports/Crete
        //Create a new Report
        [HttpPost]
        [ValidateAntiForgeryToken] //Prevent Cross-Site Request Forgery
        public async Task<IActionResult> Create(Reports report)
        {
            //Check if the model is valid
            if (ModelState.IsValid)
            {
                //Set the current date
                report.SubmissionDate = DateTime.Now;
                //Add the report to the database
                _context.Reports.Add(report);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index"); //Redirect to Index
            }
            return View(report); //Return the Create view
        }

        //GET: Reports/Edit/5
        //Display a form to edit a Report
        public async Task<IActionResult> Edit(int? id)
        {
            //Check if the id is null
            if (id == null)
            {
                return NotFound();
            }
            //Get the Report from the database
            var report = await _context.Reports.FindAsync(id);
            if (report == null)
            {
                return NotFound();
            }
            //Pass the Report to the view
            return View(report);
        }

        //POST: Reports/Edit/5
        //Edit a Report
        [HttpPost]
        [ValidateAntiForgeryToken] //Prevent Cross-Site Request Forgery
        public async Task<IActionResult> Edit(int id,   Reports report)
        {
            //Check if the id is not equal to the ReportID
            if (id != report.ReportID)
            {
                return NotFound();
            }
            //Check if the model is valid
            if (ModelState.IsValid)
            {
                // Update the Report in the database
                _context.Update(report);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(report); //Return the Edit view
        }

        //GET: Reports/Delete/5
        //Display a form to delete a Report
        public async Task<IActionResult> Delete(int? id)
        {
            //Check if the id is null
            if (id == null)
            {
                return NotFound();
            }
            //Get the Report from the database
            var report = await _context.Reports.FirstOrDefaultAsync(m => m.ReportID == id);
            if (report == null)
            {
                return NotFound();
            }
            //Pass the Report to the view
            return View(report);
        }

        //POST: Reports/Delete/5
        //Delete a Report
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Find the CitizenManagement entity
            var report = await _context.Reports.FindAsync(id);

            //Check if the entity is null before attempting to remove
            if (report == null)
            {
                return NotFound();
            }
            //Get the Report from the database
            _context.Reports.Remove(report);
            await _context.SaveChangesAsync(); //Save changes
            return RedirectToAction("Index"); //Redirect to Index
        }

        //GET: Reports/Details/5
        //Display details of a Report
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var report = await _context.Reports.FindAsync(id); //Get the Report from the database
            if (report == null)
            {
                return NotFound();
            }
            //Pass the Report to the view
            return View(report);
        }

        //POST: Reports/Details/5
        //Display details of a Report
        [HttpPost]
        [ValidateAntiForgeryToken] //Prevent Cross-Site Request Forgery
        public async Task<IActionResult> Details(int? id, Reports report)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Check if the id is not equal to the ReportID
            if (id != report.ReportID)
            {
                var report1 = await _context.Reports.FindAsync(id);
                return NotFound();
            }
            //Pass the Report to the view
            return View(report);
        }
    }
}
