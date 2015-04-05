using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO; //streamreader
using rds;

namespace Lewtz
{
    class Item : RDSCreatableObject
    {
        private string ItemType = ""; //weapon, etc
        private string ItemName; //name of the weapon; ie Dagger, etc
        private double Cost = 0;

        public Item() 
        {
            ItemType = "";
            Cost = 0;
            ItemName = "Nothing";
        }
        public Item(string type)
        {
            ItemType = type;
            Cost = 0;
        }
        public Item(string type, string name)
        {
            ItemType = type;
            ItemName = name;
            Cost = 0;
        }


        public Item(string type, string name, double cost)
        {
            ItemType = type;
            ItemName = name;
            Cost = cost;
        }
        //usually called in LoadFromFile in RDSTable interface
        public Item(string type, string name, int cost, int probability)
        {
            ItemType = type;
            ItemName = name;
            Cost = cost;
            rdsProbability = probability;
        }


        public virtual double GetCost()
        {
            return Cost;
        }
        public virtual void SetCost(double cost)
        {
            Cost = cost;
        }
        public virtual string GetItemType()
        {
            return ItemType;
        }

        public override string ToString()
        {
            return ItemName;
        }

        public override IRDSObject rdsCreateInstance()
        {
            return new Item(ItemType,ItemName,Cost);
        }
    }
}
