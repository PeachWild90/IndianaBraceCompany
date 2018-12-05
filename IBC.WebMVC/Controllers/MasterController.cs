using IBC.Models.MasterModel;
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
    public class MasterController : Controller
    {
        // GET: Master
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MasterCartService(userId);
            var model = service.GetMasterCarts();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterCartCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateMasterCartService();

            if (service.CreateCart(model))
            {
                TempData["SaveResult"] = "Your Item was Added to the Cart";
                return RedirectToAction("Cart");
            }

            ModelState.AddModelError("", "Item could not be added");

            return View(model);
        }

        //[ActionName("Delete")]
        //public ActionResult Delete(int id)
        //{
        //    var svc = CreateMasterCartService();
        //    var model = svc.GetMasterCartsById(id);

        //    return View(model);
        //}

        //[HttpPost]
        //[ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeletePost(int id) //this actionresult REMOVES the FM from the DB (needs a different name due to overloading issues*** ????
        //{
        //    var service = CreateMasterCartService();

        //    service.DeleteMasterCart(id);

        //    TempData["SaveResult"] = "Your FaceMask was removed";

        //    return RedirectToAction("Index");
        //}

        private MasterCartService CreateMasterCartService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MasterCartService(userId);
            return service;
        }
    }
}