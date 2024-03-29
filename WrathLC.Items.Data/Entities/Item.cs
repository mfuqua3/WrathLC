﻿using WrathLC.Utility.Common.DataContracts.Interfaces;

namespace WrathLC.Items.Data.Entities;

public class Item : IUnique<int>, INamed
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ItemLevel { get; set; }
    public int ItemSubClassId { get; set; }
    public int ItemQualityId { get; set; }
    public int ItemInventorySlotId { get; set; }
    public int IconId { get; set; }
    public int? LichKingEquipmentMetadataId { get; set; }
    public LichKingEquipmentMetadata LichKingEquipmentMetadata { get; set; }
    public List<ItemClassRestriction> ClassRestrictions { get; set; }
    public ItemSubClass ItemSubClass { get; set; }
    public ItemQuality ItemQuality { get; set; }
    public ItemInventorySlot ItemInventorySlot { get; set; }
    public Icon Icon { get; set; }
}