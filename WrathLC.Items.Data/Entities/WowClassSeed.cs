namespace WrathLC.Items.Data.Entities;

public static class WowClassSeed
{
    public static List<WowClass> Classes = new List<WowClass>
    {
        new()
        {
            Id = 1,
            Name = "Warrior",
            WowheadFlagEnumId = 1
        },
        new()
        {
            Id = 2,
            Name = "Paladin",
            WowheadFlagEnumId = 2
        },
        new()
        {
            Id = 3,
            Name = "Hunter",
            WowheadFlagEnumId = 4
        },
        new()
        {
            Id = 4,
            Name = "Rogue",
            WowheadFlagEnumId = 8,
        },
        new()
        {
            Id = 5,
            Name = "Priest",
            WowheadFlagEnumId = 16
        },
        new()
        {
            Id = 6,
            Name = "Death Knight",
            WowheadFlagEnumId = 32
        },
        new()
        {
            Id = 7,
            Name = "Shaman",
            WowheadFlagEnumId = 64
        },
        new()
        {
            Id = 8,
            Name = "Mage",
            WowheadFlagEnumId = 128
        },
        new()
        {
            Id = 9,
            Name = "Warlock",
            WowheadFlagEnumId = 256
        },
        new()
        {
            Id = 10,
            Name = "Druid",
            WowheadFlagEnumId = 1024
        }
    };
}
[Flags]
public enum WowheadClass
{
    Warrior = 1,
    Paladin = 2,
    Hunter = 4,
    Rogue = 8,
    Priest = 16,
    DeathKnight = 32,
    Shaman = 64,
    Mage = 128,
    Warlock = 256,
    Druid = 1024
}