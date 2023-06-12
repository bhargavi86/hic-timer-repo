using HIC.WebAPI.Domain.Models;

namespace HIC.WebAPI.DataAccess.Repositories.Inventory
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly InventoryContext _inventoryContext;

        public InventoryRepository(InventoryContext inventoryContext)
        {
            _inventoryContext = inventoryContext;
        }

        public List<InventoryBO>? GetAllInventory()
        {
            return _inventoryContext.InventoryItems.ToList();
        }

        public InventoryBO? GetInventory(int id)
        {
            return _inventoryContext.InventoryItems.Find(id);              
        }

        public void SaveInventory(InventoryBO inventory)
        {
            var inventoryExists = _inventoryContext.InventoryItems.FirstOrDefault(x => x.Id == inventory.Id);
            if(inventoryExists != null)
            {
                _inventoryContext.InventoryItems.Update(inventory);
            }
            else
            {
                _inventoryContext.InventoryItems.Add(inventory);
            }
            
            _inventoryContext.SaveChanges();
        }
    }
}
