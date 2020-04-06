// ReSharper disable VirtualMemberCallInConstructor
namespace AnimalShop.Data.Models
{
    using AnimalShop.Data.Common.Models;

    public class FoodOrder : BaseDeletableModel<int>
    {
        public int FoodId { get; set; }

        public Food Food { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}
