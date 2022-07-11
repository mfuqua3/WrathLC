using GuildView.Idp.Areas.Identity;

[assembly: HostingStartup(typeof(IdentityHostingStartup))]
namespace GuildView.Idp.Areas.Identity
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
