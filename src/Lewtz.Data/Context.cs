namespace Lewtz.Data
{
	internal sealed class Context : DataContext
	{
		public Table Coins { get; private set; } = new Table();

		#region GOODS TABLE
		public Table GoodsTable { get; private set; } = new Table();

		public Table ArtTable { get; private set; } = new Table();

		public Table GemTable { get; private set; } = new Table();
		public Table LowestGemTable { get; private set; } = new Table();
		public Table LowerGemTable { get; private set; } = new Table();
		public Table LowGemTable { get; private set; } = new Table();
		public Table HighGemTable { get; private set; } = new Table();
		public Table HigherGemTable { get; private set; } = new Table();
		public Table HighestGemTable { get; private set; } = new Table();
		#endregion

		#region ITEMSTABLE
		public Table ItemsTable { get; private set; } = new Table();
		public Table MundaneItemsTable { get; private set; } = new Table();
		public Table ToolsGear { get; private set; } = new Table();

		public Table AlchemicalItemsTable { get; private set; } = new Table();

		public Table ArmorTable { get; private set; } = new Table();
		public Table DarkwoodShields { get; private set; } = new Table();
		public Table Shields { get; private set; } = new Table();

		public Table WeaponsTable { get; private set; } = new Table();
		public Table CommonWeapons { get; private set; } = new Table();
		public Table UncommonWeapons { get; private set; } = new Table();
		public Table CommonRangedWeapons { get; private set; } = new Table();
		public Table UncommonRangedWeapons { get; private set; } = new Table();

		public Table MagicItemsTable { get; private set; } = new Table();

		public Table MinorMagicTable { get; private set; } = new Table();
		public Table MinorArmorTable { get; private set; } = new Table();
		public Table MinorSpecificArmors { get; private set; } = new Table();
		public Table MinorArmorAbilities { get; private set; } = new Table();

		public Table MinorShieldsTable { get; private set; } = new Table();
		public Table MinorSpecificShields { get; private set; } = new Table();
		public Table MinorShieldAbilities { get; private set; } = new Table();

		public Table MinorWeaponsTable { get; private set; } = new Table();
		public Table MinorSpecificWeapons { get; private set; } = new Table();
		public Table MinorMeleeWeaponsAbilities { get; private set; } = new Table();
		public Table MinorRangedWeaponsAbilities { get; private set; } = new Table();

		public Table MinorPotionsTable { get; private set; } = new Table();
		public Table MinorRingsTable { get; private set; } = new Table();
		public Table MinorRodsTable { get; private set; } = new Table();
		public Table MinorScrollsTable { get; private set; } = new Table();
		public Table MinorStaffTable { get; private set; } = new Table();
		public Table MinorWandsTable { get; private set; } = new Table();
		public Table MinorWondrousItemsTable { get; private set; } = new Table();

		public Table MediumMagicTable { get; private set; } = new Table();
		public Table MediumSpecificArmors { get; private set; } = new Table();
		public Table MediumArmorTable { get; private set; } = new Table();
		public Table MediumArmorAbilitiesTable { get; private set; } = new Table();

		public Table MediumShieldsTable { get; private set; } = new Table();
		public Table MediumSpecificShields { get; private set; } = new Table();
		public Table MediumShieldAbilities { get; private set; } = new Table();
		public Table MediumShieldAbilitiesTable { get; private set; } = new Table();

		public Table MediumWeaponsTable { get; private set; } = new Table();
		public Table MediumSpecificWeapons { get; private set; } = new Table();
		public Table MediumMeleeWeaponsAbilitiesTable { get; private set; } = new Table();
		public Table MediumRangedWeaponsAbilitiesTable { get; private set; } = new Table();
		public Table MediumPotionsTable { get; private set; } = new Table();
		public Table MediumRingsTable { get; private set; } = new Table();
		public Table MediumRodsTable { get; private set; } = new Table();
		public Table MediumScrollsTable { get; private set; } = new Table();
		public Table MediumStaffsTable { get; private set; } = new Table();
		public Table MediumWandsTable { get; private set; } = new Table();
		public Table MediumWondrousItemsTable { get; private set; } = new Table();

		public Table MajorMagicTable { get; private set; } = new Table();
		public Table MajorArmorTable { get; private set; } = new Table();
		public Table MajorSpecificArmors { get; private set; } = new Table();
		public Table MajorArmorAbilitiesTable { get; private set; } = new Table();

		public Table MajorShieldsTable { get; private set; } = new Table();
		public Table MajorSpecificShields { get; private set; } = new Table();
		public Table MajorShieldAbilities { get; private set; } = new Table();
		public Table MajorShieldAbilitiesTable { get; private set; } = new Table();

		public Table MajorWeaponsTable { get; private set; } = new Table();
		public Table MajorSpecificWeapons { get; private set; } = new Table();
		public Table MajorMeleeWeaponsAbilitiesTable { get; private set; } = new Table();
		public Table MajorRangedWeaponsAbilitiesTable { get; private set; } = new Table();
		public Table MajorPotionsTable { get; private set; } = new Table();
		public Table MajorRingsTable { get; private set; } = new Table();
		public Table MajorRodsTable { get; private set; } = new Table();
		public Table MajorScrollsTable { get; private set; } = new Table();
		public Table MajorStaffsTable { get; private set; } = new Table();
		public Table MajorWandsTable { get; private set; } = new Table();
		public Table MajorWondrousItemsTable { get; private set; } = new Table();
		#endregion //ITEMSTABLE 
	}
}
