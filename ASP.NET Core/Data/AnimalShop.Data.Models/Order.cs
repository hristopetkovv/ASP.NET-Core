// ReSharper disable VirtualMemberCallInConstructor
namespace AnimalShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AnimalShop.Data.Common.Models;
    using AnimalShop.Data.Models.Enums;

    public class Order : BaseDeletableModel<int>
    {
        public OrderStatus Status { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public virtual ICollection<FoodOrder> Food { get; set; } = new HashSet<FoodOrder>();

        public virtual ICollection<ProductOrder> Products { get; set; } = new HashSet<ProductOrder>();
    }
}