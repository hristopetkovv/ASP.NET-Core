namespace AnimalShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using AnimalShop.Data.Common.Models;

    using static DataValidations.DataValidation;

    public class ContactForm : BaseModel<int>
    {
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Content { get; set; }

        [Required]
        [MaxLength(25)]
        public string Title { get; set; }
    }
}
