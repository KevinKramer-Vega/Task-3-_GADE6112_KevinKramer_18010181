using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Task 3
namespace Task2_Kevin_Kramer
{
    [Serializable]
    class FactoryBuilding:Building
    {
       
        GameEngine engine;
        Map map;
        Random rd = new Random();
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
        private string unitProduce;

        public string UnitProduce
        {
            get { return unitProduce; }
            set { unitProduce = value; }
        }
        private int productionSpeed;

        public int ProductionSpeed
        {
            get { return productionSpeed; }
            set { productionSpeed = value; }
        }

        private int spawnPointX;

        public int SpawnPointX
        {
            get { return spawnPointX; }
            set { spawnPointX = value; }
        }
        private int spawnPointY;

        public int SpawnPointY
        {
            get { return spawnPointY; }
            set { spawnPointY = value; }
        }

        private int unitGenerate;

        public int UnitGenerate
        {
            get { return unitGenerate; }
            set { unitGenerate = value; }
        }

        //produces units on round 6 (help me .... please)
        public void Production()
        {
            if(engine.Round == 10)
            {
                map.Generate();
            }
            else
            {
                map.Generate();
            }
        }

        public override void Destruction()
        {
            if (Health <= 0)
            {
                symbol = "X";
                IsDestroyed = true;
            }
        }
        public Unit Spawn()
        {
            Unit unit;
            if(faction==0)
            {
                if(UnitGenerate ==0)
                {
                    MeleeUnit mu= new MeleeUnit(rd.Next(0,20),
                                                rd.Next(0,20),
                                                 120,
                                                  1,
                                                  20,
                                                   0,
                                                  "M",
                                                 "Ninja");
                    unit = mu;
                }
                else
                {
                    RangedUnit ru= new RangedUnit(rd.Next(0, 20),
                                                  rd.Next(0, 20),
                                                    100,
                                                    1,
                                                    20,
                                                    5,
                                                    0,
                                                    "R",
                                                   "Archer");
                    unit = ru;

                }
                return unit;
            }
            else
            {
                if (UnitGenerate == 0)
                {
                    MeleeUnit mu = new MeleeUnit(rd.Next(0, 20),
                                                rd.Next(0, 20),
                                                 120,
                                                  1,
                                                  20,
                                                   1,
                                                  "M",
                                                 "Ninja");
                    unit = mu;
                }
                else
                {
                    RangedUnit ru = new RangedUnit(rd.Next(0, 20),
                                                rd.Next(0, 20),
                                                    100,
                                                    1,
                                                    20,
                                                    5,
                                                    1,
                                                    "R",
                                                   "Archer");
                    unit = ru;

                }
                return unit;
            }
        }


        public override string ToString()
        {
            string temp = " ";
            temp += "Building :";
            temp += "(" + Symbol + ")";
            temp += "(" + XPos + "," + YPos + ")";
            temp += Health;
            temp += (IsDestroyed ? "Destroyed : " : "Standing");
            return temp;
        }
        public FactoryBuilding(int x, int y, int h, int f, string sym)
        {
            XPos = x;
            YPos = y;
            Health = h;
            base.maxHealth = h;
            base.faction = f;
            Symbol = sym;
        }
    }
}
