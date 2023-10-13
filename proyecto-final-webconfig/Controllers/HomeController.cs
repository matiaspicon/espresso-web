using Microsoft.AspNetCore.Mvc;
using proyecto_final_webconfig.Data;
using proyecto_final_webconfig.Models;
using proyecto_final_webconfig.Services;
using System.Diagnostics;

namespace proyecto_final_webconfig.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEventsService eventsService;

        public HomeController(ILogger<HomeController> logger, IEventsService eventsService)
        {
            _logger = logger;
            this.eventsService = eventsService;
        }

        public async Task<IActionResult> Index()
        {
            //get all entities from the database events
            var events = await eventsService.GetAllRecentsEvents();

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
    }
}