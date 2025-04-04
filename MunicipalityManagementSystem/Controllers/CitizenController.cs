using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MunicipalityManagementSystem.Data;
using MunicipalityManagementSystem.Models;

namespace MunicipalityManagementSystem.Controllers
{
    //Is responsible for all actions related to Citizens
    public class CitizenController : Controller
    {
        //Declare a private readonly field to store the database
        private readonly MunicipalityManagementSystemContext _context;

        //Constructor to inject the database
        public CitizenController(MunicipalityManagementSystemContext context)
        {
            _context = context; //Inject the database context 
        }

        //GET: Citizen
        //Display a list of Citizens
        public async Task<IActionResult> Index()
        {
            //Get all Citizens from the database
            var citizens = await _context.Citizens.ToListAsync();
            //Pass the list of Citizens to the view, return the Index view
            return View(citizens);
        }

        //GET: Citizen/Create
        //Display a form to create a new Citizen
        public IActionResult Create()
        {
            return View(); //Return the Create view
        }

        //POST: Citizen/Create
        //Create a new Citizen
        [HttpPost]
        [ValidateAntiForgeryToken] //Prevent Cross-Site Request Forgery
        public async Task<IActionResult> Create(CitizenManagement citizen)
        {
            if (ModelState.IsValid) //Check if the form is valid
            {
                citizen.RegistrationDate = DateTime.Now; //Set registration date
                _context.Citizens.Add(citizen); //Add the new Citizen to the database
                await _context.SaveChangesAsync(); //Save changes
                return RedirectToAction("Index"); //Redirect to the Index
            }
            return View(citizen); //Return the Create view, if validation fails
        }

        //GET: Citizen/Edit/5
        //Display a form to edit an existing Citizen
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) //Check if the id is null
            {
                return NotFound();
            }
            //Get the Citizen from the database
            var citizen = await _context.Citizens.FindAsync(id);
            if (citizen == null) //Check if the Citizen is null
            {
                return NotFound();
            }
            return View(citizen); //Return the Edit view
        }

        //POST: Citizen/Edit/5
        //Edit an existing Citizen
        [HttpPost]
        [ValidateAntiForgeryToken] //Prevent Cross-Site Request Forgery
        public async Task<IActionResult> Edit(int? id, CitizenManagement citizen)
        {
            if (id != citizen.CitizenID) //Check if the id is not equal to the CitizenID
            {
                return NotFound();
            }
            if (ModelState.IsValid) //Check if the form is valid
            {
                _context.Citizens.Update(citizen); //Update the citizen in the context
                await _context.SaveChangesAsync(); //Save changes
                return RedirectToAction("Index"); //Redirect to Index action after successful update
            }
            return View(citizen); //Return the Edit view
        }

        //GET: Citizen/Delete/5
        //Display a form to delete a Citizen
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) //Check if the id is null
            {
                return NotFound();
            }
            //Get the Citizen from the database
            var citizen = await _context.Citizens.FindAsync(id);
            if (citizen == null) //Check if the Citizen is null
            {
                return NotFound();
            }
            return View(citizen); //Return the Delete view
        }

        //POST: Citizen/Delete/5
        //Delete a Citizen
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken] //Prevent Cross-Site Request Forgery
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null) 
            {   
                return NotFound();
            }
            //Find the CitizenManagement entity
            var citizen = await _context.Citizens.FindAsync(id);

            //Check if the entity is null before attempting to remove
            if (citizen == null)
            {
                return NotFound();
            }
            //Get the Citizen from the database by ID and remove them 
            _context.Citizens.Remove(citizen);
            await _context.SaveChangesAsync(); //Save changes
            return RedirectToAction("Index"); //Redirect to Index
        }

        //Helper method to get all Citizens
        private bool CitizenExists(int id)
        {
            return _context.Citizens.Any(e => e.CitizenID == id); //Check if any citizen with the ID exists
        }

        //Get: Citizen/Details/5
        //Display details of a Citizen
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) //Check if the id is null
            {
                return NotFound();
            }
            //Get the Citizen from the database
            var citizen = await _context.Citizens.FindAsync(id);
            if (citizen == null)
            {
                return NotFound();
            }
            return View(citizen); //Return the Details view
        }

        //POST: Citizen/Details/5
        //Display details of a Citizen
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(int? id, CitizenManagement citizen)
        {
            if (id == null)
            //Check if the id is not equal to the CitizenID
            {
                return NotFound();
            }
            if (id != citizen.CitizenID)
            {
                var citizen1 = await _context.Citizens.FindAsync(id);
                return NotFound();
            }
            return View(citizen); //Return the Details view
        }
    }
}
