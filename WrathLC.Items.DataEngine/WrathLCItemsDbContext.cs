using Microsoft.EntityFrameworkCore;
using WrathLC.Items.Data.Entities;

namespace WrathLC.Items.DataEngine;

public class WrathLcItemsDbContext : DbContext
{
    public DbSet<Item> Items { get; set; }
    public DbSet<ItemClass> ItemClasses { get; set; }
    public DbSet<ItemSubClass> ItemSubClasses { get; set; }
    public DbSet<ItemQuality> ItemQualities { get; set; }
    public DbSet<ItemInventorySlot> ItemInventorySlots { get; set; }
    public DbSet<ItemSocket> ItemSockets { get; set; }
    public DbSet<LichKingEquipmentMetadata> LichKingEquipmentMetadata { get; set; }
    public DbSet<Icon> WowheadIcons { get; set; }

    public DbSet<WowClass> WowClasses { get; set; }
    public DbSet<ItemClassRestriction> ItemClassRestrictions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<WowClass>()
            .HasData(WowClassSeed.Classes);
        modelBuilder.Entity<ItemSocket>()
            .HasData(new ItemSocket
            {
                Id = 1,
                Name = "Meta"
            }, new ItemSocket
            {
                Id = 2,
                Name = "Red"
            }, new ItemSocket
            {
                Id = 3,
                Name = "Yellow"
            }, new ItemSocket
            {
                Id = 4,
                Name = "Blue"
            });
        modelBuilder.Entity<Item>()
            .Property(x => x.IconId)
            .HasColumnName("WowheadIconId");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=C:\\Repositories\\WrathLC\\Backend\\WrathLC.Items.DataEngine\\Items.db")
            .EnableSensitiveDataLogging().EnableDetailedErrors();
}