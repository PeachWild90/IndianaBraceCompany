using IBC.Models.FaceMaskModels;
using IBC.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IBC.WebMVC.Controllers
{
    [Authorize]
    public class FaceMaskController : Controller
    {
        // GET: FaceMask
        public ActionResult Index()                 //ActionResult = return type, allows us to return a View() method, which corresponds to the FaceMaskController
        {                                           //Index method displays all notes for the current users
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FaceMaskService(userId);
            var model = service.GetNotes();    //initializing new instance of FaceMaskListItem as an IEnumerable(with the [0] syntax)
            return View(model);                     //when we added the List template for our view, it created IEnumerable requiremens for our list view
        }

        //GET method that gives users a View in which they can fill in INFO. Request is the Create view, so we have to MAKE a MODEL for the view
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FaceMaskCreate model) //this pushes the data inputed into the view through our service and into the DB
        {                                                //this method makes sure the model is valid, grabs the current userId, calls on CreateFaceMask, and returns the user back to the index view
            if (!ModelState.IsValid) return View(model);

            var service = CreateFaceMaskService();

            if (service.CreateFaceMask(model))
            {

                TempData["SaveResult"] = "Your FaceMask was created!";
                return RedirectToAction("Index");

            };

            ModelState.AddModelError("", "Note could not be created.");

            return View(model);
        }

        private FaceMaskService CreateFaceMaskService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FaceMaskService(userId);
            return service;
        }
    }
}