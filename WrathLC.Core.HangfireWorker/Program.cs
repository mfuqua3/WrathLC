using Hangfire;
using WrathLC.Utility.Common.Hangfire;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        var connectionString = hostContext.Configuration.GetConnectionString("DefaultConnection");
        services.AddHangfire(cfg => cfg.UseWrathLcConfiguration(connectionString));
        services.AddHangfireServer();
    })
    .Build();

await host.RunAsync();