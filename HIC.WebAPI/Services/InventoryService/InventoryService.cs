using HIC.WebAPI.Domain.Models;
using HIC.WebAPI.DataAccess.Repositories.Inventory;
using HIC.WebAPI.DataAccess;

namespace HIC.WebAPI.Services.InventoryService
{
    public class InventoryService : IInventoryService
    {
        private IInventoryRepository _inventoryRespository;

        public InventoryService(IInventoryRepository inventoryRepository)
        {
            _inventoryRespository = inventoryRepository;
        }

        public List<InventoryBO> GetAllInventory()
        {
            var allInventory = _inventoryRespository.GetAllInventory();
            if(allInventory == null)
            {
                allInventory = new List<InventoryBO>();
            }
            return allInventory;      
        }

        public InventoryBO? GetInventory(int id)
        {
            return _inventoryRespository.GetInventory(id);
        }

        public void IncrementCount(int id)
        {
            var inventoryItem = _inventoryRespository.GetInventory(id);
            if (inventoryItem != null)
            {
                inventoryItem.Count++;
                _inventoryRespository.SaveInventory(inventoryItem);
            }
        }
    }
}
