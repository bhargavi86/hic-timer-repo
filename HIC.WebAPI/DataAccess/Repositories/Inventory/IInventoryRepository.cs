using HIC.WebAPI.Domain.Models;

namespace HIC.WebAPI.DataAccess.Repositories.Inventory
{
    public interface IInventoryRepository
    {
        List<InventoryBO>? GetAllInventory();

        InventoryBO? GetInventory(int id);

        void SaveInventory(InventoryBO inventory);
    }
}
