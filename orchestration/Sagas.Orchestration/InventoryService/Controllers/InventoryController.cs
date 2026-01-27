using InventoryService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        public Guid HardcodedId { get; set; }
        public InventoryController() 
        {
            HardcodedId = Guid.NewGuid();
        }

        public IActionResult ReserveInventory([FromBody] Order order)
        {
            if(order == null)
            {
                return BadRequest();
            }
            if(order.Id != HardcodedId)
            {
                return BadRequest("Order out of stock");
            }

            Console.WriteLine("Inventory Reserved");
            return Ok();

        }
    }
}
