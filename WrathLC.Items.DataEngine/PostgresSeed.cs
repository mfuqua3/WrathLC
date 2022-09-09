using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WrathLC.Core.Business.DependencyInjection;
using WrathLc.Core.ResourceAccess;
using WrathLC.Items.Data;
using WrathLC.Items.Data.Entities;

namespace WrathLC.Items.DataEngine;

public class PostgresSeed
{
    public async Task RunAsync()
    {
        var services = new ServiceCollection();
        var config = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string>
            {
                {"ConnectionStrings:DefaultConnection", ""}
            })
            .Build();
        services.AddCore(config);
        var provider = services.BuildServiceProvider();
        var context = provider.GetRequiredService<WrathLcDbContext>();
        await SeedAsync(context);
    }

    private async Task SeedAsync(WrathLcDbContext context)
    {
        var dataSource = new WrathLcItemsDbContext();
         await CopyAsync<ItemClass>(dataSource, context);
         await CopyAsync<ItemSubClass>(dataSource, context);
         await CopyAsync<ItemQuality>(dataSource, context);
         await CopyAsync<ItemInventorySlot>(dataSource, context);
         await CopyAsync<Icon>(dataSource, context);
         await CopyAsync<LichKingEquipmentMetadata>(dataSource, context);
         await CopyAsync<Item>(dataSource, context);
         await CopyAsync<ItemClassRestriction>(dataSource, context);
        var schema = await context.Set<ItemSchema>().SingleAsync(x => x.Version == 1);
        schema.SeedDate = DateTime.UtcNow;
        await context.SaveChangesAsync();
    }

    private async Task CopyAsync<T>(WrathLcItemsDbContext from, WrathLcDbContext to) where T : class
    {
        Console.WriteLine($"Copying {typeof(T).Name} entities...");
        await to.BulkInsertAsync(await from.Set<T>().ToListAsync());
        await to.SaveChangesAsync();
        Console.WriteLine("Done.");
    }
}