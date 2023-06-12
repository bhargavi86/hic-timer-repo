using HIC.WebAPI.Domain.Models;

namespace HIC.WebAPI.Services.InventoryService
{
    public interface IInventoryService
    {
        List<InventoryBO> GetAllInventory();

        InventoryBO? GetInventory(int id);

        void IncrementCount(int id);
    }
}
