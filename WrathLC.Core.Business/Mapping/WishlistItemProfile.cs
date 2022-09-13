using AutoMapper;
using JetBrains.Annotations;
using WrathLc.Core.ResourceAccess.Entities;
using WrathLC.Core.Utility.DataContracts.Models;

namespace WrathLC.Core.Business.Mapping;

[UsedImplicitly]
public class WishlistItemProfile : Profile
{
    public WishlistItemProfile()
    {
        CreateMap<WishlistItem, WishlistItemModel>();
    }
}