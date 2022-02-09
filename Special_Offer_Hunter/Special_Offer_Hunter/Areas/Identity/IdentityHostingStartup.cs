using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Special_Offer_Hunter.Areas.Identity.IdentityHostingStartup))]
namespace Special_Offer_Hunter.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}