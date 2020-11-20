namespace AnimalShop.Web.Controllers
{
    using System.Threading.Tasks;

    using AnimalShop.Common;
    using AnimalShop.Data.Common.Repositories;
    using AnimalShop.Data.Models;
    using AnimalShop.Services.Messaging;
    using AnimalShop.Web.ViewModels.Contacts;
    using Microsoft.AspNetCore.Mvc;

    public class ContactsController : Controller
    {
        private readonly IRepository<ContactForm> contactsRepository;
        private readonly IEmailSender emailSender;

        public ContactsController(IRepository<ContactForm> contactsRepository, IEmailSender emailSender)
        {
            this.contactsRepository = contactsRepository;
            this.emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactsFormViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var contactFormInput = new ContactForm
            {
                Name = input.Name,
                Email = input.Email,
                Title = input.Title,
                Content = input.Content,
            };

            await this.contactsRepository.AddAsync(contactFormInput);
            await this.contactsRepository.SaveChangesAsync();

            await this.emailSender.SendEmailAsync(
                input.Email,
                input.Name,
                GlobalConstants.SystemEmail,
                input.Title,
                input.Content);

            return this.RedirectToAction("SuccessfulMessage");
        }

        public IActionResult SuccessfulMessage()
        {
            return this.View();
        }
    }
}
