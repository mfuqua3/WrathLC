using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WrathLC.Items.Data.Entities;

namespace WrathLC.Items.Data.EntityConfigurations;

internal class IconConfiguration : EntityTypeConfiguration<Icon>
{
    protected override string TableName => "Icons";
}