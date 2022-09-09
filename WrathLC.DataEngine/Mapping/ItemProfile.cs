using AutoMapper;
using WrathLC.DataEngine.WowHead;

namespace WrathLC.DataEngine.Mapping;

public class ItemProfile : Profile
{
    public ItemProfile()
    {
        CreateMap<XmlWarcraftItem, Database.Item>()
            .ForMember(x => x.Id, o => o.MapFrom(x => x.Id))
            .ForMember(x => x.Name, o => o.MapFrom(x => x.Name))
            .ForMember(x => x.ItemLevel, o => o.MapFrom(x => x.Level))
            .ForMember(x => x.ItemSubClassId, o => o.MapFrom(x => x.Subclass.Id))
            .ForMember(x => x.ItemQualityId, o => o.MapFrom(x => x.Quality.Id))
            .ForMember(x => x.ItemInventorySlotId, o => o.MapFrom(x => x.InventorySlot.Id))
            .ForMember(x => x.WowheadIconId, o => o.MapFrom(x => x.Icon.DisplayId))
            .ForMember(x => x.LichKingEquipmentMetadata, o => o.MapFrom(x => x.JsonEquip));
    }
}