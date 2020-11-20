namespace AnimalShop.Web.ViewModels.Food
{
    using System;
    using System.Linq;

    using AnimalShop.Data.Models;
    using AnimalShop.Data.Models.Enums;
    using AnimalShop.Services.Mapping;
    using AutoMapper;

    public class FoodViewModel : IMapFrom<Food>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Weight { get; set; }

        public decimal Price { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int Stock { get; set; }

        public AnimalType AnimalType { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public int VotesCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Food, FoodViewModel>()
                .ForMember(x => x.VotesCount, options =>
                {
                    options.MapFrom(p => p.Votes.Sum(v => (int)v.Type));
                });
        }
    }
}
