﻿using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WrathLC.Data.Common;
using WrathLC.Data.Common.Extensions;

namespace WrathLC.Identity.Data;

public class WrathLcIdentityDbContext : IdentityDbContext<WrathLcUser>
{
    public WrathLcIdentityDbContext(DbContextOptions<WrathLcIdentityDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("identity");
        builder.UseOpenIddict();
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        builder.ApplySoftDeleteQueryFilters();
    }


    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
        CancellationToken cancellationToken = new())
    {
        this.ProcessCustomInterfaces();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
}