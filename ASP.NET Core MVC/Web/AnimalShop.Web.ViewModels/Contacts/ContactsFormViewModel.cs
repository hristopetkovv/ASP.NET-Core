namespace AnimalShop.Web.ViewModels.Contacts
{
    using System.ComponentModel.DataAnnotations;

    public class ContactsFormViewModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Your names")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Your email address")]
        public string Email { get; set; }

        [Required]
        [StringLength(5000)]
        [Display(Name = "Message")]
        public string Content { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Title name")]
        public string Title { get; set; }
    }
}
