using System;

namespace Lewtz.Data
{
	internal sealed class HardcodedDataSeed : SeedData
	{
		private readonly DataContext _context;

		public HardcodedDataSeed(DataContext context)
		{
			if (context == null)
				throw new ArgumentNullException("context");
			_context = context;
		}

		public void Generate()
		{
			#region ITEMSTABLE ENTRIES
			_context.MundaneItemsTable.AddEntry(_context.AlchemicalItemsTable, 17);
			_context.AlchemicalItemsTable.LoadFromFile("Alchemical Items.Lewt", "Alchemical Item", 1, "");

			_context.MundaneItemsTable.AddEntry(_context.ArmorTable, 50);
			_context.ArmorTable.LoadFromFile("Common Armors.Lewt", "Armor", 1, "");
			_context.ArmorTable.AddEntry(_context.DarkwoodShields, 90);
			_context.DarkwoodShields.AddEntry(new Item("Shield", "Darkwood Buckler", 20500, 50));
			_context.DarkwoodShields.AddEntry(new Item("Shield", "Darkwood Shield", 25700, 100));

			_context.ArmorTable.AddEntry(_context.Shields, 100);
			_context.Shields.LoadFromFile("Common Shields.Lewt", "Common Shield", 1, "");

			_context.MundaneItemsTable.AddEntry(_context.WeaponsTable, 83);
			_context.WeaponsTable.AddEntry(_context.CommonWeapons, 70);
			_context.WeaponsTable.AddEntry(_context.UncommonWeapons, 80);
			_context.WeaponsTable.AddEntry(_context.CommonRangedWeapons, 100);
			_context.CommonWeapons.LoadFromFile("Common Melee Weapons.Lewt", "Common Melee Weapon", 1, "");
			_context.UncommonWeapons.LoadFromFile("DMG Uncommon Weapons.Lewt", "Uncommon Melee Weapon", 1, "");
			_context.CommonRangedWeapons.LoadFromFile("Common Ranged Weapons.Lewt", "Common Ranged Weapon", 1, "");

			_context.MundaneItemsTable.AddEntry(_context.ToolsGear, 100);
			_context.ToolsGear.LoadFromFile("ToolsGear.Lewt", "Tools and Gear", 1, "");

			_context.MinorMagicTable.AddEntry(_context.MinorArmorTable, 4);
			_context.MinorArmorTable.AddEntry(new MagicItem("Magic Armor", "+1", 0, 1), 60);
			_context.MinorArmorTable.AddEntry(new MagicItem("Magic Shield", "+1", 0, 1), 80);
			_context.MinorArmorTable.AddEntry(new MagicItem("Magic Armor", "+2", 0, 2), 85);
			_context.MinorArmorTable.AddEntry(new MagicItem("Magic Shield", "+2", 0, 2), 87);
			_context.MinorArmorTable.AddEntry(_context.MinorSpecificArmors, 89);
			_context.MinorSpecificArmors.AddEntry(new MagicItem("Specific Armor", "Armor Name", 2, 0), 1, false, true, true);

			_context.MinorArmorTable.AddEntry(_context.MinorSpecificShields, 91);
			_context.MinorSpecificShields.AddEntry(new MagicItem("Specific Shield", "Shield Name", 2, 0), 1, false, true, true);
			_context.MinorArmorTable.AddEntry(new MagicItem("Armor Ability", "Ability", 0, 1), 100); //special abilites. ROLL AGAIN


			_context.MinorArmorAbilities.LoadFromFile("DMG Armor Special Abilities.Lewt", "Armor Ability", 3, "Minor");
			_context.MinorShieldAbilities.LoadFromFile("DMG Shield Special Abilities.Lewt", "Shield Ability", 3, "Minor");
			_context.MinorMeleeWeaponsAbilities.LoadFromFile("DMG Melee Weapon Special Abilities.Lewt", "Melee Weapon Ability", 3, "Minor");
			_context.MinorRangedWeaponsAbilities.LoadFromFile("DMG Ranged Weapon Special Abilities.Lewt", "Ranged Weapon Ability", 3, "Minor");

			_context.MinorMagicTable.AddEntry(_context.MinorWeaponsTable, 9);
			_context.MinorWeaponsTable.AddEntry(new MagicItem("Magic Weapon", "+1", 0, 1), 70);
			_context.MinorWeaponsTable.AddEntry(new MagicItem("Magic Weapon", "+2", 0, 2), 85);
			_context.MinorWeaponsTable.AddEntry(_context.MinorSpecificWeapons, 90);
			_context.MinorSpecificWeapons.AddEntry(new MagicItem("Specific Weapon", "Weapon Name", 2, 0), 1, false, true, true);
			_context.MinorWeaponsTable.AddEntry(new MagicItem("Weapon Ability", "Ability", 0, 1), 100);
			_context.MinorMagicTable.AddEntry(_context.MinorPotionsTable, 44);
			_context.MinorPotionsTable.AddEntry(new MagicItem("Potion", "Potion Name", 0, 0), 1, false, true, true);
			_context.MinorMagicTable.AddEntry(_context.MinorRingsTable, 46);
			_context.MinorRingsTable.AddEntry(new MagicItem("Ring", "Ring Name", 0, 0), 1, false, true, true);
			_context.MinorMagicTable.AddEntry(_context.MinorScrollsTable, 81);
			_context.MinorScrollsTable.AddEntry(new MagicItem("Scroll", "Scroll Name", 0, 0), 1, false, true, true);
			_context.MinorMagicTable.AddEntry(_context.MinorWandsTable, 91);
			_context.MinorWandsTable.AddEntry(new MagicItem("Wand", "Wand Name", 0, 0), 1, false, true, true);
			_context.MinorMagicTable.AddEntry(_context.MinorWondrousItemsTable, 100);
			_context.MinorWondrousItemsTable.AddEntry(new MagicItem("Wondrous Item", "Wondrous Item Name", 2, 0), 1, false, true, true);

			_context.MediumMagicTable.AddEntry(_context.MediumArmorTable, 10);
			_context.MediumArmorTable.AddEntry(new MagicItem("Magic Armor", "+1", 0, 1), 5);
			_context.MediumArmorTable.AddEntry(new MagicItem("Magic Shield", "+1", 0, 1), 10);
			_context.MediumArmorTable.AddEntry(new MagicItem("Magic Armor", "+2", 0, 2), 20);
			_context.MediumArmorTable.AddEntry(new MagicItem("Magic Shield", "+2", 0, 2), 30);
			_context.MediumArmorTable.AddEntry(new MagicItem("Magic Armor", "+3", 0, 3), 40);
			_context.MediumArmorTable.AddEntry(new MagicItem("Magic Shield", "+3", 0, 3), 50);
			_context.MediumArmorTable.AddEntry(new MagicItem("Magic Armor", "+4", 0, 4), 55);
			_context.MediumArmorTable.AddEntry(new MagicItem("Magic Shield", "+4", 0, 4), 57);
			_context.MediumArmorTable.AddEntry(_context.MediumSpecificArmors, 60);
			_context.MediumArmorTable.AddEntry(_context.MediumSpecificShields, 63);

			_context.MediumArmorTable.AddEntry(new MagicItem("Armor Ability", "Ability", 0, 1), 100); //special abilites. ROLL AGAIN

			_context.MediumArmorAbilitiesTable.LoadFromFile("DMG Armor Special Abilities.Lewt", "Armor Ability", 3, "Medium");
			_context.MediumShieldAbilitiesTable.LoadFromFile("DMG Shield Special Abilities.Lewt", "Shield Ability", 3, "Medium");
			_context.MediumMeleeWeaponsAbilitiesTable.LoadFromFile("DMG Melee Weapon Special Abilities.Lewt", "Melee Weapon Ability", 3, "Medium");
			_context.MediumRangedWeaponsAbilitiesTable.LoadFromFile("DMG Ranged Weapon Special Abilities.Lewt", "Ranged Weapon Ability", 3, "Medium");

			_context.MediumMagicTable.AddEntry(_context.MediumWeaponsTable, 20);
			_context.MediumWeaponsTable.AddEntry(new MagicItem("Magic Weapon", "+1", 0, 1), 10);
			_context.MediumWeaponsTable.AddEntry(new MagicItem("Magic Weapon", "+2", 0, 2), 29);
			_context.MediumWeaponsTable.AddEntry(new MagicItem("Magic Weapon", "+3", 0, 3), 58);
			_context.MediumWeaponsTable.AddEntry(new MagicItem("Magic Weapon", "+4", 0, 4), 62);
			_context.MediumWeaponsTable.AddEntry(_context.MediumSpecificWeapons, 68);

			_context.MediumWeaponsTable.AddEntry(new MagicItem("Weapon Ability", "Ability", 0, 1), 100);

			_context.MediumMagicTable.AddEntry(_context.MediumPotionsTable, 30);
			_context.MediumMagicTable.AddEntry(_context.MediumRingsTable, 40);
			_context.MediumMagicTable.AddEntry(_context.MediumRodsTable, 50);
			_context.MediumMagicTable.AddEntry(_context.MediumScrollsTable, 65);
			_context.MediumMagicTable.AddEntry(_context.MediumStaffsTable, 68);
			_context.MediumMagicTable.AddEntry(_context.MediumWandsTable, 83);
			_context.MediumMagicTable.AddEntry(_context.MediumWondrousItemsTable, 100);

			_context.MajorMagicTable.AddEntry(_context.MajorArmorTable, 10);
			_context.MajorArmorTable.AddEntry(new MagicItem("Magic Armor", "+3", 0, 3), 8);
			_context.MajorArmorTable.AddEntry(new MagicItem("Magic Shield", "+3", 0, 3), 16);
			_context.MajorArmorTable.AddEntry(new MagicItem("Magic Armor", "+4", 0, 4), 27);
			_context.MajorArmorTable.AddEntry(new MagicItem("Magic Shield", "+4", 0, 4), 38);
			_context.MajorArmorTable.AddEntry(new MagicItem("Magic Armor", "+5", 0, 5), 49);
			_context.MajorArmorTable.AddEntry(new MagicItem("Magic Shield", "+5", 0, 5), 57);
			_context.MajorArmorTable.AddEntry(_context.MajorSpecificArmors, 60);
			_context.MajorArmorTable.AddEntry(_context.MajorSpecificShields, 63);
			_context.MajorArmorTable.AddEntry(new MagicItem("Armor Ability", "Ability", 0, 1), 100); //special abilites. ROLL AGAIN

			_context.MajorArmorAbilitiesTable.LoadFromFile("DMG Armor Special Abilities.Lewt", "Armor Ability", 3, "Major");
			_context.MajorArmorAbilitiesTable.LoadFromFile("DMG Shield Special Abilities.Lewt", "Shield Ability", 3, "Major");

			_context.MajorMeleeWeaponsAbilitiesTable.LoadFromFile("DMG Melee Weapon Special Abilities.Lewt", "Melee Weapon Ability", 3, "Major");
			_context.MajorRangedWeaponsAbilitiesTable.LoadFromFile("DMG Ranged Weapon Special Abilities.Lewt", "Ranged Weapon Ability", 3, "Major");

			_context.MajorMagicTable.AddEntry(_context.MajorWeaponsTable, 20);
			_context.MajorWeaponsTable.AddEntry(new MagicItem("Magic Weapon", "+3", 0, 3), 20);
			_context.MajorWeaponsTable.AddEntry(new MagicItem("Magic Weapon", "+4", 0, 4), 38);
			_context.MajorWeaponsTable.AddEntry(new MagicItem("Magic Weapon", "+5", 0, 5), 49);
			_context.MajorWeaponsTable.AddEntry(_context.MajorSpecificWeapons, 63);

			_context.MajorWeaponsTable.AddEntry(new MagicItem("Weapon Ability", "Ability", 0, 1), 100);

			_context.MajorMagicTable.AddEntry(_context.MajorPotionsTable, 25);
			_context.MajorMagicTable.AddEntry(_context.MajorRingsTable, 35);
			_context.MajorMagicTable.AddEntry(_context.MajorRodsTable, 45);
			_context.MajorMagicTable.AddEntry(_context.MajorScrollsTable, 55);
			_context.MajorMagicTable.AddEntry(_context.MajorStaffsTable, 75);
			_context.MajorMagicTable.AddEntry(_context.MajorWandsTable, 80);
			_context.MajorMagicTable.AddEntry(_context.MajorWondrousItemsTable, 100);

			#endregion

			#region GOODSTABLE ENTRIES
			_context.GemTable.AddEntry(_context.LowestGemTable, 25);
			_context.GemTable.AddEntry(_context.LowerGemTable, 50);
			_context.GemTable.AddEntry(_context.LowGemTable, 70);
			_context.GemTable.AddEntry(_context.HighGemTable, 90);
			_context.GemTable.AddEntry(_context.HigherGemTable, 99);
			_context.GemTable.AddEntry(_context.HighestGemTable, 100);

			_context.LowestGemTable.LoadFromFile("LowestValueGems.Lewt", "Lowest Value Gem", 2, "");
			_context.LowerGemTable.LoadFromFile("LowerValueGems.Lewt", "Lower Value Gem", 2, "");
			_context.LowGemTable.LoadFromFile("LowValueGems.Lewt", "Low Value Gem", 2, "");
			_context.HighGemTable.LoadFromFile("HighValueGems.Lewt", "High Value Gem", 2, "");
			_context.HigherGemTable.LoadFromFile("HigherValueGems.Lewt", "Higher Value Gem", 2, "");
			_context.HighestGemTable.LoadFromFile("HighestValueGems.Lewt", "Highest Value Gem", 2, "");
			#endregion
		}
	}
}
