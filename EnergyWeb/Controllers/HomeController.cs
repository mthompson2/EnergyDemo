using EnergyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EnergyWeb.Controllers
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

            DataCollectorService svc = new DataCollectorService();
            Models.ExportPriceModel model = new ExportPriceModel();
            model.Pricing = svc.GetAgilePrices();


            return View(model);
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
    }
}