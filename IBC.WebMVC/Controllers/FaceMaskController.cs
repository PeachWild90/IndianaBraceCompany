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
            var model = service.GetFaceMasks();    //initializing new instance of FaceMaskListItem as an IEnumerable(with the [0] syntax)
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

        public ActionResult Details(int id)
        {
            var svc = CreateFaceMaskService();
            var model = svc.GetFaceMaskById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateFaceMaskService();
            var detail = service.GetFaceMaskById(id);
            var model =
                new FaceMaskEdit
                {
                    FaceMaskId = detail.FaceMaskId,
                    Style = detail.Style,
                    Personalization = detail.Personalization,
                    Color = detail.Color,
                    Height = detail.Height,
                    Weight = detail.Weight,
                    Sport = detail.Sport,
                    Quantity = detail.Quantity
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FaceMaskEdit model) //this is an overloaded Edit Action Result method, I add validation similar to ActionResult Create to make sure FaceMaskId matches
        {
            if (!ModelState.IsValid) return View(model);

            if(model.FaceMaskId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateFaceMaskService(); //this part displays a message to the user with the result of their actions

            if (service.UpdateFaceMask(model))
            {
                TempData["SaveResult"] = "Your FaceMask specifications were updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateFaceMaskService();
            var model = svc.GetFaceMaskById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id) //this actionresult REMOVES the FM from the DB (needs a different name due to overloading issues*** ????
        {
            var service = CreateFaceMaskService();

            service.DeleteNote(id);

            TempData["SaveResult"] = "Your FaceMask was removed";

            return RedirectToAction("Index");
        }

        //get view

        //post
        //public ActionResult Checkout(int ownerId)

        private FaceMaskService CreateFaceMaskService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FaceMaskService(userId);
            return service;
        }
    }
}