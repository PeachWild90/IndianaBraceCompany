using IBC.Models.TKEModels;
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
    public class TKEController : Controller
    {
        // GET: TKE
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TKEService(userId);
            var model = service.GetTKEs();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TKECreate model)//makes sure the model is avlid, grabs the current userId. calls on CreateTKE, and reurns the user back to the index view
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTKEService();

           if (service.CreateTKE(model))
            {
                TempData["SaveResult"] = "Your TKE was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "TKE could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateTKEService();
            var model = svc.GetTKEById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateTKEService();
            var detail = service.GetTKEById(id);
            var model =
                new TKE_Edit
                {
                    TKEId = detail.TKEId,
                    Reason = detail.Reason,
                    Quantity = detail.Quantity
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TKE_Edit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.TKEId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateTKEService();

            if (service.UpdateTKE(model))
            {
                TempData["SaveResult"] = "Your TKE was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your TKE could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTKEService();
            var model = svc.GetTKEById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateTKEService();

            service.DeleteTKE(id);

            TempData["SaveResult"] = "Your TKE was deleted";

            return RedirectToAction("Index");
        }

        private TKEService CreateTKEService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TKEService(userId);
            return service;
        }
    }
}