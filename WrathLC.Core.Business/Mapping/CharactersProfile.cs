using AutoMapper;
using JetBrains.Annotations;
using WrathLc.Core.ResourceAccess.Entities;
using WrathLC.Core.Utility.DataContracts.Models;

namespace WrathLC.Core.Business.Mapping;

[UsedImplicitly]
public class CharactersProfile : Profile
{
    public CharactersProfile()
    {
        CreateMap<Character, UserCharacterModel>()
            .ForMember(x => x.Class, o => o.MapFrom(x => x.WowClass.Name));
        CreateMap<Character, GuildCharacterModel>()
            .ForMember(x => x.Class, o => o.MapFrom(x => x.WowClass.Name))
            .ForMember(x => x.UserId, o => o.MapFrom(x => x.GuildUser.UserId));
    }
}