using Microsoft.AspNetCore.Mvc;
using OrderService.Enumerations;
using OrderService.Models;
using OrderService.Services;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private OrderRepository _orderRepository {get;set;}
        public OrdersController(OrderRepository orderRepository) 
        { 
            _orderRepository = orderRepository;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetOrders()
        {
            return Ok("hey");
        }

        [HttpPost]
        public async  Task<IActionResult> CreateOrder([FromBody] decimal? price, CancellationToken token)
        {
            //Create order
            var order = new Order
            {
                Id = Guid.NewGuid(),
                Price = price,
                Status = OrderStatus.OrderInitiated
            };
            try
            {
                _orderRepository.CreateOrder(order);

                //process payment
                order.Status = OrderStatus.PaymentProcessed;
                await ProcessPayment(order, token);


                //reserve inventory
                order.Status = OrderStatus.InventoryReserved;
                await ReserveInventory(order);


                //final stage
                order.Status = OrderStatus.OrderCompleted;

                return Ok(order);
            }
            catch (Exception ex)
            {
                //rollback
                await Rollback(order);
                order.Status = OrderStatus.OrderCancelled;
                return BadRequest(ex.Message); 
            }

        }

        private async Task ProcessPayment(Order order, CancellationToken token)
        {
            var http = new HttpClient();
            var response = await http.PostAsJsonAsync("https://localhost:5000/api/Payments", order, token);
            response.EnsureSuccessStatusCode();
            //await Task.CompletedTask;
        }

        private async Task ReserveInventory(Order order)
        {
            await Task.CompletedTask;
        }

        private async Task Rollback(Order order)
        {
            await Task.CompletedTask;
        }
    }
}
