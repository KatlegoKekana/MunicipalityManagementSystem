using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MunicipalityManagementSystem.Data;
using MunicipalityManagementSystem.Models;

namespace MunicipalityManagementSystem.Controllers
{
    public class ServiceRequestController : Controller
    {
        //Dependency Injection
        private readonly MunicipalityManagementSystemContext _context;

        //Constructor
        public ServiceRequestController(MunicipalityManagementSystemContext context)
        {
            _context = context; //Inject the database context
        }

        //GET: ServiceRequest
        //Display a list of ServiceRequests
        public async Task<IActionResult> Index()
        {
            //Get all ServiceRequests from the database
            var serviceRequests = await _context.ServiceRequests.ToListAsync();
            return View(serviceRequests); //Pass the list of ServiceRequests to the view
        }

        //GET: ServiceRequest/Create
        //Display a form to create a new ServiceRequest
        public IActionResult Create()
        {
            //Pass the ServiceRequest to the view
            return View();
        }

        //POST: ServiceRequest/Create
        //Create a new ServiceRequest
        [HttpPost]
        [ValidateAntiForgeryToken] //Prevent Cross-Site Request Forgery
        public async Task<IActionResult> Create(ServiceRequest serviceRequest)
        {
            if (ModelState.IsValid)
            { 
                serviceRequest.RequestDate = DateTime.Now;
                //Add the ServiceRequest to the database
                _context.ServiceRequests.Add(serviceRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index"); //Redirect to Index
            }
            return View(serviceRequest); //Return the Create view
        }

        //GET: ServiceRequests/Edit/5
        //Display a form to edit a ServiceRequest
        public async Task<IActionResult> Edit(int? id)
        {
            //Check if the id is null
            if (id == null)
            {
                return NotFound();
            }
            //Get the ServiceRequest from the database
            var serviceRequest = await _context.ServiceRequests.FindAsync(id);
            if (serviceRequest == null)
            {
                return NotFound();
            }
            return View(serviceRequest); //Return the Edit view
        }

        //POST: ServiceRequest/Edit/5
        //Edit a ServiceRequest
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ServiceRequest request)
        {
            if (id != request.ServiceRequestID)
            {
                return NotFound(); //Check if the id is not equal to the ServiceRequestID
            }
            if (ModelState.IsValid) //Check if the model is valid
            {
                //Update the ServiceRequest in the database
                _context.ServiceRequests.Update(request);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(request); //Return the Edit view
        }

        //GET: ServiceRequest/Delete/5
        //Display a form to delete a ServiceRequest
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Get the ServiceRequest from the database
            var serviceRequest = await _context.ServiceRequests.FindAsync(id);
            if (serviceRequest == null)
            {
                return NotFound();
            }
            //Pass the ServiceRequest to the view
            return View(serviceRequest);
        }

        //POST: ServiceRequests/Delete/5
        //Delete a ServiceRequest
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken] //Prevent Cross-Site Request Forgery
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Get the ServiceRequest from the database
            var serviceRequest = await _context.ServiceRequests.FindAsync(id);
            if (serviceRequest == null)
            {
                return NotFound();
            }

             //Check if the ServiceRequest is null
            _context.ServiceRequests.Remove(serviceRequest);
            await _context.SaveChangesAsync();
            
            //  Redirect to Index
            return RedirectToAction("Index");
        }

        //GET: ServiceRequest/Details/5
        //Display details of a ServiceRequest
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Get the ServiceRequest from the database
            var serviceRequest = await _context.ServiceRequests.FindAsync(id);
            if (serviceRequest == null)
            {
                return NotFound();
            }
            return View(serviceRequest);
        }

        //POST: ServiceRequest/Details/5
        //Display details of a ServiceRequest
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(int? id, ServiceRequest request)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Check if the id is not equal to the ServiceRequestID
            if (id != request.ServiceRequestID)
            {
                var request1 = await _context.ServiceRequests.FindAsync(id);
                return NotFound();
            }
            return View(request);
        }
    }
}
