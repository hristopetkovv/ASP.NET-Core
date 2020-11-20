namespace AnimalShop.Web.ViewModels.Orders
{
    using AnimalShop.Data.Models;
    using AnimalShop.Services.Mapping;

    public class OrderViewModel : IMapFrom<Order>
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public OrderStatus Status { get; set; }
    }
}
