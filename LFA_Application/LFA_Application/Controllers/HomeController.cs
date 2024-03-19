using LFA_Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace LFA_Application.Controllers
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
            var model = new Form();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(Form model)
        {
            if (string.IsNullOrEmpty(model.Pattern) && string.IsNullOrEmpty(model.Text1) &&
                string.IsNullOrEmpty(model.Text2))
            {
                return View(model);
            }

            if (!IsValidRegexPattern(model.Pattern))
            {
                ViewBag.Error = "Pattern-ul introdus nu este valid.";
                return View(model);
            }
            else
            {
                ViewBag.Error = "";
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Regex regex = new Regex(model.Pattern);

            var forText1 = regex.Match(model.Text1);
            if (forText1.Success)
            {
                model.Matched = "Matched";
            }
            else
            {
                model.Matched = "DisMatched";
            }

            var forText2 = regex.Matches(model.Text2);

            foreach (Match match in forText2)
            {
                if (string.IsNullOrEmpty(model.Matches))
                {
                    model.Matches = match.ToString();
                }
                else
                {
                    model.Matches = model.Matches + ", " + match.ToString();
                }
            }

            return View(model);
        }


        private bool IsValidRegexPattern(string pattern)
        {
            try
            {
                Regex.Match("", pattern);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }
    }
}