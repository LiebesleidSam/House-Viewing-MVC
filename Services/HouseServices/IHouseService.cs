using HouseViewingMVC.Data;
using HouseViewingMVC.Models.House;

namespace HouseViewingMVC.Services.HouseServices
{
    public interface IHouseService
    {
        Task<bool> CreateHouse(HouseCreate model);
        Task<List<HouseListItem>> GetAllHouses();
        Task<HouseListItem> GetHouseById(int id);
        Task<bool> UpdateHouse(int id, HouseUpdate model);
        Task<bool> DeleteHouse(int id);
    }
}