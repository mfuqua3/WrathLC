using AutoMapper;
using JetBrains.Annotations;
using WrathLC.Core.Utility.DataContracts.Models;
using WrathLC.Items.Data.Entities;

namespace WrathLC.Core.Business.Mapping;

[UsedImplicitly]
public class ItemProfile : Profile
{
    public ItemProfile()
    {
        CreateMap<Icon, ItemSummaryModel>()
            .ForMember(x => x.IconId, o => o.MapFrom(x => x.Id))
            .ForMember(x => x.IconName, o => o.MapFrom(x => x.Name));
        CreateMap<Item, ItemSummaryModel>()
            .IncludeMembers(x=>x.Icon)
            .ForMember(x=>x.ItemId, o=>o.MapFrom(x=>x.Id))
            .ForMember(x=>x.Domain, o=>o.MapFrom(x=>"wotlk"))
            .ForMember(x=>x.Name, o=>o.MapFrom(x=>x.Name))
            .ForMember(x=>x.Quality, o=>o.MapFrom(x=>x.ItemQuality.Name))
            .ForMember(x=>x.InventorySlot, o=>o.MapFrom(x=>x.ItemInventorySlot.Name))
            .ForMember(x=>x.Descriptor, o=>o.MapFrom(x=>x.ItemSubClass.Name));
    }
}