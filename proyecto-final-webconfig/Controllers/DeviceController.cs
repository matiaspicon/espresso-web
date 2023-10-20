using Microsoft.AspNetCore.Mvc;
using proyecto_final_webconfig.Data;
using proyecto_final_webconfig.Models;
using proyecto_final_webconfig.Services;
using System.Diagnostics;

namespace proyecto_final_webconfig.Controllers
{
    public class DeviceController : Controller
    {
        private readonly ILogger<DeviceController> _logger;
        private readonly IDevicesService DevicesService;

        public DeviceController(ILogger<DeviceController> logger, IDevicesService DevicesService)
        {
            _logger = logger;
            this.DevicesService = DevicesService;
        }

        public async Task<IActionResult> Index()
        {
            //get all entities from the database Devices
            var Devices = await DevicesService.GetAllDevices();

            return View(Devices);
        }
        public async Task<IActionResult> Details(int id)
        {
            //get all entities from the database Devices
            var singleDevice = await DevicesService.GetDeviceByID(id);

            return View(singleDevice);
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