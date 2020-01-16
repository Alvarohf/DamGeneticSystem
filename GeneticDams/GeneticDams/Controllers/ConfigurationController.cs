using Microsoft.AspNetCore.Mvc;

namespace GeneticDams.Controllers
{
    /// <summary>
    /// Class for configuration controller
    /// </summary>
    public class ConfigurationController : Controller
    {
        /// <summary>
        /// Returns the view for configuration
        /// </summary>
        /// <returns>View for configuration</returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}