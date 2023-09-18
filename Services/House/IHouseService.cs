using HouseViewingMVC.Data;
using HouseViewingMVC.Models.House;

namespace HouseViewingMVC.Services.House
{
    public interface IHouseService
    {
        Task<bool> CreateHouse(HouseCreate model);
        Task<List<HouseListItem>> GetAllHouses();
        Task<HouseDetail> GetHouseById(int id);
        Task<bool> UpdateHouse(HouseUpdate model);
        Task<bool> DeleteHouse(int id);
    }
}