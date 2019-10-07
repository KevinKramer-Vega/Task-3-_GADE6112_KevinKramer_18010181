using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//Task 3
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

        public void ResourceGenerator(int rounds, Label lblResources,Label lblRes)
        {
            do
            {
                for (int i = 0; i < remaining; i++)
                {
                    resourceType.Remove(i);
                    if (i > remaining)
                    {
                        IsDestroyed = true;
                        symbol = "XX";
                    }
                    //lblResources.Text = "Resource Amount : " + resourceType.Count.Tostring();
                    lblRes.Text = " Resources Generated : " + i.ToString();

                }
            }
            while (rounds < remaining);
            
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
