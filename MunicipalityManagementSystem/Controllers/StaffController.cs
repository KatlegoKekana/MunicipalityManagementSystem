using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MunicipalityManagementSystem.Data;
using MunicipalityManagementSystem.Models;

namespace MunicipalityManagementSystem.Controllers
{
    //[Route("api/[controller]")]
    public class StaffController : Controller
    {
        //Inject the database context
        private readonly MunicipalityManagementSystemContext _context;

        //Constructor
        public StaffController(MunicipalityManagementSystemContext context)
        {
            _context = context; //Inject the database context
        }

        //GET: Staff
        //Display a list of Staff
        public async Task<IActionResult> Index()
        {
            //Get all Staff from the database
            var staffList = await _context.Staffs.ToListAsync();
            return View(staffList); //Pass the list of Staff to the view
        }

        //GET: Staff/Create
        //Display a form to create a new Staff
        public IActionResult Create()
        {
            return View(); //Return the Create view
        }

        //POST: Staff/Create
        //Create a new Staff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StaffManagement staff)
        {
            //Check if the form is valid
            if (ModelState.IsValid)
            {

                    //Add the new Staff to the database
                    _context.Staffs.Add(staff);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
            }
            return View(staff); //Return the Create view, if validation fails
        }

        //GET: Staff/Edit/5
        //Display a form to edit an existing Staff
        public async Task<IActionResult> Edit(int? id)
        {
            //Check if the id is null
            if (id == null)
            {
                return NotFound();
            }
            //Get the Staff from the database
            var staff = await _context.Staffs.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            //Pass the Staff to the view
            return View(staff);
        }

        //POST: Staff/Edit/5
        //Edit an existing Staff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StaffManagement staff)
        {
            if (id != staff.StaffID)
            {
                //Check if the id is not equal to the StaffID
                return NotFound();
            }
            //Check if the form is valid
            if (ModelState.IsValid)
            {
                _context.Update(staff);
                //Update the Staff in the database
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(staff);
        }

        //GET: Staff/Delete/5
        //Display a form to delete a Staff
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                //  Check if the id is null
                return NotFound();
            }
            //Get the Staff from the database
            var staff = await _context.Staffs.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            return View(staff); //Return the Delete view
        }

        //POST: Staff/Delete/5
        //Delete a Staff
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            //Get the Staff from the database
            var staff = await _context.Staffs.FindAsync(id);

            //Check if the entity is null before attempting to remove
            if (staff == null)
            {
                return NotFound();
            }
            _context.Staffs.Remove(staff);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //GET: Staff/Details/5
        //Display details of a Staff
        public async Task<IActionResult> Details(int? id)
        {
            //Check if the id is null
            if (id == null)
            {
                return NotFound();
            }
            //Get the Staff from the database
            var staff = await _context.Staffs.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            return View(staff); //Return the Details view
        }

        //POST: Staff/Details/5
        //Edit a Staff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(int id, StaffManagement staff)
        {
            if (id != staff.StaffID)
            {
                //Check if the id is not equal to the StaffID
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                //Update the Staff in the database
                _context.Update(staff);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(staff);
        }
    }
}
