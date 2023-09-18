using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HouseViewingMVC.Models;
using HouseViewingMVC.Services.House;
using HouseViewingMVC.Models.House;

namespace HouseViewingMVC.Controllers
{
    public class HouseController : Controller
    {
        private IHouseService _service;
        public HouseController(IHouseService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            List<HouseListItem> houses = await _service.GetAllHouses();
            return View(houses);
        }
    }
}