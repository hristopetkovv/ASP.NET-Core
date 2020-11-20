namespace AnimalShop.Web.ViewModels.Administration.Administration
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AnimalShop.Data.Models.Enums;

    using static AnimalShop.Data.Models.DataValidations.DataValidation;

    public class FoodInputViewModel
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

        [Required]
        [Range(0, 1000000000000)]
        public int Stock { get; set; }

        [Required]
        public AnimalType AnimalType { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
