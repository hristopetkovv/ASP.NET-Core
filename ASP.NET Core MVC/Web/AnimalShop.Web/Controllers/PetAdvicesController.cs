namespace AnimalShop.Web.Controllers
{
    using AnimalShop.Data.Models.Enums;
    using AnimalShop.Services.Data;
    using AnimalShop.Web.ViewModels.PetAdvices;
    using Microsoft.AspNetCore.Mvc;

    public class PetAdvicesController : Controller
    {
        private readonly IPetAdvicesService petAdvicesService;

        public PetAdvicesController(IPetAdvicesService petAdvicesService)
        {
            this.petAdvicesService = petAdvicesService;
        }

        public IActionResult Dog()
        {
            AnimalType animalType = AnimalType.Dog;

            var viewModel = new PetAdviceListingViewModel
            {
                PetAdvices = this.petAdvicesService.GetAll<PetAdviceViewModel>(animalType),
            };

            return this.View(viewModel);
        }

        public IActionResult Cat()
        {
            AnimalType animalType = AnimalType.Cat;

            var viewModel = new PetAdviceListingViewModel
            {
                PetAdvices = this.petAdvicesService.GetAll<PetAdviceViewModel>(animalType),
            };

            return this.View(viewModel);
        }

        public IActionResult Bird()
        {
            AnimalType animalType = AnimalType.Birds;

            var viewModel = new PetAdviceListingViewModel
            {
                PetAdvices = this.petAdvicesService.GetAll<PetAdviceViewModel>(animalType),
            };

            return this.View(viewModel);
        }

        public IActionResult Fish()
        {
            AnimalType animalType = AnimalType.Fish;

            var viewModel = new PetAdviceListingViewModel
            {
                PetAdvices = this.petAdvicesService.GetAll<PetAdviceViewModel>(animalType),
            };

            return this.View(viewModel);
        }

        public IActionResult SmallPet()
        {
            AnimalType animalType = AnimalType.SmallPets;

            var viewModel = new PetAdviceListingViewModel
            {
                PetAdvices = this.petAdvicesService.GetAll<PetAdviceViewModel>(animalType),
            };

            return this.View(viewModel);
        }
    }
}
