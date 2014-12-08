using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Revision_Take2.Models;

namespace Revision_Take2.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View(new AzureCloud() {NumInstances =2 });
        }

        [HttpPost]
        public ActionResult Create(AzureCloud azCloud)
        {
           // ViewBag.Message = "Your application description page.";

            if(ModelState.IsValid)
            {
                return RedirectToAction("Confirm", azCloud);
            }
            return View(azCloud);
        }

        public ActionResult Confirm(AzureCloud azCloud)
        {
           // ViewBag.Message = "Your contact page.";

            return View(azCloud);
        }
    }
}