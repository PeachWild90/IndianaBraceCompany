using IBC.Models.X1BladeModels;
using IBC.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IBC.WebMVC.Controllers
{
    public class X1BladeController : Controller
    {
        // GET: X1Blade
        [Authorize]
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new X1BladeService(userId);
            var model = service.GetX1Blades();

            return View(model);
        }

        //GET the VIEW
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(X1BladeCreate model) //This is the POST method
        {
            if (!ModelState.IsValid) return View(model); //method makes sure the model is valid

            var service = CreateX1BladeService();

            if (service.CreateX1Blade(model))
            {
                TempData["SaveResult"] = "Your X-1 Blade order was created!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "X1-Blade could not be entered...");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateX1BladeService();
            var model = svc.GetX1BladeById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateX1BladeService();
            var detail = service.GetX1BladeById(id);
            var model =
                new X1BladeEdit
                {
                    X1BladeId = detail.X1BladeId,
                    Injury = detail.Injury,
                    FootSize = detail.FootSize,
                    Foot = detail.Foot,
                    Quantity = detail.Quantity
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, X1BladeEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.X1BladeId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateX1BladeService();

            if (service.UpdateX1Blade(model))
            {
                TempData["SaveResult"] = "Your X1-Blade Order was Updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateX1BladeService();
            var model = svc.GetX1BladeById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateX1BladeService(); //add in validation here

            service.DeleteX1Blade(id); //error for this goes away once we add code to the Service (aka add a delete method)

            TempData["SaveResult"] = "Your X1 Blade was deleted";

            return RedirectToAction("Index");
        }

        private X1BladeService CreateX1BladeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new X1BladeService(userId);
            return service;
        }
    }
}