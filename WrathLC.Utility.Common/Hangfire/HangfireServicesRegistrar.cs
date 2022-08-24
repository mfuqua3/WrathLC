using Hangfire;
using Hangfire.PostgreSql;

namespace WrathLc.Common.Utilities.Hangfire;

public static class HangfireServicesRegistrar
{
    public static void UseWrathLcConfiguration(this IGlobalConfiguration hangfireConfig, string connectionString)
    {
        hangfireConfig.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UsePostgreSqlStorage(connectionString);
    }
}