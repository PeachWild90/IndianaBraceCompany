using IBC.Models.X1BladeModels;
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
            var model = new X1BladeListItem[0];
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(X1BladeCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}