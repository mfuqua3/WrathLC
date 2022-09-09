using WrathLC.Utility.Common.DataContracts.Interfaces;

namespace WrathLC.Items.Data.Entities;

public class LichKingEquipmentMetadata : IUnique<int>
{
    public int Id { get; set; }
    public int? Armor { get; set; }
    public int? Durability { get; set; }
    public int? Agility { get; set; }
    public int? Strength { get; set; }
    public int? Intellect { get; set; }
    public int? Spirit { get; set; }
    public int? Stamina { get; set; }
    public int? LevelRequirement { get; set; }
    public int? VendorPrice { get; set; }
    public int? SocketCount { get; set; }
    public int? Socket1Id { get; set; }
    public int? Socket2Id { get; set; }
    public int? Socket3Id { get; set; }
    public int? SocketBonusId { get; set; }
    
    public int? HitRating { get; set; }
    public int? HasteRating { get; set; }
    public int? ManaRegen { get; set; }
    public int? SpellDamage { get; set; }
    public int? Healing { get; set; }
    public int? DefenseRating { get; set; } 
    public int? ParryRating { get; set; } 
    public int? DodgeRating { get; set; } 
    public int? CriticalStrikeRating { get; set; } 
    public int? MeleeAttackPower { get; set; } 
    public int? ExpertiseRating { get; set; } 
    public int? RangedAttackPower { get; set; } 
    public int? WeaponDamageMinimum { get; set; } 
    public int? WeaponDamageMaximum { get; set; } 
    public double? WeaponDps { get; set; } 
    public double? WeaponSpeed { get; set; } 
    public ItemSocket Socket1 { get; set; }
    public ItemSocket Socket2 { get; set; }
    public ItemSocket Socket3 { get; set; }
}