using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//task 3

namespace Task2_Kevin_Kramer
{
    [Serializable]
    public class MeleeUnit : Unit
    {
        //IsDead field used for Dead method
        public bool IsDead { get; set; }
        //Properties
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
        public int Attack
        {
            get { return base.attack; }
            set { base.attack = value; }
        }
        public int AttackRange
        {
            get { return base.attackRange; }
            set { base.attackRange = value; }
        }
        public int Speed
        {
            get { return base.speed; }
            set { base.speed = value; }
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
        public bool IsAttacking
        {
            get { return base.isAttacking; }
            set { base.isAttacking = value; }
        }

        //task 2 unit type
        private string unitType;

        public string UnitType
        {
            get { return unitType; }
            set { unitType = value; }
        }



        //Methods
        public override void Combat(Unit attacker)
        {
            if (attacker is MeleeUnit)
            {
                Health = health - ((MeleeUnit)attacker).Attack;
            }
            else if (attacker is RangedUnit)
            {
                RangedUnit ru = (RangedUnit)attacker;
                Health = Health - (ru.Attack - ru.AttackRange);
            }
            else if (attacker is WizzardUnit)//updated to include wizzard unit
            {
                WizzardUnit wu = (WizzardUnit)attacker;
                Health = Health - (wu.Attack - wu.AttackRange);
            }
            else if (attacker is NeutralTeam)//includes neutral team unit
            {
                NeutralTeam nt = (NeutralTeam)attacker;
                Health = Health - (nt.Attack - nt.AttackRange);
            }

            if (Health <= 0)
            {
                Death(); //Mistakes were made!!!!
            }
        }

        public override void Death()
        {
            symbol = "X";
            IsDead = true;
        }

        public override bool InRange(Unit other)
        {
            int distance = 0;
            int otherX = 0;
            int otherY = 0;

            if (other is MeleeUnit)
            {
                otherX = ((MeleeUnit)other).XPos;
                otherY = ((MeleeUnit)other).YPos;

            }
            else if (other is RangedUnit)
            {
                otherX = ((RangedUnit)other).XPos;
                otherY = ((RangedUnit)other).YPos;
            }
            else if (other is WizzardUnit)// includes new wizzard unit
            {
                otherX = ((WizzardUnit)other).XPos;
                otherY = ((WizzardUnit)other).YPos;
            }
            else if (other is NeutralTeam)// includes neutral team wizzard
            {
                otherX = ((NeutralTeam)other).XPos;
                otherY = ((NeutralTeam)other).YPos;
            }
            distance = Math.Abs(XPos - otherX) + Math.Abs(YPos - otherY);
            if (distance <= AttackRange)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Move(int direction)
        {
            switch (direction)
            {
                case 0: YPos--; break; //North         
                case 1: XPos++; break; //East        
                case 2: YPos++; break; //South       
                case 3: XPos--; break; //West       
                default: break;
            }
        }
        //public override (Unit, int) Closest(List<Unit> units)
        //{
        //    int shortest = 100;
        //    Unit closest = this;
        //    //Closest Unit and Distance                    
        //    foreach (Unit u in units)
        //    {
        //        if (u is MeleeUnit && u != this)
        //        {
        //            MeleeUnit otherMu = (MeleeUnit)u;
        //            int distance = Math.Abs(this.XPos - otherMu.XPos)
        //                       + Math.Abs(this.YPos - otherMu.YPos);
        //            if (distance < shortest)
        //            {
        //                shortest = distance;
        //                closest = otherMu;
        //            }
        //        }
        //        else if (u is RangedUnit && u != this)
        //        {
        //            RangedUnit otherRu = (RangedUnit)u;
        //            int distance = Math.Abs(this.XPos - otherRu.XPos)
        //                       + Math.Abs(this.YPos - otherRu.YPos);
        //            if (distance < shortest)
        //            {
        //                shortest = distance;
        //                closest = otherRu;
        //            }
        //        }

        //    }
        //    return (closest, shortest);
        //}

        public override string ToString()
        {
            string temp = " ";
            temp += "Melee : ";
            temp += "(" + Symbol + ")";
            temp += "(" + XPos + "," + YPos + ")";
            temp +="Health: " + Health + "," + Attack + "," + AttackRange + "," + Speed;
            temp += (IsDead ? "Dead : " : "Alive!");
            temp += "Unit Type : " + UnitType;//task 2 unit type
            return temp;
        }

        //constructor
        public MeleeUnit(int x, int y, int h, int s, int a, int f, string sy,string ut)
        {
            XPos = x;
            YPos = y;
            Health = h;
            base.maxHealth = h;
            Speed = s;
            Attack = a;
            AttackRange = 1;
            base.faction = f;
            Symbol = sy;
            isAttacking = false;
            IsDead = false;
            UnitType = ut;//task 2 unit type
        }
    }
}
