using Microsoft.AspNetCore.Mvc;

namespace GeneticDams.Controllers
{
    public class ConfigurationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}