namespace AnimalShop.Services.Data
{
    using System.Collections.Generic;

    using AnimalShop.Data.Models.Enums;

    public interface IPetAdvicesService
    {
        IEnumerable<T> GetAll<T>(AnimalType animalType);
    }
}
