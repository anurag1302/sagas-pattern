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
        public async  Task<IActionResult> CreateOrder([FromBody] decimal? price)
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
                await ProcessPayment(order);


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

        public async Task ProcessPayment(Order order)
        {
            await Task.CompletedTask;
        }

        public async Task ReserveInventory(Order order)
        {
            await Task.CompletedTask;
        }

        public async Task Rollback(Order order)
        {
            await Task.CompletedTask;
        }
    }
}
