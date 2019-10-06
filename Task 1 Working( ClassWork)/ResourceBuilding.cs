using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_Kevin_Kramer
{
    [Serializable]
    class ResourceBuilding:Building
    {
        GameEngine engine;
        public bool IsDestroyed { get; set; }

        public int XPos
        {
            get { return base.xPos; }
            set { base.xPos = value; }
        }
        public int YPos
        {
            get { return base.yPos; }
            set { base.yPos = value; }
        }
        public int Health
        {
            get { return base.health; }
            set { base.health = value; }
        }
        public int MaxHealth
        {
            get { return base.maxHealth; }
        }

        public int Faction
        {
            get { return base.faction; }
        }
        public string Symbol
        {
            get { return base.symbol; }
            set { base.symbol = value; }
        }

        public string resourceType = " Gold ";
        public int resourceGen= 0;
        public int resourcePR= 0;
        public int remaining= 500;
        

        public override void Destruction()
        {
           if (Health <= 0)
           {
                symbol = "XX";
                IsDestroyed = true;
           }
        }

        public void ResourceGenerator()
        {
            remaining -= 5;
            resourceGen += 5;
        }

        public override string ToString()
        {
            string temp = " ";
            temp += "Building :";
            temp += "(" + Symbol + ")";
            temp += "(" + XPos + "," + YPos + ")";
            temp += Health;
            temp += (IsDestroyed ? "Destroyed : " : "Standing");
            temp += "Resource Type :  " +  resourceType;
            temp += "Resources Per a round :  "  +  resourcePR;
            temp += "Resources Remaining : " +  remaining;
            return temp;
        }
        public ResourceBuilding(int x,int y,int h,int f,string sym)
        {
            XPos = x;
            YPos = y;
            Health = h;
            base.maxHealth = h;
            base.faction = f;
            Symbol = sym;
            IsDestroyed = false;
        }
    }
}
