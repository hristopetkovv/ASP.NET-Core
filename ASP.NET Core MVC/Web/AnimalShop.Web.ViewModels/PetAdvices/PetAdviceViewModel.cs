namespace AnimalShop.Web.ViewModels.PetAdvices
{
    using AnimalShop.Data.Models;
    using AnimalShop.Data.Models.Enums;
    using AnimalShop.Services.Mapping;

    public class PetAdviceViewModel : IMapFrom<PetAdvice>
    {
        public string Description { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

        public string Url { get; set; }

        public AnimalType AnimalType { get; set; }
    }
}
