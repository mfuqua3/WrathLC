using System.Collections.Generic;
using System.Linq;
using static WrathLC.Items.Data.WowClassIds;

namespace WrathLc.Core.ResourceAccess;

public static class ItemHelpers
{
    private static readonly int[] AllClasses =
        { Priest, Warlock, Priest, Rogue, Druid, Shaman, Hunter, Paladin, Warrior, DeathKnight };

    private static Dictionary<int, int[]> _subClassLookup = new()
    {
        { 1, new[] { Priest, Druid, Rogue, Shaman, Paladin, Warrior, DeathKnight } }, //1H Maces
        { 2, new[] { Mage, Warlock, Rogue, Hunter, Paladin, Warrior, DeathKnight } }, //1H Swords
        { 3, AllClasses }, //Cloth Armor
        { 4, AllClasses }, //Rings
        { 5, new[] { Paladin, Warrior, Shaman } }, //Shields
        { 6, new[] { DeathKnight, Hunter, Paladin, Rogue, Shaman, Warrior } }, //1H Axes
        { 7, AllClasses }, //Cloaks
        { 10, new[] { Mage, Priest, Warlock } }, //Wands
        { 11, new[] { Rogue, Druid, Hunter, Shaman, Paladin, Warrior, DeathKnight } }, //Leather Armor
        { 13, new[] { DeathKnight, Hunter, Paladin, Warrior } }, //2H Swords
        { 14, new[] { Hunter, Rogue, Warrior } }, //Bows
        { 15, new[] { Hunter, Shaman, Warrior, Paladin, DeathKnight } }, //Mail Armor
        { 17, new[] { Warrior, Paladin, DeathKnight } }, //Plate Armor
        { 18, new[] { Druid, Hunter, Mage, Priest, Shaman, Warlock, Warrior } }, //Staves
        { 19, new[] { Druid, Hunter, Rogue, Shaman, Warrior } }, //Fist Weapons
        { 20, new[] { DeathKnight, Hunter, Paladin, Shaman, Warrior } }, //2H Axes
        { 21, new[] { DeathKnight, Druid, Paladin, Shaman, Warrior } }, //2H Maces
        { 23, new[] { Hunter, Rogue, Warrior } }, //Guns
        { 24, new[] { DeathKnight, Druid, Hunter, Paladin, Warrior } }, //Polearms
        { 25, new[] { Druid, Hunter, Mage, Priest, Rogue, Shaman, Warlock, Warrior } }, //Daggers
        { 26, new[] { Hunter, Rogue, Warrior } }, //Crossbows
        { 27, new[] { Warrior, Rogue } }, //Thrown
        { 33, new[] { DeathKnight } }, //Sigils
        { 34, AllClasses }, //Trinkets
        { 47, new[] { Shaman } }, //Totems
        { 48, new[] { Druid } }, //Idols
        { 66, AllClasses }, //Mounts
        { 74, AllClasses }, //LW Patterns
        { 75, AllClasses }, //Alch Patterns
        { 76, AllClasses }, //Tailoring Patterns
        { 78, AllClasses }, //BS Plans
        { 80, AllClasses }, //Eng Schematics
        { 83, AllClasses }, //Enchanting Formulae
        { 88, AllClasses }, //JC Designs
    };

    public static int[] PermittedWishlistSubClasses(int wowClassId)
        => _subClassLookup.Where(x => x.Value.Contains(wowClassId)).Select(x => x.Key).ToArray();
}