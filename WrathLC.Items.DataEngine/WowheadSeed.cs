using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WrathLC.Items.Data.Entities;
using WrathLC.Items.DataEngine.Mapping;
using WrathLC.Items.DataEngine.Wowhead;
using WrathLC.Utility.Common.DataContracts.Interfaces;
using Icon = WrathLC.Items.Data.Entities.Icon;

namespace WrathLC.Items.DataEngine;

public class WowheadSeed
{
    public async Task RunAsync()
    {
        var failedItems = new List<XmlWarcraftItem>();
        var client = new WowheadClient();
        var mapperConfig = new MapperConfiguration(x =>
        {
            x.AddProfile<EquipmentProfile>();
            x.AddProfile<ItemProfile>();
        });
        var queryClient = new HttpClient();
        queryClient.BaseAddress = new Uri("https://www.wowhead.com/wotlk/icons/");
        var mapper = mapperConfig.CreateMapper();
        await using var context = new WrathLcItemsDbContext();
        await context.Database.MigrateAsync();
        for (var i = 53000; i < 60000; i++)
        {
            await using var itemContext = new WrathLcItemsDbContext();
            var result = await client.Get(i.ToString());
            if (result?.Item == null)
                continue;
            var item = result.Item;
            if (!int.TryParse(item.Class.Id, out var classId) || classId == 12)
            {
                continue; //ignore quest items
            }

            Console.WriteLine($"Successfully fetched {i}: {item.Name}");
            try
            {
                await AddItem(item, itemContext, mapper, queryClient);
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while adding {item.Id} {item.Name}");
                Console.WriteLine(e);
                failedItems.Add(item);
            }
        }

        Console.WriteLine($"Job Done. {failedItems.Count} failed items");
        foreach (var failedItem in failedItems)
        {
            Console.WriteLine($"{failedItem.Id}: {failedItem.Name}");
        }
    }
    private static async Task AddItem(XmlWarcraftItem item, WrathLcItemsDbContext context, IMapper mapper,
        HttpClient queryClient)
    {
        item.Class.Text ??= "Unspecified";
        item.Subclass.Text ??= "Unspecified";
        item.InventorySlot.Text ??= "Unspecified";
        item.Quality.Text ??= "Unspecified";
        var itemClass =
            await context.ItemClasses.FirstOrDefaultAsync(x => item.Class != null && x.Name == item.Class.Text);
        if (string.IsNullOrEmpty(item.Subclass.Text))
        {
            item.Subclass.Text = "Unspecified";
        }

        var subclass =
            await context.ItemSubClasses.FirstOrDefaultAsync(x =>
                item.Subclass != null && itemClass != null && x.Name == item.Subclass.Text &&
                x.ItemClassId == itemClass.Id);
        var slot = await context.ItemInventorySlots.FirstOrDefaultAsync(x =>
            item.InventorySlot != null && x.Name == item.InventorySlot.Text);
        var quality  =
            await context.ItemQualities.FirstOrDefaultAsync(x => item.Quality != null && x.Name == item.Quality.Text);
        var iconExists = await context.WowheadIcons.AnyAsync(x => item.Icon == null || x.Id == item.Icon.DisplayId);
        var itemExists = await context.Items.AnyAsync(x => x.Id == int.Parse(item.Id));
        if (itemClass == null)
        {
            var addClass = new ItemClass
            {
                Name = item.Class.Text
            };
            await context.ItemClasses.AddAsync(addClass);
            LogAdd(addClass);
            await context.SaveChangesAsync();
            itemClass = addClass;
        }

        if (subclass == null)
        {
            var addSubClass = new ItemSubClass()
            {
                Name = item.Subclass.Text,
                ItemClassId = itemClass.Id
            };
            await context.ItemSubClasses.AddAsync(addSubClass);
            LogAdd(addSubClass);
            await context.SaveChangesAsync();
            subclass = addSubClass;
        }

        if (slot == null)
        {
            var addSlot = new ItemInventorySlot()
            {
                Id = int.Parse(item.InventorySlot.Id),
                Name = item.InventorySlot.Text
            };
            await context.ItemInventorySlots.AddAsync(addSlot);
            LogAdd(addSlot);
            await context.SaveChangesAsync();
            slot = addSlot;
        }

        if (quality == null)
        {
            var addQuality = new ItemQuality()
            {
                Id = int.Parse(item.Quality.Id),
                Name = item.Quality.Text
            };
            await context.ItemQualities.AddAsync(addQuality);
            LogAdd(addQuality);
            await context.SaveChangesAsync();
            quality = addQuality;
        }

        if (!iconExists)
        {
            var addIcon = new Icon()
            {
                Id = item.Icon.DisplayId,
                Name = item.Icon.IconName
            };
            var add = true;
            if (addIcon.Id == default)
            {
                var fromName = await context.WowheadIcons.FirstOrDefaultAsync(x => x.Name == addIcon.Name);
                var id = fromName?.Id;
                if (fromName != null)
                {
                    item.Icon.DisplayId = fromName.Id;
                    add = false;
                }

                if (id == default)
                {
                    Console.WriteLine($"Attempting to resolve icon: {addIcon.Name}");
                    {
                        var path = $"name:{addIcon.Name}";
                        var document = await queryClient.GetAsync(new Uri($"https://www.wowhead.com/wotlk/item={item.Id}"));
                        var body = await document.Content.ReadAsStringAsync();
                        var queryString = "[icondb=";
                        var idx = body.IndexOf(queryString);
                        if (idx > 0)
                        {
                            var fromHtml = new string(body.Skip(idx + queryString.Length).TakeWhile(char.IsDigit).ToArray());
                            if (!string.IsNullOrWhiteSpace(fromHtml))
                            {
                                Console.WriteLine($"Resolved successfully as {fromHtml}");
                                id = int.Parse(fromHtml);
                            }
                        }
                    }
                    if (id == default)
                    {
                        Console.WriteLine($"Please provide ID for icon {addIcon.Name} (ITEM ID {item.Id})");
                        var parsed = Console.ReadLine();
                        id = int.Parse(parsed);
                    }
                    item.Icon.DisplayId = id.GetValueOrDefault();
                }

                addIcon.Id = id.GetValueOrDefault();
            }

            if (add)
            {
                await context.WowheadIcons.AddAsync(addIcon);
                LogAdd(addIcon);
                await context.SaveChangesAsync();
            }
        }

        if (!itemExists)
        {
            var addItem = mapper.Map<XmlWarcraftItem, Item>(item);
            if (item.JsonEquip is { Classes: { } })
            {
                addItem.ClassRestrictions = Enum.GetValues<WowheadClass>()
                    .Where(x => x.HasFlag((WowheadClass)item.JsonEquip.Classes))
                    .Cast<int>()
                    .Select(x => new ItemClassRestriction
                    {
                        WowClassId = context.WowClasses.Single(c=>c.WowheadFlagEnumId == x).Id,
                    }).ToList();
            }

            addItem.ItemSubClassId = subclass.Id;
            addItem.ItemInventorySlotId = slot.Id;
            addItem.ItemQualityId = quality.Id;
            await context.Items.AddAsync(addItem);
            LogAdd(addItem);
        }

        await context.SaveChangesAsync();
    }

    private static void LogAdd<T>(T added) where T : INamed, IUnique<int>
    {
        Console.WriteLine($"Adding {typeof(T).Name}: {added.Id} ({added.Name})");
    }
}