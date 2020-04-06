// ReSharper disable VirtualMemberCallInConstructor
namespace AnimalShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AnimalShop.Data.Common.Models;
    using AnimalShop.Data.Models.Enums;

    using static DataValidations.DataValidation;

    public class Product : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [Range(0.0, 1000000000000)]
        public decimal Price { get; set; }

        [Required]
        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public virtual ICollection<ProductOrder> Orders { get; set; } = new HashSet<ProductOrder>();

        public AnimalType AnimalType { get; set; }

        public ProductCategory Category { get; set; }

        [Required]
        [Range(0, 100000)]
        public int Stock { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
