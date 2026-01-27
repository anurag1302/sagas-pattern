using Microsoft.AspNetCore.Mvc;
using PaymentService.Models;

namespace PaymentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    { 
        public PaymentsController() { }

        [HttpPost]
        public  IActionResult ProcessPayment([FromBody] Order order, CancellationToken token)
        {
            if(order == null)
            {
                return BadRequest();
            }
            if(order.Price.HasValue && order.Price.Value > 1000)
            {
                return BadRequest("Payment Failed");
            }

            Console.WriteLine("Payment has been processed");
            return Ok();

        }
    }
}
