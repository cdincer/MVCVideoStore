using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VideoStore.Controllers
{
    [AllowAnonymous]         //This helps people without accounts to see the main landing page.

    public class HomeController : Controller
    {
        //Cache store period in seconds and its location.
        //Have caching depending on parameters. Star is for all.
        [OutputCache(Duration = 50, Location = System.Web.UI.OutputCacheLocation.Server, VaryByParam = "*")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Come on down and rent your movies from us directly !";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}