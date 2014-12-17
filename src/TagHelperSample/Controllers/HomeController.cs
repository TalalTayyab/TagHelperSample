using System;
using System.Collections.Generic;
using System.Globalization;
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

        public IActionResult List()
        {
            
            return View("List", Person.Persons);
        }

     

        [HttpGet]
        public IActionResult Form()
        {
            ViewBag.Countries = GetCountries();

            var p = new Person();
           
            
            return View(p);
        }


        [HttpPost]
        public IActionResult FormSave(Person p)
        {
            ViewBag.Countries = GetCountries();

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Form not saved due to errors");
                return View("Form", p);
            }

            Person.Persons.Add(p);
            return RedirectToAction("List");
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