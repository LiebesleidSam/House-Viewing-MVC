using HouseViewingMVC.Data;
using HouseViewingMVC.Models.House;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.ObjectPool;

namespace HouseViewingMVC.Services.HouseServices
{
    public class HouseService
    {
        private HouseViewingDbContext _context;
        public HouseService(HouseViewingDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateHouse(HouseCreate model)
        {
            House house = new House()
            {
                Beds = model.Beds,
                Baths = model.Baths,
                Description = model.Description,
                ListingDate = model.ListingDate
            };

            _context.Houses.Add(house);

            return await _context.SaveChangesAsync() == 1;
        }
        public async Task<List<HouseListItem>> GetAllHouses()
        {
            List<HouseListItem> houses = new();

            foreach(var house in _context.Houses)
            {
                houses.Add(new HouseListItem(){
                    Id = house.Id,
                    Beds = house.Beds,
                    Baths = house.Baths,
                    Description = house.Description,
                    ListingDate = house.ListingDate
                });
            }

            return houses;
        }
        public async Task<HouseListItem> GetHouseById(int id)
        {
            HouseListItem target = new();

            foreach(var house in _context.Houses)
            {
                if(house.Id == id)
                {
                    target.Id = house.Id;
                    target.Beds = house.Beds;
                    target.Baths = house.Baths;
                    target.Description = house.Description;
                    target.ListingDate = house.ListingDate;
                }
            }

            return target;
        }
        public async Task<bool> UpdateHouse(HouseUpdate model)
        {
            House target;

            foreach(var house in _context.Houses)
            {
                if(house.Id == model.Id)
                {
                    target = house;
                    target.Beds = model.Beds;
                    target.Baths = model.Baths;
                    target.Description = model.Description;
                    target.ListingDate = model.ListingDate;
                    return true;
                }
            }
            return false;
        }
        public async Task<bool> DeleteHouse(int id)
        {
            foreach(var house in _context.Houses)
            {
                if(house.Id == id)
                {
                    _context.Houses.Remove(house);
                }
            }
            return await _context.SaveChangesAsync() == 1;
        }
    }
}