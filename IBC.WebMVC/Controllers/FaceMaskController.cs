using IBC.Models.FaceMaskModels;
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
        {
            var model = new FaceMaskListItem[0];    //initializing new instance of FaceMaskListItem as an IEnumerable(with the [0] syntax)
            return View(model);                     //when we added the List template for our view, it created IEnumerable requiremens for our list view
        }

        //GET method that gives users a View in which they can fill in INFO. Request is the Create view, so we have to MAKE a MODEL for the view
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FaceMaskCreate model) //this pushes the data inputeed int the view through our service and into the DB
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}