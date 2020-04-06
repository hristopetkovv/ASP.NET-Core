// ReSharper disable VirtualMemberCallInConstructor
namespace AnimalShop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AnimalShop.Data.Common.Models;
    using AnimalShop.Data.Models.Enums;

    using static DataValidations.DataValidation;

    public class Food : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [Range(0.0, 1000000000000)]
        public double Weight { get; set; }

        [Required]
        [Range(0.0, 1000000000000)]
        public decimal Price { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        [Required]
        [Range(0, 1000000000000)]
        public int Stock { get; set; }

        public AnimalType AnimalType { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public string Image { get; set; }

        public virtual ICollection<FoodOrder> Orders { get; set; } = new HashSet<FoodOrder>();

        public virtual ICollection<Vote> Votes { get; set; } = new HashSet<Vote>();
    }
}
