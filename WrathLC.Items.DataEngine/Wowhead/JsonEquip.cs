using System.Text.Json.Serialization;

namespace WrathLC.Items.DataEngine.Wowhead;

public class JsonEquip
{
    //Base
    [JsonPropertyName("armor")]
    public int? Armor { get; set; } //armor
    [JsonPropertyName("dura")]
    public int? Durability { get; set; } //dura
    [JsonPropertyName("agi")]
    public int? Agility { get; set; } //agi
    [JsonPropertyName("str")]
    public int? Strength { get; set; } //str
    [JsonPropertyName("int")]
    public int? Intellect { get; set; } //int
    [JsonPropertyName("spi")]
    public int? Spirit { get; set; } //spi
    [JsonPropertyName("sta")]
    public int? Stamina { get; set; } //sta
    [JsonPropertyName("reqlevel")]
    public int? LevelRequirement { get; set; } //reqlevel
    [JsonPropertyName("sellprice")]
    public int? VendorPrice { get; set; } //sellprice
    
    [JsonPropertyName("nsockets")]
    public int? SocketCount { get; set; } //nsockets
    [JsonPropertyName("socket1")]
    public int? Socket1Id { get; set; } //socket1
    [JsonPropertyName("socket2")]
    public int? Socket2Id { get; set; } //socket2
    [JsonPropertyName("socket3")]
    public int? Socket3Id { get; set; } //socket3
    [JsonPropertyName("socket4")]
    public int? Socket4Id { get; set; } //socket4
    [JsonPropertyName("socketbonus")]
    public int? SocketBonusId { get; set; } //socketbonus
    
    [JsonPropertyName("hitrtng")]
    public int? HitRating { get; set; } //hitrtng
    [JsonPropertyName("hastertng")]
    public int? HasteRating { get; set; } //hastertng
    //Caster
    [JsonPropertyName("manargn")]
    public int? ManaRegen { get; set; }
    [JsonPropertyName("spldmg")]
    public int? SpellDamage { get; set; }
    [JsonPropertyName("splheal")]
    public int? Healing { get; set; }
    //Defense
    [JsonPropertyName("defrtng")]
    public int? DefenseRating { get; set; } //defrtng
    [JsonPropertyName("parryrtng")]
    public int? ParryRating { get; set; } //parryrtng
    [JsonPropertyName("dodgertng")]
    public int? DodgeRating { get; set; } //dodgertng
    //Melee
    [JsonPropertyName("critstrkrtng")]
    public int? CriticalStrikeRating { get; set; } //critstrkrtng
    [JsonPropertyName("mleatkpwr")]
    public int? MeleeAttackPower { get; set; } //mleatkpwr
    [JsonPropertyName("exprtng")]
    public int? ExpertiseRating { get; set; } //exprtng
    [JsonPropertyName("classes")]
    public int? Classes { get; set; }
    //Ranged
    [JsonPropertyName("rgdatkpwr")]
    public int? RangedAttackPower { get; set; } //rgdatkpwr
    //Weapon
    [JsonPropertyName("dmgmin1")]
    public double? WeaponDamageMinimum { get; set; } //dmgmin1
    [JsonPropertyName("dmgmax1")]
    public double? WeaponDamageMaximum { get; set; } //dmgmax1
    [JsonPropertyName("dps")]
    public double? WeaponDps { get; set; } //dps
    [JsonPropertyName("speed")]
    public double? WeaponSpeed { get; set; } //speed
}