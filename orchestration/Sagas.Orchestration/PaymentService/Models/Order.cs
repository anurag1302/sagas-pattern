namespace PaymentService.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public decimal? Price { get; set; }
        public OrderStatus Status { get; set; }
    }

    public enum OrderStatus
    {
        OrderInitiated,
        PaymentProcessed,
        InventoryReserved,
        OrderCompleted,
        OrderCancelled
    }
}
