using System;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using TagHelperSample.Model;

namespace TagHelper.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }


        public IActionResult Select()
        {
            var p = new Person();
            ViewBag.Countries = GetCountries();
            return View(p);
        }

        IEnumerable<SelectListItem> GetCountries()
        {
            return new SelectListItem[] 
                {
                    new SelectListItem() { Text="Australia", Value="AU" },
                    new SelectListItem() {Text = "Other" , Value= "*" }
                };
        }

    }
}