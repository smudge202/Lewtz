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
    public partial class FormLewtz : Form
    {
        public FormLewtz()
        {
            InitializeComponent(); 
            LoadTables();
        }
        private int hoardCount = 0;
        private double CoinMultiplier = 1;
        private double ItemMultiplier = 1;
        private double GoodsMultiplier = 1;

        Random rand = new Random(); //used for calculating dice roll values


        //FIX THIS SHIT. CREATE A NEW CLASS FOR EVERY TABLE TYPE? -> TreasureTable : RDSTable
        RDSTable TreasureTable = new RDSTable(); //used for top-tier random drops of tons of subtables

        //If the table ends in (-Table), the table includes subtables (ItemTable include minor, medium, etc)
        //Entries NOT ending in (-Table) are loaded from files
        #region TABLE DECLARATIONS

        private RDSTable Coins = new RDSTable(); //change this to something else?

        #region GOODS TABLE
        private RDSTable GoodsTable = new RDSTable(); //GoodsTable : RDSTable -> load the tabbed thigns into this table

            private RDSTable ArtTable = new RDSTable();

            private RDSTable GemTable = new RDSTable();
                private RDSTable LowestGemTable =  new RDSTable();
                private RDSTable LowerGemTable =   new RDSTable();
                private RDSTable LowGemTable =     new RDSTable();
                private RDSTable HighGemTable =    new RDSTable();  //CHANGE THEM ALL
                private RDSTable HigherGemTable =  new RDSTable();
                private RDSTable HighestGemTable = new RDSTable();
        #endregion

        #region ITEMSTABLE
        private RDSTable ItemsTable = new RDSTable();
            private RDSTable MundaneItemsTable = new RDSTable();
                private RDSTable ToolsGear = new RDSTable();

                private RDSTable AlchemicalItemsTable = new RDSTable();

                private RDSTable ArmorTable = new RDSTable();
                    private RDSTable DarkwoodShields = new RDSTable();
                    private RDSTable Shields = new RDSTable();

                private RDSTable WeaponsTable = new RDSTable();
                    private RDSTable CommonWeapons = new RDSTable();
                    private RDSTable UncommonWeapons = new RDSTable();
                    private RDSTable CommonRangedWeapons = new RDSTable();
                    private RDSTable UncommonRangedWeapons = new RDSTable(); ///CHHAAAANNNGEEEE THESSEE

            private RDSTable MagicItemsTable = new RDSTable(); //used to store dynamically created weapons and armor

                private RDSTable MinorMagicTable = new RDSTable();
                    private RDSTable MinorArmorTable = new RDSTable();
                        private RDSTable MinorSpecificArmors = new RDSTable();
                        private RDSTable MinorArmorAbilities = new RDSTable();

                    private RDSTable MinorShieldsTable = new RDSTable();
                        private RDSTable MinorSpecificShields = new RDSTable();
                        private RDSTable MinorShieldAbilities = new RDSTable();
                        //private RDSTable MinorShieldAbilitiesTable = new RDSTable();

                    private RDSTable MinorWeaponsTable = new RDSTable();
                        private RDSTable MinorSpecificWeapons = new RDSTable();
                        private RDSTable MinorMeleeWeaponsAbilities = new RDSTable();
                        private RDSTable MinorRangedWeaponsAbilities = new RDSTable();

                    private RDSTable MinorPotionsTable =       new RDSTable();
                    private RDSTable MinorRingsTable =         new RDSTable();
                    private RDSTable MinorRodsTable =          new RDSTable();
                    private RDSTable MinorScrollsTable =       new RDSTable();
                    private RDSTable MinorStaffTable =         new RDSTable();
                    private RDSTable MinorWandsTable =         new RDSTable();
                    private RDSTable MinorWondrousItemsTable = new RDSTable();
                    
                private RDSTable MediumMagicTable = new RDSTable();
                    private RDSTable MediumSpecificArmors = new RDSTable();
                    private RDSTable MediumArmorTable = new RDSTable();
                    private RDSTable MediumArmorAbilitiesTable = new RDSTable();

                    private RDSTable MediumShieldsTable = new RDSTable();
                        private RDSTable MediumSpecificShields = new RDSTable();
                        private RDSTable MediumShieldAbilities = new RDSTable();
                        private RDSTable MediumShieldAbilitiesTable = new RDSTable();

                    private RDSTable MediumWeaponsTable = new RDSTable();
                        private RDSTable MediumSpecificWeapons = new RDSTable();
                        private RDSTable MediumMeleeWeaponsAbilitiesTable = new RDSTable();
                        private RDSTable MediumRangedWeaponsAbilitiesTable = new RDSTable();
                    private RDSTable MediumPotionsTable = new RDSTable();
                    private RDSTable MediumRingsTable = new RDSTable();
                    private RDSTable MediumRodsTable = new RDSTable();
                    private RDSTable MediumScrollsTable = new RDSTable();
                    private RDSTable MediumStaffsTable = new RDSTable();
                    private RDSTable MediumWandsTable = new RDSTable();
                    private RDSTable MediumWondrousItemsTable = new RDSTable();
                    
                private RDSTable MajorMagicTable = new RDSTable();
                    private RDSTable MajorArmorTable = new RDSTable();
                        private RDSTable MajorSpecificArmors = new RDSTable();
                        private RDSTable MajorArmorAbilitiesTable = new RDSTable();

                    private RDSTable MajorShieldsTable = new RDSTable();
                        private RDSTable MajorSpecificShields = new RDSTable();
                        private RDSTable MajorShieldAbilities = new RDSTable();
                        private RDSTable MajorShieldAbilitiesTable = new RDSTable();

                    private RDSTable MajorWeaponsTable = new RDSTable();
                        private RDSTable MajorSpecificWeapons = new RDSTable();
                        private RDSTable MajorMeleeWeaponsAbilitiesTable = new RDSTable();
                        private RDSTable MajorRangedWeaponsAbilitiesTable = new RDSTable();
                    private RDSTable MajorPotionsTable = new RDSTable();
                    private RDSTable MajorRingsTable = new RDSTable();
                    private RDSTable MajorRodsTable = new RDSTable();
                    private RDSTable MajorScrollsTable = new RDSTable();
                    private RDSTable MajorStaffsTable = new RDSTable();
                    private RDSTable MajorWandsTable = new RDSTable();
                    private RDSTable MajorWondrousItemsTable = new RDSTable();
                #endregion //ITEMSTABLE 

        #endregion //DECLARATIONS


       private void btnAddTreasure_Click(object sender, EventArgs e)
        {
            hoardCount++; //add one to the number of groups of controls
            if (hoardCount > 9)
            {
                hoardCount = 9;
                textBox1.Text = "You really need that much loot? Shiiit!";
            }
            else
            {
                textBox1.Text = "";
                GroupAddRemove(hoardCount, true); //make the next set of buttons visible
            }
        }


        private void btnRemoveTreasure_Click(object sender, EventArgs e)
        {
            GroupAddRemove(hoardCount, false); //make the last set of buttons go away
            hoardCount--;
        }

        
        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void GenerateLootButton_Click(object sender, EventArgs e)
        {
            int numberOfRolls = 0;
            textBox1.Text = "";
            textBox2.Text = "";

            #region CHECKBOX1
            if (CheckBox1.Checked == true)
            { 
                #region COINS MULTIPLIER
                switch(CoinsBox1.Text)
                {
                    case "None":
                        Coins.rdsEnabled = false;
                        CoinMultiplier = 0;
                        break;
                    case "1/10":
                        Coins.rdsEnabled = true;
                        CoinMultiplier = 0.1;
                        break;
                    case "Half":
                        Coins.rdsEnabled = true;
                        CoinMultiplier = 0.5;
                        break;
                    case "Double":
                        Coins.rdsEnabled = true;
                        CoinMultiplier = 2;
                        break;
                    case "Triple":
                        Coins.rdsEnabled = true;
                        CoinMultiplier = 3;
                        break;
                    default:
                        Coins.rdsEnabled = true;
                        CoinMultiplier = 1;
                        break;
                }
                #endregion

                #region ITEMS MULTIPLIER
                switch (ItemsBox1.Text)
                {
                    case "None":
                        ItemsTable.rdsEnabled = false;
                        ItemMultiplier = 0;
                        break;
                    case "Half":
                        ItemsTable.rdsEnabled = true;
                        ItemMultiplier = 0.5;
                        break;
                    case "Double":
                        ItemsTable.rdsEnabled = true;
                        ItemMultiplier = 2;
                        break;
                    case "Triple":
                        ItemsTable.rdsEnabled = true;
                        ItemMultiplier = 3;
                        break;
                    default:
                        ItemsTable.rdsEnabled = true;
                        ItemMultiplier = 1;
                        break;
                }
                #endregion

                #region GOODS MULTIPLIER
                switch (GoodsBox1.Text)
                {
                    case "None":
                        GoodsTable.rdsEnabled = false;
                        GoodsMultiplier = 0;
                        break;
                    case "Half":
                        GoodsTable.rdsEnabled = true;
                        GoodsMultiplier = 0.5;
                        break;
                    case "Double":
                        GoodsTable.rdsEnabled = true;
                        GoodsMultiplier = 2;
                        break;
                    case "Triple":
                        GoodsTable.rdsEnabled = true;
                        GoodsMultiplier = 3;
                        break;
                    default:
                        GoodsTable.rdsEnabled = true;
                        GoodsMultiplier = 1;
                        break;
                }
                #endregion

                #region INCLUDE ALCHEMICAL ITEMS
                if (chkIncludeAlchemy.Checked == true)
                {
                    AlchemicalItemsTable.rdsEnabled = true;
                }
                else
                {
                    AlchemicalItemsTable.rdsEnabled = false;
                }
                #endregion

                #region INCLUDE WEAPONS
                if (chkIncludeWeapons.Checked == true)
                {
                    WeaponsTable.rdsEnabled = true;
                }
                else
                {
                    WeaponsTable.rdsEnabled = false;
                }
                #endregion

                #region INCLUDE ARMOR
                if (chkIncludeArmor.Checked == true)
                {
                    ArmorTable.rdsEnabled = true;
                }
                else
                {
                    ArmorTable.rdsEnabled = false;
                }
                #endregion

                #region INCLUDE SALVAGE/TOOLS
                if (chkIncludeSalvage.Checked == true)
                {
                    ToolsGear.rdsEnabled = true;
                }
                else
                {
                    ToolsGear.rdsEnabled = false;
                }
                #endregion

                #region INCLUDE GEMS
                if (chkIncludeGems.Checked == true)
                {
                    GemTable.rdsEnabled = true;
                }
                else
                {
                    GemTable.rdsEnabled = false;
                }
                #endregion

                #region INCLUDE MAGIC ITEMS
                if (chkIncludeMagic.Checked == true)
                {
                    MagicItemsTable.rdsEnabled = true;
                }
                else
                {
                    MagicItemsTable.rdsEnabled = false;
                }
                #endregion

                #region INCLUDE MINOR
                if (chkIncludeMinor.Checked == true)
                {
                    MinorMagicTable.rdsEnabled = true;
                }
                else
                {
                    MinorMagicTable.rdsEnabled = false;
                }
                #endregion

                string text = "";
                

                if (!int.TryParse(NumberToRollBox1.Text, out numberOfRolls) || numberOfRolls > 500 || numberOfRolls < 1)
                {
                    textBox1.Text = "Roll with integers between 1 and 500, douchefeck";
                }
                else
                {
                    for (int i = 0; i < numberOfRolls; i++)
                    {
                        ChooseLevel(int.Parse(LevelBox1.Text));
                        double totalCopper = 0;
                        double totalSilver = 0;
                        double totalGold = 0;
                        double totalPlatinum = 0;

                        if (!chkCombineHoards.Checked)
                        {
                            text += "--------HOARD " + (i + 1) + "--------\r\n";
                        }

                        foreach (Item m in TreasureTable.rdsResult)
                        {
                            if (m.GetItemType() == "" || m.ToString() == "") continue;

                            switch(m.GetItemType())
                            {
                                case "Lowest Value Gem":
                                    m.SetCost(RollDice(4, 4, 100));
                                    break;
                                case "Lower Value Gem":
                                    m.SetCost(RollDice(2, 4, 1000));
                                    break;
                                case "Low Value Gem":
                                    m.SetCost(RollDice(4, 4, 1000));
                                    break;
                                case "High Value Gem":
                                    m.SetCost(RollDice(2, 4, 10000));
                                    break;
                                case "Higher Value Gem":
                                    m.SetCost(RollDice(4, 4, 10000));
                                    break;
                                case "Highest Value Gem":
                                    m.SetCost(RollDice(2, 4, 100000));
                                    break;

                                case "Coin":
                                    switch (m.ToString())
                                    {
                                        case "Copper Piece":
                                            totalCopper += (m.GetCost() * ((CoinMultiplier < 1) ? CoinMultiplier : 1));
                                            break;
                                        case "Silver Piece":
                                            totalSilver += (m.GetCost() * ((CoinMultiplier < 1) ? CoinMultiplier : 1));
                                            break;
                                        case "Gold Piece":
                                            totalGold += (m.GetCost() * ((CoinMultiplier < 1) ? CoinMultiplier : 1));
                                            break;
                                        case "Platinum Piece":
                                            totalPlatinum += (m.GetCost() * ((CoinMultiplier < 1) ? CoinMultiplier : 1));
                                            break;
                                        default:
                                            textBox2.Text += "SHIT MANS";
                                            break;
                                    }
                                    break;
                                default:
                                    break;
                            }
                            if (m.GetItemType() != "Coin")
                            {
                                text += m.ToString() + " worth " + (m.GetCost() / 100) + " GP\r\n"; //"Dagger worth 2 GP"
                            }
                        }
                        text += (totalCopper > 0)   ? "" + totalCopper   + " Copper Pieces\r\n"    : "";
                        text += (totalSilver > 0)   ? "" + totalSilver   + " Silver Pieces\r\n"    : "";
                        text += (totalGold > 0)     ? "" + totalGold     + " Gold Pieces\r\n"      : "";
                        text += (totalPlatinum > 0) ? "" + totalPlatinum + " Platinum Pieces\r\n"  : "";
                    }
                }
                textBox1.Text = text;
            }
            #endregion

        }


        private void ChooseLevel(int p)
        {
            TreasureTable.ClearContents();
            Coins.ClearContents();
            ItemsTable.ClearContents();
            GoodsTable.ClearContents();

            MagicItemsTable.ClearContents();
            //MinorMagicTable.ClearContents();

            textBox2.Text = "";

            #region +10 EPIC SWITCH OF TABLE SETTING
            switch (p)
            {
                case 1: 
                    Coins.AddEntry(new Item(),14);
                    Coins.AddEntry(new Item("Coin","Copper Piece",   RollDice(1, 6, 1000)),29); //1d6*1000 CP
                    Coins.AddEntry(new Item("Coin","Silver Piece",   RollDice(1, 8, 100)),52); //1d8*100 SP
                    Coins.AddEntry(new Item("Coin","Gold Piece",     RollDice(2, 8, 10)),95); //2d8*10 GP
                    Coins.AddEntry(new Item("Coin","Platinum Piece", RollDice(1, 4, 10)),100); //1d4*10 PP
 
                    ItemsTable.AddEntry(new Item(),71); //give nothing on this roll
                    ItemsTable.AddEntry(MundaneItemsTable, 95);
                        MundaneItemsTable.rdsCount = 1; //maximum of 1 mundane item
                    ItemsTable.AddEntry(MagicItemsTable, 100);
                            //MinorMagicTable.rdsCount = 1; //maximum of 1 Minor Magic item

                   
                     MagicItemsTable.AddEntry(GenerateItem("Minor"),0,true,false,true);
                    //MagicItemsTable.rdsCount = 1;
                    //MagicItemsTable.rdsAlways = true;

                    //MagicItemsTable.AddEntry(GenerateItem("Minor"),1,false,true,true);
                    //MagicItemsTable.rdsCount = 1;
                    //MagicItemsTable.rdsAlways = true;
                    
                    GoodsTable.AddEntry(new Item(),90);
                    GoodsTable.AddEntry(GemTable,95);
                    GoodsTable.AddEntry(ArtTable, 100);

                        GemTable.rdsCount = 1;
                        ArtTable.rdsCount = 1;
                    break;
                case 2:
                    Coins.AddEntry(new Item(),13);
                    Coins.AddEntry(new Item("Coin","Copper Piece",   RollDice(1, 10, 1000)),23); //1d10*1000 cp
                    Coins.AddEntry(new Item("Coin","Silver Piece",   RollDice(2, 10, 100)), 43); //2d10*100 SP
                    Coins.AddEntry(new Item("Coin","Gold Piece",     RollDice(4, 10, 10)),  95); //4d10*10 GP
                    Coins.AddEntry(new Item("Coin","Platinum Piece", RollDice(2, 8,  10)),  100); //2d8*10 PP

                    ItemsTable.AddEntry(new Item(),49); //give nothing on this roll
                    ItemsTable.AddEntry(MundaneItemsTable, 85);
                        MundaneItemsTable.rdsCount = 1; //maximum of 1 mundane item
                    ItemsTable.AddEntry(MagicItemsTable,100);

                    MagicItemsTable.AddEntry(GenerateItem("Minor"),1,false,true,true);
                    MagicItemsTable.rdsCount = 1;
                    MagicItemsTable.rdsAlways = true;
                        //MinorMagicTable.rdsCount = 1; //maximum of 1 Minor Magic item

                    //Med

                    GoodsTable.AddEntry(new Item(),81);
                    GoodsTable.AddEntry(GemTable,95);
                    GoodsTable.AddEntry(ArtTable, 100);

                        GemTable.rdsCount = RollDice(1,4,1);// (rand.Next(3) + 1);
                        ArtTable.rdsCount = RollDice(1,3,1);
                    break;

                #region FORNOW
                case 3:
                    Coins.AddEntry(new Item(),11);
                    Coins.AddEntry(new Item("Coin","Copper Piece",   RollDice(2, 10, 1000)),21); //2d10*1000 cp
                    Coins.AddEntry(new Item("Coin","Silver Piece",   RollDice(4, 8, 100)),41); //4d8*100 SP
                    Coins.AddEntry(new Item("Coin","Gold Piece",     RollDice(1, 4, 100)),95); //1d4*100 GP
                    Coins.AddEntry(new Item("Coin","Platinum Piece", RollDice(1, 10, 10)),100); //1d10*10 PP

                    ItemsTable.AddEntry(new Item(),49); //give nothing on this roll
                    ItemsTable.AddEntry(MundaneItemsTable, 79);
                        MundaneItemsTable.rdsCount = RollDice(1, 3, 1); //1d3 mundane item
                    ItemsTable.AddEntry(MagicItemsTable, 100);
                        MinorMagicTable.rdsCount = 1; //maximum of 1 Minor Magic item

                        for (int i = 0; i < RollDice(1, 3, 1); i++)
                        {
                            MagicItemsTable.AddEntry(GenerateItem("Minor"), 1, false, true, true);
                        }

                    GoodsTable.AddEntry(new Item(),77);
                    GoodsTable.AddEntry(GemTable,95);
                    GoodsTable.AddEntry(ArtTable, 100);

                        GemTable.rdsCount = RollDice(1,3,1);
                        ArtTable.rdsCount = RollDice(1,3,1); 
                    break;
                case 4:
                    Coins.AddEntry(new Item(),11);
                    Coins.AddEntry(new Item("Coin","Copper Piece",   RollDice(3, 10, 1000)),21); //3d10*1000 cp
                    Coins.AddEntry(new Item("Coin","Silver Piece",   RollDice(4, 12, 1000)),41); //4d12*100 SP
                    Coins.AddEntry(new Item("Coin","Gold Piece",     RollDice(1, 6, 100)),95); //1d6*100 GP
                    Coins.AddEntry(new Item("Coin","Platinum Piece", RollDice(1, 10, 10)),100); //1d10*10 PP

                    ItemsTable.AddEntry(new Item(),42); //give nothing on this roll
                    ItemsTable.AddEntry(MundaneItemsTable, 62);
                    ItemsTable.AddEntry(MinorMagicTable, 100);
                        MundaneItemsTable.rdsCount = RollDice(1,4,1); //1d4 mundane item
                        MinorMagicTable.rdsCount = 1; //maximum of 1 Minor Magic item

                    GoodsTable.AddEntry(new Item(),70);
                    GoodsTable.AddEntry(GemTable,95);
                    GoodsTable.AddEntry(ArtTable, 100);

                        GemTable.rdsCount = RollDice(1,4,1);
                        ArtTable.rdsCount = RollDice(1,3,1);
                    break;
                case 5:
                    Coins.AddEntry(new Item(),10);
                    Coins.AddEntry(new Item("Coin","Copper Piece",   RollDice(1, 4, 10000)),19); //3d10*1000 cp
                    Coins.AddEntry(new Item("Coin","Silver Piece",   RollDice(1, 6, 1000)),38); //4d12*100 SP
                    Coins.AddEntry(new Item("Coin","Gold Piece",     RollDice(1, 8, 100)),95); //1d6*100 GP
                    Coins.AddEntry(new Item("Coin","Platinum Piece", RollDice(1, 10, 10)),100); //1d10*10 PP

                    ItemsTable.AddEntry(new Item(),57); //give nothing on this roll
                    ItemsTable.AddEntry(MundaneItemsTable, 67);
                    ItemsTable.AddEntry(MinorMagicTable, 100);
                        MundaneItemsTable.rdsCount = RollDice(1,4,1); //1d4 mundane item
                        MinorMagicTable.rdsCount = RollDice(1,3,1); //1d3 Minor Magic item

                    GoodsTable.AddEntry(new Item(),60);
                    GoodsTable.AddEntry(GemTable,95);
                    GoodsTable.AddEntry(ArtTable, 100);

                        GemTable.rdsCount = RollDice(1,4,1);
                        ArtTable.rdsCount = RollDice(1,4,1);
                    break;
                case 6:
                    Coins.AddEntry(new Item(),10);
                    Coins.AddEntry(new Item("Coin","Copper Piece",   RollDice(1, 6, 10000)),18); //1d6*10000 cp
                    Coins.AddEntry(new Item("Coin","Silver Piece",   RollDice(1, 8, 1000)),37); //1d8*1000 SP
                    Coins.AddEntry(new Item("Coin","Gold Piece",     RollDice(1, 10, 100)),95); //1d10*100 GP
                    Coins.AddEntry(new Item("Coin","Platinum Piece", RollDice(1, 12, 10)),100); //1d12*10 PP
         
                    ItemsTable.AddEntry(new Item(),54); //give nothing on this roll
                    ItemsTable.AddEntry(MundaneItemsTable, 59);
                    ItemsTable.AddEntry(MinorMagicTable, 99);
                    ItemsTable.AddEntry(MediumMagicTable, 100);// only on a roll of 100
                        MundaneItemsTable.rdsCount = RollDice(1,4,1); //1d4 mundane item
                        MinorMagicTable.rdsCount = RollDice(1,3,1); //1d3 Minor Magic item
                        MediumMagicTable.rdsCount = 1;
                            //PotionsTable.AddEntry(new MagicItem("Potion", WeaponsTable, MinorMagicTable, 1), 100);

                    GoodsTable.AddEntry(new Item(),56);
                    GoodsTable.AddEntry(GemTable,92);
                    GoodsTable.AddEntry(ArtTable, 100);

                        GemTable.rdsCount = RollDice(1,4,1);
                        ArtTable.rdsCount = RollDice(1,4,1);
                    break;
                case 7:
                    Coins.AddEntry(new Item(),11);
                    Coins.AddEntry(new Item("Coin","Copper Piece",   RollDice(1, 10, 10000)),18); //1d10*10000 CP
                    Coins.AddEntry(new Item("Coin","Silver Piece",   RollDice(1, 12, 1000)),35); //1d12*1000 SP
                    Coins.AddEntry(new Item("Coin","Gold Piece",     RollDice(2, 6, 100)),93); //2d6*100 GP
                    Coins.AddEntry(new Item("Coin","Platinum Piece", RollDice(3, 4, 10)),100); //3d4*10 PP

                    ItemsTable.AddEntry(new Item(),51); //give nothing on this roll
                    ItemsTable.AddEntry(MinorMagicTable, 96);
                    ItemsTable.AddEntry(MediumMagicTable, 100);
                        MinorMagicTable.rdsCount = RollDice(1,3,1); //1d3 Minor Magic item
                        MediumMagicTable.rdsCount = 1;

                    GoodsTable.AddEntry(new Item(),48);
                    GoodsTable.AddEntry(GemTable,88);
                    GoodsTable.AddEntry(ArtTable, 100);

                        GemTable.rdsCount = RollDice(1,4,1);
                        ArtTable.rdsCount = RollDice(1,4,1);
                    break;
                case 8:
                    
                    Coins.AddEntry(new Item(),10);
                    Coins.AddEntry(new Item("Coin","Copper Piece",   RollDice(1, 12, 10000)),15); //1d10*10000 cp
                    Coins.AddEntry(new Item("Coin","Silver Piece",   RollDice(2, 6, 1000)),29); //2d6*1000 SP
                    Coins.AddEntry(new Item("Coin","Gold Piece",     RollDice(2, 8, 100)),93); //2d8*100 GP
                    Coins.AddEntry(new Item("Coin","Platinum Piece", RollDice(3, 6, 10)),100); //3d6*10 PP

                    ItemsTable.AddEntry(new Item(),48); //give nothing on this roll
                    ItemsTable.AddEntry(MinorMagicTable, 96);
                    ItemsTable.AddEntry(MediumMagicTable, 100);
                        MinorMagicTable.rdsCount = RollDice(1,4,1); //1d4 Minor Magic item
                        MediumMagicTable.rdsCount = 1;

                    GoodsTable.AddEntry(new Item(),45);
                    GoodsTable.AddEntry(GemTable,85);
                    GoodsTable.AddEntry(ArtTable, 100);

                        GemTable.rdsCount = RollDice(1, 6, 1);
                        ArtTable.rdsCount = RollDice(1, 4, 1);
                    break;
                case 9:                  
                    Coins.AddEntry(new Item(),10);
                    Coins.AddEntry(new Item("Coin","Copper Piece",   RollDice(2, 6, 10000)),15); //2d6*10000 cp
                    Coins.AddEntry(new Item("Coin","Silver Piece",   RollDice(2, 8, 1000)),29); //2d8*1000 SP
                    Coins.AddEntry(new Item("Coin","Gold Piece",     RollDice(5, 4, 100)),85); //5d4*100 GP
                    Coins.AddEntry(new Item("Coin","Platinum Piece", RollDice(2, 12, 10)),100); //2d12*10 PP
 
                    ItemsTable.AddEntry(new Item(),43); //give nothing on this roll
                    ItemsTable.AddEntry(MinorMagicTable, 91);
                    ItemsTable.AddEntry(MediumMagicTable, 100);
                        MinorMagicTable.rdsCount = RollDice(1,4,1); //1d4 Minor Magic item
                        MediumMagicTable.rdsCount = 1;

                    GoodsTable.AddEntry(new Item(),40);
                    GoodsTable.AddEntry(GemTable,89);
                    GoodsTable.AddEntry(ArtTable, 100);

                        GemTable.rdsCount = RollDice(1, 8, 1);
                        ArtTable.rdsCount = RollDice(1, 4, 1);
                    break;
                case 10:                  
                    Coins.AddEntry(new Item(),10);
                    Coins.AddEntry(new Item("Coin","Silver Piece",   RollDice(2, 10, 1000)),24); //2d10*1000 SP
                    Coins.AddEntry(new Item("Coin","Gold Piece",     RollDice(6, 4, 100)),79); //6d4*100 GP
                    Coins.AddEntry(new Item("Coin","Platinum Piece", RollDice(5, 6, 10)),100); //5d6*10 PP

                    ItemsTable.AddEntry(new Item(),40); //give nothing on this roll
                    ItemsTable.AddEntry(MinorMagicTable, 88);
                    ItemsTable.AddEntry(MediumMagicTable, 99);
                    ItemsTable.AddEntry(MajorMagicTable, 100);
                        MinorMagicTable.rdsCount = (rand.Next(4)+1); //1d4 Minor Magic item
                        MediumMagicTable.rdsCount = 1;
                        MajorMagicTable.rdsCount = 1;

                    GoodsTable.AddEntry(new Item(),35);
                    GoodsTable.AddEntry(GemTable,79);
                    GoodsTable.AddEntry(ArtTable, 100);

                        GemTable.rdsCount = RollDice(1, 8, 1);
                        ArtTable.rdsCount = RollDice(1, 6, 1);
                    break;
                case 11:
                    Coins.AddEntry(new Item(),8);
                    Coins.AddEntry(new Item("Coin","Silver Piece",   RollDice(3, 10, 1000)),14); //3d10*1000 SP
                    Coins.AddEntry(new Item("Coin","Gold Piece",     RollDice(4, 8, 100)),75); //4d8*100 GP
                    Coins.AddEntry(new Item("Coin","Platinum Piece", RollDice(4, 10, 10)),100); //4d10*10 PP

                    
                    ItemsTable.AddEntry(new Item(),31); //give nothing on this roll
                    ItemsTable.AddEntry(MinorMagicTable, 84);
                    ItemsTable.AddEntry(MediumMagicTable, 98);
                    ItemsTable.AddEntry(MajorMagicTable, 100);
                        MinorMagicTable.rdsCount = RollDice(1, 4, 1); //1d4 Minor Magic item
                        MediumMagicTable.rdsCount = 1;
                        MajorMagicTable.rdsCount = 1;

                    GoodsTable.AddEntry(new Item(),24);
                    GoodsTable.AddEntry(GemTable,74);
                    GoodsTable.AddEntry(ArtTable, 100);

                        GemTable.rdsCount = RollDice(1, 10, 1);
                        ArtTable.rdsCount = RollDice(1, 6, 1);
                    break;
                case 12:
                    Coins.AddEntry(new Item(),8);
                    Coins.AddEntry(new Item("Coin","Silver Piece",   RollDice(3, 12, 1000)),14); //3d12*1000 SP
                    Coins.AddEntry(new Item("Coin","Gold Piece",     RollDice(1,4, 1000)),75); //1d4*1000 GP
                    Coins.AddEntry(new Item("Coin","Platinum Piece", RollDice(1,4, 100)),100); //1d4*100 PP

                    ItemsTable.AddEntry(new Item(),27); //give nothing on this roll
                    ItemsTable.AddEntry(MinorMagicTable, 82);
                    ItemsTable.AddEntry(MediumMagicTable, 97);
                    ItemsTable.AddEntry(MajorMagicTable, 100);
                        MinorMagicTable.rdsCount = RollDice(1, 6, 1); //1d6 Minor Magic item
                        MediumMagicTable.rdsCount = 1;
                        MajorMagicTable.rdsCount = 1;

                    GoodsTable.AddEntry(new Item(),17);
                    GoodsTable.AddEntry(GemTable,70);
                    GoodsTable.AddEntry(ArtTable, 100);

                        GemTable.rdsCount = RollDice(1, 10, 1);
                        ArtTable.rdsCount = RollDice(1, 8, 1);
                    break;
                case 13:
                    Coins.AddEntry(new Item(), 8);
                    Coins.AddEntry(new Item("Coin","Gold Piece", RollDice(1, 4, 1000)), 75); //1d4*1000 GP
                    Coins.AddEntry(new Item("Coin","Platinum Piece", RollDice(1, 4, 100)), 100); //1d4*100 PP

                    ItemsTable.AddEntry(new Item(), 19); //give nothing on this roll
                    ItemsTable.AddEntry(MinorMagicTable,73);
                    ItemsTable.AddEntry(MediumMagicTable, 95);
                    ItemsTable.AddEntry(MajorMagicTable, 100);
                        MinorMagicTable.rdsCount = RollDice(1, 6, 1); //1d6 Minor Magic item
                        MediumMagicTable.rdsCount = 1;
                        MajorMagicTable.rdsCount = 1;

                    GoodsTable.AddEntry(new Item(),11);
                    GoodsTable.AddEntry(GemTable,66);
                    GoodsTable.AddEntry(ArtTable, 100);

                        GemTable.rdsCount = RollDice(1, 12, 1);
                        ArtTable.rdsCount = RollDice(1, 10, 1);
                    break;
                case 14:
                    Coins.AddEntry(new Item(), 8);
                    Coins.AddEntry(new Item("Coin","Gold Piece", RollDice(1, 6, 1000)), 75); //1d6*1000 GP
                    Coins.AddEntry(new Item("Coin","Platinum Piece", RollDice(1, 10, 100)), 100); //1d10*100 PP

                    ItemsTable.AddEntry(new Item(), 19); //give nothing on this roll
                    ItemsTable.AddEntry(MinorMagicTable,58);
                    ItemsTable.AddEntry(MediumMagicTable, 92);
                    ItemsTable.AddEntry(MajorMagicTable, 100);
                        MinorMagicTable.rdsCount = RollDice(1, 6, 1); //1d6 Minor Magic item
                        MediumMagicTable.rdsCount = 1;
                        MajorMagicTable.rdsCount = 1;

                    GoodsTable.AddEntry(new Item(),11);
                    GoodsTable.AddEntry(GemTable,66);
                    GoodsTable.AddEntry(ArtTable, 100);

                        GemTable.rdsCount = RollDice(2, 8, 1);
                        ArtTable.rdsCount = RollDice(2, 6, 1);
                    break;
                case 15:
                    Coins.AddEntry(new Item(), 3);
                    Coins.AddEntry(new Item("Coin","Gold Piece", RollDice(1, 8, 1000)), 74); //1d8*1000 GP
                    Coins.AddEntry(new Item("Coin","Platinum Piece", RollDice(3, 4, 100)), 100); //3d4*100 PP

                    ItemsTable.AddEntry(new Item(), 11); //give nothing on this roll
                    ItemsTable.AddEntry(MinorMagicTable, 46);
                    ItemsTable.AddEntry(MediumMagicTable, 90);
                    ItemsTable.AddEntry(MajorMagicTable, 100);
                        MinorMagicTable.rdsCount = RollDice(1, 10, 1); //1d10 Minor Magic item
                        MediumMagicTable.rdsCount = 1;
                        MajorMagicTable.rdsCount = 1;

                    GoodsTable.AddEntry(new Item(),9);
                    GoodsTable.AddEntry(GemTable,65);
                    GoodsTable.AddEntry(ArtTable, 100);

                        GemTable.rdsCount = RollDice(2, 10, 1);
                        ArtTable.rdsCount = RollDice(2, 8, 1);
                    break;
                case 16:
                    Coins.AddEntry(new Item(), 3);
                    Coins.AddEntry(new Item("Coin","Gold Piece", RollDice(1, 12, 1000)), 74); //1d12*1000 GP
                    Coins.AddEntry(new Item("Coin","Platinum Piece", RollDice(3, 4, 100)), 100); //3d4*100 PP

                    ItemsTable.AddEntry(new Item(), 40); //give nothing on this roll
                    ItemsTable.AddEntry(MinorMagicTable, 46);
                    ItemsTable.AddEntry(MediumMagicTable, 90);
                    ItemsTable.AddEntry(MajorMagicTable, 100);
                        MinorMagicTable.rdsCount = RollDice(1, 10, 1); //1d10 Minor Magic item
                        MediumMagicTable.rdsCount = RollDice(1, 3, 1);
                        MajorMagicTable.rdsCount = 1;

                    GoodsTable.AddEntry(new Item(),7);
                    GoodsTable.AddEntry(GemTable,64);
                    GoodsTable.AddEntry(ArtTable, 100);

                        GemTable.rdsCount = RollDice(4, 6, 1);
                        ArtTable.rdsCount = RollDice(2, 10, 1);
                    break;
                case 17:
                    Coins.AddEntry(new Item(), 3);
                    Coins.AddEntry(new Item("Coin","Gold Piece", RollDice(3, 4, 1000)), 68); //1d12*1000 GP
                    Coins.AddEntry(new Item("Coin","Platinum Piece", RollDice(2, 10, 100)), 100); //3d4*100 PP

                    ItemsTable.AddEntry(new Item(), 33); //give nothing on this roll
                    ItemsTable.AddEntry(MediumMagicTable, 83);
                    ItemsTable.AddEntry(MajorMagicTable, 100);
                        MediumMagicTable.rdsCount = RollDice(1, 3, 1);
                        MajorMagicTable.rdsCount = 1;

                    GoodsTable.AddEntry(new Item(),4);
                    GoodsTable.AddEntry(GemTable,63);
                    GoodsTable.AddEntry(ArtTable, 100);

                        GemTable.rdsCount = RollDice(4, 8, 1);
                        ArtTable.rdsCount = RollDice(3, 8, 1);

                    break;
                case 18:
                    Coins.AddEntry(new Item(), 2);
                    Coins.AddEntry(new Item("Coin","Gold Piece", RollDice(3, 6, 1000)), 65); //1d12*1000 GP
                    Coins.AddEntry(new Item("Coin","Platinum Piece", RollDice(5, 4, 100)), 100); //3d4*100 PP

                    ItemsTable.AddEntry(new Item(), 24); //give nothing on this roll
                    ItemsTable.AddEntry(MediumMagicTable, 80);
                    ItemsTable.AddEntry(MajorMagicTable, 100);
                        MediumMagicTable.rdsCount = RollDice(1, 4, 1);
                        MajorMagicTable.rdsCount = 1;

                    GoodsTable.AddEntry(new Item(),4);
                    GoodsTable.AddEntry(GemTable,54);
                    GoodsTable.AddEntry(ArtTable, 100);

                        GemTable.rdsCount = RollDice(3, 12, 1);
                        ArtTable.rdsCount = RollDice(3, 10, 1);
                    break;

                case 19:
                    Coins.AddEntry(new Item(), 2);
                    Coins.AddEntry(new Item("Coin", "Gold Piece", RollDice(3, 8, 1000)), 65); //1d12*1000 GP
                    Coins.AddEntry(new Item("Coin", "Platinum Piece", RollDice(3, 10, 100)), 100); //3d4*100 PP

                    ItemsTable.AddEntry(new Item(), 4); //give nothing on this roll
                    ItemsTable.AddEntry(MediumMagicTable, 70);
                    ItemsTable.AddEntry(MajorMagicTable, 100);
                        MediumMagicTable.rdsCount = RollDice(1, 4, 1);
                        MajorMagicTable.rdsCount = 1;

                    GoodsTable.AddEntry(new Item(), 3);
                    GoodsTable.AddEntry(GemTable, 50);
                    GoodsTable.AddEntry(ArtTable, 100);

                        GemTable.rdsCount = RollDice(6, 6, 1);
                        ArtTable.rdsCount = RollDice(6, 6, 1);
                    break;

                case 20:
                    Coins.AddEntry(new Item(), 2);
                    Coins.AddEntry(new Item("Coin", "Gold Piece", RollDice(4, 8, 1000)), 65);
                    Coins.AddEntry(new Item("Coin", "Platinum Piece", RollDice(4, 10, 100)), 100);

                    ItemsTable.AddEntry(new Item(), 25); //give nothing on this roll
                    ItemsTable.AddEntry(MediumMagicTable, 65);
                    ItemsTable.AddEntry(MajorMagicTable, 100);
                        MediumMagicTable.rdsCount = RollDice(1, 4, 1);
                        MajorMagicTable.rdsCount = RollDice(1, 3, 1);

                    GoodsTable.AddEntry(new Item(), 2);
                    GoodsTable.AddEntry(GemTable, 38);
                    GoodsTable.AddEntry(ArtTable, 100);

                        GemTable.rdsCount = RollDice(4, 10, 1);
                        ArtTable.rdsCount = RollDice(7, 6, 1);
                    break;
                default:
                    break;
            }
            #endregion
            #endregion

            TreasureTable.AddEntry(Coins);
            TreasureTable.AddEntry(ItemsTable);
            TreasureTable.AddEntry(GoodsTable);
            ItemsTable.rdsAlways = true;
            GoodsTable.rdsAlways = true;
            Coins.rdsAlways = true;
            
            #region MULTIPLIERS

            SetMulitipliers(GoodsTable, GoodsMultiplier);
            SetMulitipliers(ItemsTable, ItemMultiplier);

            if (CoinMultiplier < 1.0)
            {
                Coins.rdsCount = 1;
                //Coins.ProbabilityMult(CoinMultiplier);
            }
            else
            {
                //Coins.ProbabilityMult(1.0);
                Coins.rdsCount = (int)CoinMultiplier;
            }
            #endregion
        }


        
        private MagicItem GenerateItem(string rank)
        {
            string newName = "";
            string abilities = "";
            string itemType = "";
            int cost = 0; //the total cost (SHOULD take into account non-enhancement bonus abilities)
            int bonus = 0; //used to track bonuses for dynamic cost formulas
            MagicItem magicRolledItem = new MagicItem(""); //used to swap between minor/medium/major item tables
            Item rolledItem = new Item();
            
            int rollsLeft = 1;

            #region First Loop

            do
            {
                switch (rank)
                {
                    //first, roll what TYPE of item this is (ring, weapon, armor, staff, etc)
                    case "Minor":
                        switch (magicRolledItem.GetItemType())
                        {
                            case "Armor Ability":
                                magicRolledItem = (MagicItem)MinorArmorTable.rdsResult.Single();
                                break;
                            case "Weapon Ability":
                                magicRolledItem = (MagicItem)MinorWeaponsTable.rdsResult.Single(); ///NOOOOOOOOOO INSTEAD DO ITEMTYPE (STRING)?
                                break;
                            case "Shield Ability":
                                magicRolledItem = (MagicItem)MinorShieldsTable.rdsResult.Single(); ///NOOOOOOOOOO INSTEAD DO ITEMTYPE (STRING)?
                                break;
                            default:
                                magicRolledItem = (MagicItem)MinorMagicTable.rdsResult.Single();
                                textBox2.Text += "\r\nMINOR DEFAULT -> " + magicRolledItem.GetItemType();
                                break;
                        }
                        break;
                    case "Medium":
                        switch (magicRolledItem.GetItemType())
                        {
                            case "Armor Ability":
                                magicRolledItem = (MagicItem)MediumArmorTable.rdsResult.Single();
                                break;
                            case "Weapon Ability":
                                magicRolledItem = (MagicItem)MediumWeaponsTable.rdsResult.Single();
                                break;
                            default:
                                magicRolledItem = (MagicItem)MediumMagicTable.rdsResult.Single();
                                break;
                        }
                        break;
                    case "Major":
                        switch (magicRolledItem.GetItemType())
                        {
                            case "Armor Ability":
                                magicRolledItem = (MagicItem)MajorArmorTable.rdsResult.Single();
                                break;
                            case "Weapon Ability":
                                magicRolledItem = (MagicItem)MajorWeaponsTable.rdsResult.Single();
                                break;
                            default:
                                magicRolledItem = (MagicItem)MajorMagicTable.rdsResult.Single();
                                break;
                        }
                        break;
                    default:
                        break;
                }

                cost = magicRolledItem.GetCost(); //for mostly non-ability things (ability is currently zero cost)
                textBox2.Text += magicRolledItem.GetCost() + "    bitch titteh \r\n";

                //then, do stuff based on what this TYPE is
                switch (magicRolledItem.GetItemType())
                {
                    case "Magic Armor":
                        if (rolledItem.ToString() == "Nothing") //if this has not been rolled and it gets here, it is a simple magic armor with no abilities
                        {
                            rolledItem = (Item)ArmorTable.rdsResult.Single();
                            cost = rolledItem.GetCost();
                        }

                        /*            *        "+1"     +       " Armor Name"    = "+1 Chain Shirt (of shadow)"  */
                        newName = magicRolledItem.ToString() + " " + rolledItem.ToString() + abilities;

                        if (magicRolledItem.GetBonus() >= 1 && magicRolledItem.GetBonus() < 11)
                        {
                            bonus += magicRolledItem.GetBonus();
                        }
                        cost += magicRolledItem.GetCost();
                        break;
                    case "Magic Shield":
                        if (rolledItem.ToString() == "Nothing") //magic shield with no abilities
                        {
                            rolledItem = (Item)Shields.rdsResult.Single();
                            cost = rolledItem.GetCost();
                        }
                         newName = magicRolledItem.ToString() + " " + rolledItem.ToString() + abilities;
                        if (magicRolledItem.GetBonus() >= 1 && magicRolledItem.GetBonus() < 11) 
                        {  //TODO: If >COST< is between 1 and 11, this is a BONUS.
                            bonus += magicRolledItem.GetBonus();  
                        }
                        //else
                        //
                        cost += magicRolledItem.GetCost();

                        //textBox2.Text += magicRolledItem.GetCost() + "   \r\n";
                        //}
                        break;
                    case "Magic Weapon":
                        if (rolledItem.ToString() == "Nothing") //magic weapon with no abilities
                        {
                            rolledItem = (Item)WeaponsTable.rdsResult.Single();
                            cost = rolledItem.GetCost();
                        }
                        
                        newName = magicRolledItem.ToString() + " " + rolledItem.ToString() + abilities;
                        if (magicRolledItem.GetBonus() >= 1)
                        {
                            bonus += magicRolledItem.GetBonus();
                        }
                        else
                        {
                            cost += magicRolledItem.GetCost();
                        }
                        break;
                    case "Specific Armor":
                        newName = "Specificized! Name: " + magicRolledItem.ToString();
                        break;
                    case "Potion":
                    case "Scroll":
                    case "Rod":
                    case "Wand":
                    case "Wondrous Item":
                        newName = magicRolledItem.ToString(); //no abilities, just a name
                        break;
                    case "Armor Ability":
                        itemType = "Armor Ability";
                        abilities += AddAbilities(rank, itemType);
                        rollsLeft++;
                        break;
                    case "Weapon Ability":
                        if(itemType == "")
                        {
                            rolledItem = (Item)WeaponsTable.rdsResult.Single();
                            itemType = rolledItem.GetItemType();
                            cost = rolledItem.GetCost();
                            textBox2.Text += "blarg! " + cost;
                        }
                        abilities += AddAbilities(rank, itemType);
                        //rollsLeft++;
                        break;
                    default:
                        break;
                }

            rollsLeft--;

            } while (rollsLeft > 0);

            #endregion

            //return newName;

            if (magicRolledItem.GetItemType() == "Magic Weapon")
            {
                cost += (int)Math.Pow(bonus, 2) * 200000 + 30000; //bonus^2 * 2000 gold
            }
            if (magicRolledItem.GetItemType() == "Magic Armor" || magicRolledItem.GetItemType() == "Magic Shield")
            {
                cost += (int)Math.Pow(bonus, 2) * 100000 + 15000; //bonus^2 * 1000 gold
            }

            return new MagicItem(magicRolledItem.GetItemType(),newName,cost,bonus);
        }

        private string AddAbilities(string rank, string itemType)
        {
            string ability = "";
            RDSTable Abilities = new RDSTable(); //used to swap between minor/medium/major and armor/weapon ability tables
            string buffer = "";
            switch (rank)
            {
                case "Minor":
                    switch(itemType)
                    {
                        case "Armor Ability":
                            Abilities = MinorArmorAbilities;
                            break;
                        case "Melee Weapon":
                        case "Uncommon Melee Weapon":
                            Abilities = MinorMeleeWeaponsAbilities;
                            break;
                        case "Ranged Weapon":
                            Abilities = MinorRangedWeaponsAbilities;
                            break;
                        default:
                            return ""; //something went wrong if it gets here
                    }
                    break;
                case "Medium":
                    switch(itemType)
                    {
                        case "Armor Ability":
                            Abilities = MediumArmorAbilitiesTable;
                            break;
                        case "Shield Ability":
                            Abilities = MediumShieldAbilities;
                            break;
                        case "Melee Weapon":
                        case "Uncommon Melee Weapon":
                            Abilities = MediumMeleeWeaponsAbilitiesTable;
                            break;
                        case "Ranged Weapon":
                            Abilities = MediumRangedWeaponsAbilitiesTable;
                            break;
                        default:
                            return ""; //something went wrong if it gets here
                    }
                    break;
                case "Major":
                    switch(itemType)
                    {
                        case "Armor Ability":
                            Abilities = MajorArmorAbilitiesTable;
                            break;
                        case "Melee Weapon":
                        case "Uncommon Melee Weapon":
                            Abilities = MajorMeleeWeaponsAbilitiesTable;
                            break;
                        case "Ranged Weapon":
                            Abilities = MajorRangedWeaponsAbilitiesTable;
                            break;
                        default:
                            return ""; //something went wrong if it gets here
                    }
                    break;
                default:
                    break;
            }

            int rollsLeft = 1;
            ability = "\r\n+-->Abilities: \r\n";
            
            while (rollsLeft > 0) //EXIT IFF: totalBonus == 10; rollsleft < 1; 
            {

                if (Abilities.rdsContents.Count() < 1)
                {
                    textBox2.Text += "ERROR: no abilities to apply for" + itemType;
                    break;
                }
                buffer = Abilities.rdsResult.Single().ToString();            
                if (buffer == "ROLL AGAIN TWICE")
                {
                    //textBox2.Text += "ROLL AGAIN!";
                    rollsLeft += 2;
                }
                else
                {
                    //textBox2.Text += "ABILITY ADDED!" + " " + buffer + "\r\n";
                    ability += "    ->" + buffer + "\r\n";
                }
                rollsLeft--;
            }
            return ability;
        }

        private void SetMulitipliers(RDSTable table, double p)
        {
            double newMult = p;
            table.rdsEnabled = true;
            if (p == 0.5)
            {
                table.rdsCount = 1;
            }
            else
            {
                switch ((int)p)
                {
                    case 0:
                        table.rdsCount = 0;
                        table.rdsEnabled = false;
                        newMult = 0;
                        break;
                    case 1:
                        newMult = 1;
                        table.rdsCount = (int)p;
                        break;
                    case 2:
                        newMult = 1;
                        table.rdsCount = (int)p;
                        break;
                    case 3:
                        table.ProbabilityMult(1.0);
                        table.rdsCount = (int)p;
                        break;
                    default:
                        table.rdsCount = 1;
                        break;
                }
            }
            table.ProbabilityMult(newMult);
        }

        private int RollDice(int dicecount, int dicesides, int multiplier)
        {
            int TotalCount = 0;
            for (int i = 0; i < dicecount; i++) //roll (dicecount) times
            {
                TotalCount += rand.Next(1,dicesides + 1); //from 1 to (dicesides+1) excluding dicesides+1
            }
            return TotalCount * multiplier;
        }

        private void GroupAddRemove(int hoard, bool bAddRemove)
        {
            switch (hoard)
            {
                case 1:
                    pnlInput1.Visible = bAddRemove;
                    btnRemoveTreasure.Enabled = bAddRemove;
                    break;
                case 2:
                    pnlInput2.Visible = bAddRemove;
                    break;
                case 3:
                    pnlInput3.Visible = bAddRemove;
                    break;
                case 4:
                    pnlInput4.Visible = bAddRemove;
                    break;
                case 5:
                    pnlInput5.Visible = bAddRemove;
                    break;
                case 6:
                    pnlInput6.Visible = bAddRemove;
                    break;
                case 7:
                    pnlInput7.Visible = bAddRemove;
                    break;
                case 8:
                    pnlInput8.Visible = bAddRemove;
                    break;
                case 9:
                    pnlInput9.Visible = bAddRemove;
                    break;
                default:
                    if (bAddRemove == true)
                    {
                        textBox1.Text = "Can't add any more treasure hoards!";
                    }
                    break;
            }
        }

        private void lootTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                textBox1.Text = openFileDialog1.FileName;
            }
            //textBox1.Text = result.ToString(); // <-- For debugging use.
        }

    }
}