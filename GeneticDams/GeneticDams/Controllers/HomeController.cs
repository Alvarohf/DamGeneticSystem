using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GeneticDams.Models;
using System.IO;
using GeneticDams.BLL;

namespace GeneticDams.Controllers
{
    public class HomeController : Controller
    {
        private static readonly DownloadProxy Proxy = new DownloadProxy(new DownloadServer());

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
        public IActionResult Download(string fileName, bool login)
        {
            // We geth the path
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
            // Download the file with Proxy, that counts downloads as smart reference
            FileContentResult file = Proxy.DownloadFile(filePath, login);
            if (file != null)
            {
                int a = Proxy.Count();
                System.Diagnostics.Debug.WriteLine(a);
                return file;
            } else
            {
                ViewData["Error"] = "Error";
                return View("Index","Home");
            }
        }
    }
}
