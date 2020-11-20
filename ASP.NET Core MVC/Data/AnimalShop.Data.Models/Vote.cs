namespace AnimalShop.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using AnimalShop.Data.Common.Models;
    using AnimalShop.Data.Models.Enums;

    public class Vote : BaseModel<int>
    {
        public int FoodId { get; set; }

        public virtual Food Food { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public VoteType Type { get; set; }
    }
}
