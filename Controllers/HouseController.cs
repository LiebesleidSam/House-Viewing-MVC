using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HouseViewingMVC.Models;
using HouseViewingMVC.Services.HouseServices;
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
        [ActionName("Details")]
        public async Task<IActionResult> House(int id)
        {
            HouseListItem house = await _service.GetHouseById(id);
            if (house == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(house);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(HouseCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);
            await _service.CreateHouse(model);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id, HouseUpdate model)
        {
            if (!ModelState.IsValid)
                return View(model);
            await _service.UpdateHouse(id, model);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            bool delelteResult = await _service.DeleteHouse(id);
            if (!delelteResult)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}