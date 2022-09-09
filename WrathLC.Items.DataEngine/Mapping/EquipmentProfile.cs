using System;
using AutoMapper;
using WrathLC.Items.Data.Entities;
using WrathLC.Items.DataEngine.Wowhead;

namespace WrathLC.Items.DataEngine.Mapping;

public class EquipmentProfile : Profile
{
    public EquipmentProfile()
    {
        CreateMap<JsonEquip, LichKingEquipmentMetadata>()
            .ForMember(x => x.WeaponDamageMinimum,
                o => o.MapFrom(x => x.WeaponDamageMinimum.HasValue
                    ? ((int?)Math.Round(
                        x.WeaponDamageMinimum.Value))
                    : null))
            .ForMember(x => x.WeaponDamageMaximum,
                o => o.MapFrom(x => x.WeaponDamageMaximum.HasValue
                    ? ((int?)Math.Round(
                        x.WeaponDamageMaximum.Value))
                    : null))
            .ForMember(x => x.WeaponDps,
                o => o.MapFrom(x => x.WeaponDps.HasValue
                    ? (double?)Math.Round(
                        x.WeaponDps.Value, 2)
                    : null))
            .ForMember(x => x.WeaponDamageMinimum,
                o => o.MapFrom(x => x.WeaponDamageMinimum.HasValue
                    ? (double?)Math.Round(
                        x.WeaponDamageMinimum.Value, 2)
                    : null))
            .ForMember(x=>x.SocketBonusId, o=>o.Ignore());
    }
}