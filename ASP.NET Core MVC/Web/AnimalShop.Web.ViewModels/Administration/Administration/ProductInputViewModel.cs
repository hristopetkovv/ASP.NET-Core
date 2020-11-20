namespace AnimalShop.Web.ViewModels.Administration.Administration
{
    using System.ComponentModel.DataAnnotations;

    using AnimalShop.Data.Models.Enums;

    using static AnimalShop.Data.Models.DataValidations.DataValidation;

    public class ProductInputViewModel
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

        [Required]
        public AnimalType AnimalType { get; set; }

        [Required]
        public ProductCategory Category { get; set; }

        [Required]
        [Range(0, 100000)]
        public int Stock { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
