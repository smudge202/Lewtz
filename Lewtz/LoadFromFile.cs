using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO; //streamreader
using System.Linq;
using System.Text;
using System.Windows.Forms;
using rds;

namespace Lewtz
{
    public partial class FormLewtz
    {
        public void LoadTables()
        {
            #region ITEMSTABLE ENTRIES
            MundaneItemsTable.AddEntry(AlchemicalItemsTable, 17);
            AlchemicalItemsTable.LoadFromFile("Alchemical Items.Lewt", "Alchemical Item", 1, "");

            MundaneItemsTable.AddEntry(ArmorTable, 50);
            ArmorTable.LoadFromFile("Common Armors.Lewt", "Armor", 1, "");
            ArmorTable.AddEntry(DarkwoodShields, 90);
                DarkwoodShields.AddEntry(new Item("Shield", "Darkwood Buckler", 20500, 50));
                DarkwoodShields.AddEntry(new Item("Shield", "Darkwood Shield", 25700, 100));

            ArmorTable.AddEntry(Shields, 100);
                Shields.LoadFromFile("Common Shields.Lewt", "Common Shield", 1, "");

            MundaneItemsTable.AddEntry(WeaponsTable, 83);
            WeaponsTable.AddEntry(CommonWeapons, 70);
            WeaponsTable.AddEntry(UncommonWeapons, 80);
            WeaponsTable.AddEntry(CommonRangedWeapons, 100);
                CommonWeapons.LoadFromFile(      "Common Melee Weapons.Lewt",  "Common Melee Weapon",   1, "");
                UncommonWeapons.LoadFromFile(    "DMG Uncommon Weapons.Lewt",  "Uncommon Melee Weapon", 1, "");
                CommonRangedWeapons.LoadFromFile("Common Ranged Weapons.Lewt", "Common Ranged Weapon",  1, "");

            MundaneItemsTable.AddEntry(ToolsGear, 100);
                ToolsGear.LoadFromFile("ToolsGear.Lewt", "Tools and Gear", 1, "");

            MinorMagicTable.AddEntry(MinorArmorTable, 4);
                MinorArmorTable.AddEntry(new MagicItem("Magic Armor", "+1", 0, 1), 60);
                MinorArmorTable.AddEntry(new MagicItem("Magic Shield", "+1", 0, 1), 80);
                MinorArmorTable.AddEntry(new MagicItem("Magic Armor", "+2", 0, 2), 85);
                MinorArmorTable.AddEntry(new MagicItem("Magic Shield", "+2", 0, 2), 87);
                MinorArmorTable.AddEntry(MinorSpecificArmors, 89);
                    MinorSpecificArmors.AddEntry(new MagicItem("Specific Armor", "Armor Name", 2, 0), 1, false, true, true);

            MinorArmorTable.AddEntry(MinorSpecificShields, 91);
                MinorSpecificShields.AddEntry(new MagicItem("Specific Shield", "Shield Name", 2, 0), 1,   false, true, true);
            MinorArmorTable.AddEntry(new MagicItem(         "Armor Ability",   "Ability",     0, 1), 100); //special abilites. ROLL AGAIN


            MinorArmorAbilitiesTable.LoadFromFile("DMG Armor Special Abilities.Lewt", "Armor Ability", 3, "Minor");
            MinorShieldAbilitiesTable.LoadFromFile("DMG Shield Special Abilities.Lewt", "Shield Ability", 3, "Minor");
            MinorMeleeWeaponsAbilitiesTable.LoadFromFile("DMG Melee Weapon Special Abilities.Lewt", "Melee Weapon Ability", 3, "Minor");
            MinorRangedWeaponsAbilitiesTable.LoadFromFile("DMG Ranged Weapon Special Abilities.Lewt", "Ranged Weapon Ability", 3, "Minor");

            MinorMagicTable.AddEntry(MinorWeaponsTable, 9);
                MinorWeaponsTable.AddEntry(new MagicItem("Magic Weapon", "+1", 0, 1), 70);
                MinorWeaponsTable.AddEntry(new MagicItem("Magic Weapon", "+2", 0, 2), 85);
                MinorWeaponsTable.AddEntry(MinorSpecificWeapons, 90);
                    MinorSpecificWeapons.AddEntry(new MagicItem("Specific Weapon", "Weapon Name", 2, 0), 1, false, true, true);
                MinorWeaponsTable.AddEntry(new MagicItem("Weapon Ability", "Ability", 0, 1), 100);
            MinorMagicTable.AddEntry(MinorPotionsTable, 44);
                MinorPotionsTable.AddEntry(new MagicItem("Potion", "Potion Name", 0, 0), 1, false, true, true);
            MinorMagicTable.AddEntry(MinorRingsTable,   46);
                MinorRingsTable.AddEntry(new MagicItem("Ring", "Ring Name", 0, 0), 1, false, true, true);
            MinorMagicTable.AddEntry(MinorScrollsTable, 81);
                MinorScrollsTable.AddEntry(new MagicItem("Scroll", "Scroll Name", 0, 0), 1, false, true, true);
            MinorMagicTable.AddEntry(MinorWandsTable,   91);
                MinorWandsTable.AddEntry(new MagicItem("Wand", "Wand Name", 0, 0), 1, false, true, true);
            MinorMagicTable.AddEntry(MinorWondrousItemsTable, 100);
                MinorWondrousItemsTable.AddEntry(new MagicItem("Wondrous Item", "Wondrous Item Name", 2, 0), 1, false, true, true);

            MediumMagicTable.AddEntry(MediumArmorTable, 10);
                MediumArmorTable.AddEntry(new MagicItem("Magic Armor",  "+1", 0, 1),         5);
                MediumArmorTable.AddEntry(new MagicItem("Magic Shield", "+1", 0, 1),        10);
                MediumArmorTable.AddEntry(new MagicItem("Magic Armor",  "+2", 0, 2),        20);
                MediumArmorTable.AddEntry(new MagicItem("Magic Shield", "+2", 0, 2),        30);
                MediumArmorTable.AddEntry(new MagicItem("Magic Armor",  "+3", 0, 3),        40);
                MediumArmorTable.AddEntry(new MagicItem("Magic Shield", "+3", 0, 3),        50);
                MediumArmorTable.AddEntry(new MagicItem("Magic Armor",  "+4", 0, 4),        55);
                MediumArmorTable.AddEntry(new MagicItem("Magic Shield", "+4", 0, 4),        57);
                MediumArmorTable.AddEntry(MediumSpecificArmors,                             60);
                MediumArmorTable.AddEntry(MediumSpecificShields,                            63);

                MediumArmorTable.AddEntry(new MagicItem("Armor Ability", "Ability", 0, 1), 100); //special abilites. ROLL AGAIN

                MediumArmorAbilitiesTable.LoadFromFile("DMG Armor Special Abilities.Lewt", "Armor Ability", 3, "Medium");
                MediumShieldAbilitiesTable.LoadFromFile("DMG Shield Special Abilities.Lewt", "Shield Ability", 3, "Medium");
                MediumMeleeWeaponsAbilitiesTable.LoadFromFile("DMG Melee Weapon Special Abilities.Lewt", "Melee Weapon Ability", 3, "Medium");
                MediumRangedWeaponsAbilitiesTable.LoadFromFile("DMG Ranged Weapon Special Abilities.Lewt", "Ranged Weapon Ability", 3, "Medium");

            MediumMagicTable.AddEntry(MediumWeaponsTable, 20);
                MediumWeaponsTable.AddEntry(new MagicItem("Magic Weapon", "+1", 0, 1), 10);
                MediumWeaponsTable.AddEntry(new MagicItem("Magic Weapon", "+2", 0, 2), 29);
                MediumWeaponsTable.AddEntry(new MagicItem("Magic Weapon", "+3", 0, 3), 58);
                MediumWeaponsTable.AddEntry(new MagicItem("Magic Weapon", "+4", 0, 4), 62);
                MediumWeaponsTable.AddEntry(MediumSpecificWeapons, 68);

                MediumWeaponsTable.AddEntry(new MagicItem("Weapon Ability", "Ability", 0, 1), 100);

            MediumMagicTable.AddEntry(MediumPotionsTable, 30);
            MediumMagicTable.AddEntry(MediumRingsTable, 40);
            MediumMagicTable.AddEntry(MediumRodsTable, 50);
            MediumMagicTable.AddEntry(MediumScrollsTable, 65);
            MediumMagicTable.AddEntry(MediumStaffsTable, 68);
            MediumMagicTable.AddEntry(MediumWandsTable, 83);
            MediumMagicTable.AddEntry(MediumWondrousItemsTable, 100);

            MajorMagicTable.AddEntry(MajorArmorTable, 10);
                MajorArmorTable.AddEntry(new MagicItem("Magic Armor",  "+3", 0, 3), 8);
                MajorArmorTable.AddEntry(new MagicItem("Magic Shield", "+3", 0, 3), 16);
                MajorArmorTable.AddEntry(new MagicItem("Magic Armor",  "+4", 0, 4), 27);
                MajorArmorTable.AddEntry(new MagicItem("Magic Shield", "+4", 0, 4), 38);
                MajorArmorTable.AddEntry(new MagicItem("Magic Armor",  "+5", 0, 5), 49);
                MajorArmorTable.AddEntry(new MagicItem("Magic Shield", "+5", 0, 5), 57);
                MajorArmorTable.AddEntry(MajorSpecificArmors, 60);
                MajorArmorTable.AddEntry(MajorSpecificShields, 63);
                MajorArmorTable.AddEntry(new MagicItem("Armor Ability", "Ability", 0, 1), 100); //special abilites. ROLL AGAIN

                MajorArmorAbilitiesTable.LoadFromFile("DMG Armor Special Abilities.Lewt",  "Armor Ability",  3, "Major");
                MajorArmorAbilitiesTable.LoadFromFile("DMG Shield Special Abilities.Lewt", "Shield Ability", 3, "Major");

                MajorMeleeWeaponsAbilitiesTable.LoadFromFile("DMG Melee Weapon Special Abilities.Lewt", "Melee Weapon Ability",    3, "Major");
                MajorRangedWeaponsAbilitiesTable.LoadFromFile("DMG Ranged Weapon Special Abilities.Lewt", "Ranged Weapon Ability", 3, "Major");

            MajorMagicTable.AddEntry(MajorWeaponsTable, 20);
                MajorWeaponsTable.AddEntry(new MagicItem("Magic Weapon", "+3", 0, 3), 20);
                MajorWeaponsTable.AddEntry(new MagicItem("Magic Weapon", "+4", 0, 4), 38);
                MajorWeaponsTable.AddEntry(new MagicItem("Magic Weapon", "+5", 0, 5), 49);
                MajorWeaponsTable.AddEntry(MajorSpecificWeapons, 63);

                MajorWeaponsTable.AddEntry(new MagicItem("Weapon Ability", "Ability", 0, 1), 100);

            MajorMagicTable.AddEntry(MajorPotionsTable,        25);
            MajorMagicTable.AddEntry(MajorRingsTable,          35);
            MajorMagicTable.AddEntry(MajorRodsTable,           45);
            MajorMagicTable.AddEntry(MajorScrollsTable,        55);
            MajorMagicTable.AddEntry(MajorStaffsTable,         75);
            MajorMagicTable.AddEntry(MajorWandsTable,          80);
            MajorMagicTable.AddEntry(MajorWondrousItemsTable, 100);

            #endregion

            #region GOODSTABLE ENTRIES
            GemTable.AddEntry(LowestGemTable,  25);
            GemTable.AddEntry(LowerGemTable,   50);
            GemTable.AddEntry(LowGemTable,     70);
            GemTable.AddEntry(HighGemTable,    90);
            GemTable.AddEntry(HigherGemTable,  99);
            GemTable.AddEntry(HighestGemTable, 100);

                LowestGemTable.LoadFromFile( "LowestValueGems.Lewt",  "Lowest Value Gem",  2, "");
                LowerGemTable.LoadFromFile(  "LowerValueGems.Lewt",   "Lower Value Gem",   2, "");
                LowGemTable.LoadFromFile(    "LowValueGems.Lewt",     "Low Value Gem",     2, "");
                HighGemTable.LoadFromFile(   "HighValueGems.Lewt",    "High Value Gem",    2, "");
                HigherGemTable.LoadFromFile( "HigherValueGems.Lewt",  "Higher Value Gem",  2, "");
                HighestGemTable.LoadFromFile("HighestValueGems.Lewt", "Highest Value Gem", 2, "");
            #endregion
        }
    }
}