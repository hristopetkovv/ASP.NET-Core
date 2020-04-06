namespace AnimalShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using AnimalShop.Data.Common.Models;

    using static DataValidations.DataValidation;

    public class Cart : BaseDeletableModel<int>
    {
        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        [Range(0.0, 1000000000000)]
        public decimal Price { get; set; }

        public double? Weight { get; set; }
    }
}
