using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Revision_Take1.Models;

namespace Revision_Take1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View(new AzureStorage() {Redundancy = Redundancy.Geographically });
        }

        [HttpPost]
        public ActionResult Create(AzureStorage astore)
        {
           // ViewBag.Message = "Your application description page.";
            if(ModelState.IsValid)
            {
                return RedirectToAction("Confirm", astore);
            
            }

            return View(astore);
        }

        public ActionResult Confirm(AzureStorage astore)
        {
           // ViewBag.Message = "Your contact page.";

            return View(astore);
        }
    }
}