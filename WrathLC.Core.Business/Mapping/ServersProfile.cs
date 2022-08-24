using AutoMapper;
using JetBrains.Annotations;
using WrathLc.Core.ResourceAccess.Entities;
using WrathLC.Core.Utility.DataContracts.Models;

namespace WrathLC.Core.Business.Mapping;

[UsedImplicitly]
public class ServersProfile : Profile
{
    public ServersProfile()
    {
        CreateMap<DiscordServer, DiscordServerSummaryModel>()
            .ForMember(x=>x.GuildId, o=>o.MapFrom(x=>x.Guild.Id));
    }
}