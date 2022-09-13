using AutoMapper;
using JetBrains.Annotations;
using WrathLc.Core.ResourceAccess.Entities;
using WrathLC.Core.Utility.DataContracts.Models;

namespace WrathLC.Core.Business.Mapping;

[UsedImplicitly]
public class WishlistProfile : Profile
{
    public WishlistProfile()
    {
        CreateMap<Wishlist, WishlistModel>()
            .ForMember(x=>x.LastUpdated, o=>o.MapFrom(x=>x.UpdatedAt ?? x.CreatedAt))
            .ForMember(x=>x.Items, o=>o.MapFrom(x=>x.WishlistItems));
    }
}