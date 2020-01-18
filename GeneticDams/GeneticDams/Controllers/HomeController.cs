using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GeneticDams.Models;
using System.IO;
using GeneticDams.BLL;

namespace GeneticDams.Controllers
{
    /// <summary>
    /// Controller for the class Home
    /// </summary>
    public class HomeController : Controller
    {
        // Proxy for the downloads
        private static readonly IDownload Proxy = new DownloadProxy(new DownloadServer());

        /// <summary>
        /// Return the main view
        /// </summary>
        /// <returns>View with the map</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Return the view with privacy options
        /// </summary>
        /// <returns>View with privacy options</returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Send the view in case of error
        /// </summary>
        /// <returns>Error view</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        /// <summary>
        /// Download the file given by parameter
        /// </summary>
        /// <param name="fileName">Name of the file to download</param>
        /// <param name="login">Boolean to check if user is logged</param>
        /// <returns></returns>
        public IActionResult Download(string fileName, bool login)
        {
            // We geth the path
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
            // Download the file with Proxy, that counts downloads as smart reference
            FileContentResult file = Proxy.DownloadFile(filePath, login);
            if (file != null)
            {
                return file;
            } else
            {
                ViewData["Error"] = "Error";
                return View("Index","Home");
            }
        }
    }
}
