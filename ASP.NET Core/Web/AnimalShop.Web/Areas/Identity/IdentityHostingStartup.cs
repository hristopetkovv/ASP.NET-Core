using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(AnimalShop.Web.Areas.Identity.IdentityHostingStartup))]

namespace AnimalShop.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}