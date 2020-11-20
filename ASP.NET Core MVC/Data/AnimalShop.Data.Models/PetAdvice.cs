namespace AnimalShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using AnimalShop.Data.Common.Models;
    using AnimalShop.Data.Models.Enums;

    using static DataValidations.DataValidation;

    public class PetAdvice : BaseModel<int>
    {
        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Url { get; set; }

        public AnimalType AnimalType { get; set; }
    }
}
