using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lewtz.Data
{
    class MagicItem : Item
    {
        private string ItemType = "Some Magic Type Done Broke!";
        private string ItemName = "Magic Name is Broken!";
        private int Cost = 0;
        private int totalBonus = 0;


        public MagicItem(string type, string name, int cost, int bonus)
        {
            totalBonus = bonus;
            ItemType = type;
            ItemName = name;
            Cost = cost;
        }
        public MagicItem(string type)
        {
            totalBonus = 0;
            ItemType = type;
            Cost = 0;
        }

        public override int GetCost()
        {
            return Cost;
        }

        public override string GetItemType()
        {
            return ItemType;
        }

        public override string ToString()
        {
            return ItemName;
        }

        public int GetBonus()
        {
            return totalBonus;
        }
        public void SetBonus(int bonus)
        {
            totalBonus = bonus;
        }

        public override Entity CreateInstance()
        {
            return new MagicItem(ItemType, ItemName, Cost, totalBonus);
        }

        public override void OnRDSHit(EventArgs e)
        {
            //DO SHIT
        }
    }
}