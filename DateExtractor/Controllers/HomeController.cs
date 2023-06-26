using DateExtractor.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace DateExtractor.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult DateExtractorPage()
        {
            return View();
        }

        public IActionResult dateExtractor(String randomString)
        {
            string pattern = @"(0[1-9]|1[0-2])(0[1-9]|1\d|2[0-9]|3[01])(\d{4})";
            Regex regex = new Regex(pattern);

            //string validDate = null;
            Match match = regex.Match(randomString); //checks if regex pattern can be found in the given string 

            if (match.Success)
            {
                ViewBag.Date = match.Value;
            }
            else ViewBag.Date = " Sorry, No valid date found";

            return View("DateExtractorPage");

        }
    }
}