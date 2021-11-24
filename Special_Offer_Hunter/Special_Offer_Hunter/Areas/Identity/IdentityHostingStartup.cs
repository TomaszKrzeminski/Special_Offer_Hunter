using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Special_Offer_Hunter.Data;
using Special_Offer_Hunter.Models;

[assembly: HostingStartup(typeof(Special_Offer_Hunter.Areas.Identity.IdentityHostingStartup))]
namespace Special_Offer_Hunter.Areas.Identity
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