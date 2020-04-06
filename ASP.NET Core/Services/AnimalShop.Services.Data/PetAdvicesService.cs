namespace AnimalShop.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using AnimalShop.Data.Common.Repositories;
    using AnimalShop.Data.Models;
    using AnimalShop.Data.Models.Enums;
    using AnimalShop.Services.Mapping;

    public class PetAdvicesService : IPetAdvicesService
    {
        private readonly IRepository<PetAdvice> petAdviceRepository;

        public PetAdvicesService(IRepository<PetAdvice> petAdviceRepository)
        {
            this.petAdviceRepository = petAdviceRepository;
        }

        public IEnumerable<T> GetAll<T>(AnimalType animalType)
        {
            IQueryable<PetAdvice> query = this.petAdviceRepository.All().Where(x => x.AnimalType == animalType);

            return query.To<T>().ToList();
        }
    }
}
