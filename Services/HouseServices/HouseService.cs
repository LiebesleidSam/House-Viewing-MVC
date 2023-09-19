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
    }
}