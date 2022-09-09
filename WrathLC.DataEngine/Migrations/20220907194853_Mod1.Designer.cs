﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WrathLC.DataEngine.Database;

#nullable disable

namespace WrathLC.DataEngine.Migrations
{
    [DbContext(typeof(WrathLcItemsDbContext))]
    [Migration("20220907194853_Mod1")]
    partial class Mod1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.8");

            modelBuilder.Entity("WrathLC.DataEngine.Database.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ItemInventorySlotId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ItemLevel")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ItemQualityId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ItemSubClassId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("LichKingEquipmentMetadataId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("WowheadIconId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ItemInventorySlotId");

                    b.HasIndex("ItemQualityId");

                    b.HasIndex("ItemSubClassId");

                    b.HasIndex("LichKingEquipmentMetadataId");

                    b.HasIndex("WowheadIconId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("WrathLC.DataEngine.Database.ItemClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ItemClasses");
                });

            modelBuilder.Entity("WrathLC.DataEngine.Database.ItemClassRestriction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ItemId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WowClassId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("WowClassId");

                    b.ToTable("ItemClassRestrictions");
                });

            modelBuilder.Entity("WrathLC.DataEngine.Database.ItemInventorySlot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ItemInventorySlots");
                });

            modelBuilder.Entity("WrathLC.DataEngine.Database.ItemQuality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ItemQualities");
                });

            modelBuilder.Entity("WrathLC.DataEngine.Database.ItemSocket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ItemSockets");
                });

            modelBuilder.Entity("WrathLC.DataEngine.Database.ItemSocketBonus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ItemSocketBonuses");
                });

            modelBuilder.Entity("WrathLC.DataEngine.Database.ItemSubClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ItemClassId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ItemClassId");

                    b.ToTable("ItemSubClasses");
                });

            modelBuilder.Entity("WrathLC.DataEngine.Database.LichKingEquipmentMetadata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Agility")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Armor")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CriticalStrikeRating")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DefenseRating")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DodgeRating")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Durability")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ExpertiseRating")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("HasteRating")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Healing")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("HitRating")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Intellect")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("LevelRequirement")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ManaRegen")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MeleeAttackPower")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ParryRating")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RangedAttackPower")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Socket1Id")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Socket2Id")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Socket3Id")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Socket4Id")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SocketBonusId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SocketCount")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SpellDamage")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Spirit")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Stamina")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Strength")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("VendorPrice")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("WeaponDamageMaximum")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("WeaponDamageMinimum")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("WeaponDps")
                        .HasColumnType("REAL");

                    b.Property<double?>("WeaponSpeed")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("LichKingEquipmentMetadata");
                });

            modelBuilder.Entity("WrathLC.DataEngine.Database.WowClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("WowheadFlagEnumId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("WowClasses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Warrior",
                            WowheadFlagEnumId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Paladin",
                            WowheadFlagEnumId = 2
                        },
                        new
                        {
                            Id = 3,
                            Name = "Hunter",
                            WowheadFlagEnumId = 4
                        },
                        new
                        {
                            Id = 4,
                            Name = "Rogue",
                            WowheadFlagEnumId = 8
                        },
                        new
                        {
                            Id = 5,
                            Name = "Priest",
                            WowheadFlagEnumId = 16
                        },
                        new
                        {
                            Id = 6,
                            Name = "Death Knight",
                            WowheadFlagEnumId = 32
                        },
                        new
                        {
                            Id = 7,
                            Name = "Shaman",
                            WowheadFlagEnumId = 64
                        },
                        new
                        {
                            Id = 8,
                            Name = "Mage",
                            WowheadFlagEnumId = 128
                        },
                        new
                        {
                            Id = 9,
                            Name = "Warlock",
                            WowheadFlagEnumId = 256
                        },
                        new
                        {
                            Id = 10,
                            Name = "Druid",
                            WowheadFlagEnumId = 1024
                        });
                });

            modelBuilder.Entity("WrathLC.DataEngine.Database.WowheadIcon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("WowheadIcons");
                });

            modelBuilder.Entity("WrathLC.DataEngine.Database.Item", b =>
                {
                    b.HasOne("WrathLC.DataEngine.Database.ItemInventorySlot", "ItemInventorySlot")
                        .WithMany("Items")
                        .HasForeignKey("ItemInventorySlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WrathLC.DataEngine.Database.ItemQuality", "ItemQuality")
                        .WithMany("Items")
                        .HasForeignKey("ItemQualityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WrathLC.DataEngine.Database.ItemSubClass", "ItemSubClass")
                        .WithMany("Items")
                        .HasForeignKey("ItemSubClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WrathLC.DataEngine.Database.LichKingEquipmentMetadata", "LichKingEquipmentMetadata")
                        .WithMany()
                        .HasForeignKey("LichKingEquipmentMetadataId");

                    b.HasOne("WrathLC.DataEngine.Database.WowheadIcon", "WowheadIcon")
                        .WithMany("Items")
                        .HasForeignKey("WowheadIconId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemInventorySlot");

                    b.Navigation("ItemQuality");

                    b.Navigation("ItemSubClass");

                    b.Navigation("LichKingEquipmentMetadata");

                    b.Navigation("WowheadIcon");
                });

            modelBuilder.Entity("WrathLC.DataEngine.Database.ItemClassRestriction", b =>
                {
                    b.HasOne("WrathLC.DataEngine.Database.Item", "Item")
                        .WithMany("ClassRestrictions")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WrathLC.DataEngine.Database.WowClass", "WowClass")
                        .WithMany()
                        .HasForeignKey("WowClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("WowClass");
                });

            modelBuilder.Entity("WrathLC.DataEngine.Database.ItemSubClass", b =>
                {
                    b.HasOne("WrathLC.DataEngine.Database.ItemClass", "ItemClass")
                        .WithMany("ItemSubClasses")
                        .HasForeignKey("ItemClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemClass");
                });

            modelBuilder.Entity("WrathLC.DataEngine.Database.Item", b =>
                {
                    b.Navigation("ClassRestrictions");
                });

            modelBuilder.Entity("WrathLC.DataEngine.Database.ItemClass", b =>
                {
                    b.Navigation("ItemSubClasses");
                });

            modelBuilder.Entity("WrathLC.DataEngine.Database.ItemInventorySlot", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("WrathLC.DataEngine.Database.ItemQuality", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("WrathLC.DataEngine.Database.ItemSubClass", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("WrathLC.DataEngine.Database.WowheadIcon", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
