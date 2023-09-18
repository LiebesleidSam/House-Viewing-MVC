using HouseViewingMVC.Data;
using HouseViewingMVC.Models.House;
using Microsoft.EntityFrameworkCore;

namespace HouseViewingMVC.Services.House
{
    public class HouseService
    {
        private HouseViewingDbContext _context;
        public HouseService(HouseViewingDbContext context)
        {
            _context = context;
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