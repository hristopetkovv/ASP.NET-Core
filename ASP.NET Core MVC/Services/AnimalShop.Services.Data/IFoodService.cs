namespace AnimalShop.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AnimalShop.Data.Models.Enums;

    public interface IFoodService
    {
        IEnumerable<T> GetFood<T>(AnimalType animalType, int? take = null, int skip = 0);

        int GetFoodCount(AnimalType animalType);

        T GetById<T>(int id);

        Task AddToCartAsync(int foodId, string userId);
    }
}
