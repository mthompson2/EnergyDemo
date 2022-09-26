using EnergyWebAppGcp.Models;
using EnergyWebAppGcp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EnergyWebAppGcp.Controllers
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
            EnergyService svc = new EnergyService();

            Models.EnergyPriceModel model = new EnergyPriceModel();
            model.Prices = svc.GetPricesForNextDay();

            return View(model);
        }

        public IActionResult SetTime(Models.TimeModel tm)
        {


            return RedirectToAction("Index");
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