﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WrathLc.Core.ResourceAccess;

#nullable disable

namespace WrathLc.Core.ResourceAccess.Migrations
{
    [DbContext(typeof(WrathLcDbContext))]
    [Migration("20220909174654_Add_Items_Schema")]
    partial class Add_Items_Schema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WrathLc.Core.ResourceAccess.Entities.DiscordServer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("ServerId")
                        .HasColumnType("numeric(20,0)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ServerId")
                        .IsUnique();

                    b.ToTable("DiscordServers");
                });

            modelBuilder.Entity("WrathLc.Core.ResourceAccess.Entities.DiscordServerUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DiscordServerId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DiscordServerId");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("UserId");

                    NpgsqlIndexBuilderExtensions.HasMethod(b.HasIndex("UserId"), "hash");

                    b.ToTable("DiscordServerUsers");
                });

            modelBuilder.Entity("WrathLc.Core.ResourceAccess.Entities.Guild", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DiscordServerId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DiscordServerId")
                        .IsUnique();

                    b.HasIndex("IsDeleted");

                    b.ToTable("Guilds");
                });

            modelBuilder.Entity("WrathLc.Core.ResourceAccess.Entities.GuildUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("GuildId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GuildId");

                    b.HasIndex("IsDeleted");

                    b.HasIndex("UserId");

                    NpgsqlIndexBuilderExtensions.HasMethod(b.HasIndex("UserId"), "hash");

                    b.ToTable("GuildUsers");
                });

            modelBuilder.Entity("WrathLC.Items.Data.Entities.Icon", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Icons", "items");
                });

            modelBuilder.Entity("WrathLC.Items.Data.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int>("IconId")
                        .HasColumnType("integer");

                    b.Property<int>("ItemInventorySlotId")
                        .HasColumnType("integer");

                    b.Property<int>("ItemLevel")
                        .HasColumnType("integer");

                    b.Property<int>("ItemQualityId")
                        .HasColumnType("integer");

                    b.Property<int>("ItemSubClassId")
                        .HasColumnType("integer");

                    b.Property<int?>("LichKingEquipmentMetadataId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IconId");

                    b.HasIndex("ItemInventorySlotId");

                    b.HasIndex("ItemQualityId");

                    b.HasIndex("ItemSubClassId");

                    b.HasIndex("LichKingEquipmentMetadataId")
                        .IsUnique();

                    b.HasIndex("Name");

                    b.ToTable("Items", "items");
                });

            modelBuilder.Entity("WrathLC.Items.Data.Entities.ItemClass", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("ItemClasses", "items");
                });

            modelBuilder.Entity("WrathLC.Items.Data.Entities.ItemClassRestriction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ItemId")
                        .HasColumnType("integer");

                    b.Property<int>("WowClassId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("WowClassId");

                    b.ToTable("ItemClassRestrictions", "items");
                });

            modelBuilder.Entity("WrathLC.Items.Data.Entities.ItemInventorySlot", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("ItemInventorySlots", "items");
                });

            modelBuilder.Entity("WrathLC.Items.Data.Entities.ItemQuality", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("ItemQualities", "items");
                });

            modelBuilder.Entity("WrathLC.Items.Data.Entities.ItemSchema", b =>
                {
                    b.Property<int>("Version")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Version"));

                    b.Property<DateTime?>("SeedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("SeedName")
                        .HasColumnType("text");

                    b.HasKey("Version");

                    b.ToTable("schema", "items");

                    b.HasData(
                        new
                        {
                            Version = 1,
                            SeedName = "Initial v1.0"
                        });
                });

            modelBuilder.Entity("WrathLC.Items.Data.Entities.ItemSocket", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("ItemSockets", "items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Meta"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Red"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Yellow"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Blue"
                        });
                });

            modelBuilder.Entity("WrathLC.Items.Data.Entities.ItemSubClass", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int>("ItemClassId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ItemClassId");

                    b.HasIndex("Name");

                    b.ToTable("ItemSubClasses", "items");
                });

            modelBuilder.Entity("WrathLC.Items.Data.Entities.LichKingEquipmentMetadata", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int?>("Agility")
                        .HasColumnType("integer");

                    b.Property<int?>("Armor")
                        .HasColumnType("integer");

                    b.Property<int?>("CriticalStrikeRating")
                        .HasColumnType("integer");

                    b.Property<int?>("DefenseRating")
                        .HasColumnType("integer");

                    b.Property<int?>("DodgeRating")
                        .HasColumnType("integer");

                    b.Property<int?>("Durability")
                        .HasColumnType("integer");

                    b.Property<int?>("ExpertiseRating")
                        .HasColumnType("integer");

                    b.Property<int?>("HasteRating")
                        .HasColumnType("integer");

                    b.Property<int?>("Healing")
                        .HasColumnType("integer");

                    b.Property<int?>("HitRating")
                        .HasColumnType("integer");

                    b.Property<int?>("Intellect")
                        .HasColumnType("integer");

                    b.Property<int?>("LevelRequirement")
                        .HasColumnType("integer");

                    b.Property<int?>("ManaRegen")
                        .HasColumnType("integer");

                    b.Property<int?>("MeleeAttackPower")
                        .HasColumnType("integer");

                    b.Property<int?>("ParryRating")
                        .HasColumnType("integer");

                    b.Property<int?>("RangedAttackPower")
                        .HasColumnType("integer");

                    b.Property<int?>("Socket1Id")
                        .HasColumnType("integer");

                    b.Property<int?>("Socket2Id")
                        .HasColumnType("integer");

                    b.Property<int?>("Socket3Id")
                        .HasColumnType("integer");

                    b.Property<int?>("SocketBonusId")
                        .HasColumnType("integer");

                    b.Property<int?>("SocketCount")
                        .HasColumnType("integer");

                    b.Property<int?>("SpellDamage")
                        .HasColumnType("integer");

                    b.Property<int?>("Spirit")
                        .HasColumnType("integer");

                    b.Property<int?>("Stamina")
                        .HasColumnType("integer");

                    b.Property<int?>("Strength")
                        .HasColumnType("integer");

                    b.Property<int?>("VendorPrice")
                        .HasColumnType("integer");

                    b.Property<int?>("WeaponDamageMaximum")
                        .HasColumnType("integer");

                    b.Property<int?>("WeaponDamageMinimum")
                        .HasColumnType("integer");

                    b.Property<double?>("WeaponDps")
                        .HasColumnType("double precision");

                    b.Property<double?>("WeaponSpeed")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("Socket1Id");

                    b.HasIndex("Socket2Id");

                    b.HasIndex("Socket3Id");

                    b.ToTable("LichKingEquipmentMetadata", "items");
                });

            modelBuilder.Entity("WrathLC.Items.Data.Entities.WowClass", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("WowheadFlagEnumId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("WowClasses", "items");

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

            modelBuilder.Entity("WrathLc.Core.ResourceAccess.Entities.DiscordServerUser", b =>
                {
                    b.HasOne("WrathLc.Core.ResourceAccess.Entities.DiscordServer", "DiscordServer")
                        .WithMany("Users")
                        .HasForeignKey("DiscordServerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DiscordServer");
                });

            modelBuilder.Entity("WrathLc.Core.ResourceAccess.Entities.Guild", b =>
                {
                    b.HasOne("WrathLc.Core.ResourceAccess.Entities.DiscordServer", "DiscordServer")
                        .WithOne("Guild")
                        .HasForeignKey("WrathLc.Core.ResourceAccess.Entities.Guild", "DiscordServerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DiscordServer");
                });

            modelBuilder.Entity("WrathLc.Core.ResourceAccess.Entities.GuildUser", b =>
                {
                    b.HasOne("WrathLc.Core.ResourceAccess.Entities.Guild", "Guild")
                        .WithMany("GuildUsers")
                        .HasForeignKey("GuildId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Guild");
                });

            modelBuilder.Entity("WrathLC.Items.Data.Entities.Item", b =>
                {
                    b.HasOne("WrathLC.Items.Data.Entities.Icon", "Icon")
                        .WithMany("Items")
                        .HasForeignKey("IconId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WrathLC.Items.Data.Entities.ItemInventorySlot", "ItemInventorySlot")
                        .WithMany("Items")
                        .HasForeignKey("ItemInventorySlotId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WrathLC.Items.Data.Entities.ItemQuality", "ItemQuality")
                        .WithMany("Items")
                        .HasForeignKey("ItemQualityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WrathLC.Items.Data.Entities.ItemSubClass", "ItemSubClass")
                        .WithMany("Items")
                        .HasForeignKey("ItemSubClassId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WrathLC.Items.Data.Entities.LichKingEquipmentMetadata", "LichKingEquipmentMetadata")
                        .WithOne()
                        .HasForeignKey("WrathLC.Items.Data.Entities.Item", "LichKingEquipmentMetadataId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Icon");

                    b.Navigation("ItemInventorySlot");

                    b.Navigation("ItemQuality");

                    b.Navigation("ItemSubClass");

                    b.Navigation("LichKingEquipmentMetadata");
                });

            modelBuilder.Entity("WrathLC.Items.Data.Entities.ItemClassRestriction", b =>
                {
                    b.HasOne("WrathLC.Items.Data.Entities.Item", "Item")
                        .WithMany("ClassRestrictions")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WrathLC.Items.Data.Entities.WowClass", "WowClass")
                        .WithMany()
                        .HasForeignKey("WowClassId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("WowClass");
                });

            modelBuilder.Entity("WrathLC.Items.Data.Entities.ItemSubClass", b =>
                {
                    b.HasOne("WrathLC.Items.Data.Entities.ItemClass", "ItemClass")
                        .WithMany("ItemSubClasses")
                        .HasForeignKey("ItemClassId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ItemClass");
                });

            modelBuilder.Entity("WrathLC.Items.Data.Entities.LichKingEquipmentMetadata", b =>
                {
                    b.HasOne("WrathLC.Items.Data.Entities.ItemSocket", "Socket1")
                        .WithMany()
                        .HasForeignKey("Socket1Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WrathLC.Items.Data.Entities.ItemSocket", "Socket2")
                        .WithMany()
                        .HasForeignKey("Socket2Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WrathLC.Items.Data.Entities.ItemSocket", "Socket3")
                        .WithMany()
                        .HasForeignKey("Socket3Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Socket1");

                    b.Navigation("Socket2");

                    b.Navigation("Socket3");
                });

            modelBuilder.Entity("WrathLc.Core.ResourceAccess.Entities.DiscordServer", b =>
                {
                    b.Navigation("Guild");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("WrathLc.Core.ResourceAccess.Entities.Guild", b =>
                {
                    b.Navigation("GuildUsers");
                });

            modelBuilder.Entity("WrathLC.Items.Data.Entities.Icon", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("WrathLC.Items.Data.Entities.Item", b =>
                {
                    b.Navigation("ClassRestrictions");
                });

            modelBuilder.Entity("WrathLC.Items.Data.Entities.ItemClass", b =>
                {
                    b.Navigation("ItemSubClasses");
                });

            modelBuilder.Entity("WrathLC.Items.Data.Entities.ItemInventorySlot", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("WrathLC.Items.Data.Entities.ItemQuality", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("WrathLC.Items.Data.Entities.ItemSubClass", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
