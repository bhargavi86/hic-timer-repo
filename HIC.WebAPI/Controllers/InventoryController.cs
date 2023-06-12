using HIC.WebAPI.Domain.Models;
using HIC.WebAPI.Services.InventoryService;
using Microsoft.AspNetCore.Mvc;

namespace HIC.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;
        private readonly IInventoryService _inventoryService;

        public InventoryController(ILogger<InventoryController> logger, IInventoryService inventoryService)
        {
            _logger = logger;
            _inventoryService = inventoryService;
        }

        [HttpGet]
        public IEnumerable<InventoryBO> GetAll()
        {
            return _inventoryService.GetAllInventory();
        }

        [HttpGet("{id}")]
        public InventoryBO? Get(int id)
        {
            return _inventoryService.GetInventory(id);
        }

        [HttpPut("{id}")]
        public void Put(int id)
        {
            _inventoryService.IncrementCount(id);
        }
    }
}
