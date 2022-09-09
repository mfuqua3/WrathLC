using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WrathLC.Utility.Common.DataContracts.Interfaces;

namespace WrathLC.Items.Data.EntityConfigurations;

internal abstract class EntityTypeConfiguration<T>: IEntityTypeConfiguration<T> where T : class, IUnique<int>, INamed
{
    protected abstract string TableName { get; }
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.ToTable(TableName, DataConstants.SchemaName);
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.HasIndex(x => x.Name);
    }
}