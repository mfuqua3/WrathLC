using AutoMapper;
using WrathLC.Items.Data.Entities;
using WrathLC.Items.DataEngine.Wowhead;

namespace WrathLC.Items.DataEngine.Mapping;

public class ItemProfile : Profile
{
    public ItemProfile()
    {
        CreateMap<XmlWarcraftItem, Item>()
            .ForMember(x => x.Id, o => o.MapFrom(x => x.Id))
            .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
            .ForMember(x => x.ItemLevel, o => o.MapFrom(x => x.Level))
            .ForMember(x => x.ItemSubClassId, o => o.MapFrom(x => x.Subclass.Id))
            .ForMember(x => x.ItemQualityId, o => o.MapFrom(x => x.Quality.Id))
            .ForMember(x => x.ItemInventorySlotId, o => o.MapFrom(x => x.InventorySlot.Id))
            .ForMember(x => x.IconId, o => o.MapFrom(x => x.Icon.DisplayId))
            .ForMember(x => x.LichKingEquipmentMetadata, o => o.MapFrom(x => x.JsonEquip));
    }
}