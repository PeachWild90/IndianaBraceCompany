using IBC.Models.TKEModels;
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
            var model = new TKEListItem[0];
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TKECreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}