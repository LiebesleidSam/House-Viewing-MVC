using HouseViewingMVC.Data;
using HouseViewingMVC.Models.House;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.ObjectPool;

namespace HouseViewingMVC.Services.HouseServices
{
    public class HouseService : IHouseService
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
        public async Task<bool> UpdateHouse(int id, HouseUpdate model)
        {
            House? house = await _context.Houses.FindAsync(id);

            if (house != null)
            {
                house.Beds = model.Beds;
                house.Baths = model.Baths;
                house.Description = model.Description;
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
        public async Task<bool> DeleteHouse(int id)
        {
            House? house = await _context.Houses.FindAsync(id);
            
            if (house != null)
            {
                _context.Houses.Remove(house);
            }
            
            return await _context.SaveChangesAsync() == 1;
        }
    }
}