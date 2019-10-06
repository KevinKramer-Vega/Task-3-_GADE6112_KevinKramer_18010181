using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Task 3
namespace Task2_Kevin_Kramer
{
    [Serializable]
    public abstract class Unit
    {
        protected int xPos;
        protected int yPos;
        protected int health;
        protected int maxHealth;
        protected int speed;
        protected int attack;
        protected int attackRange;
        protected int faction;
        protected string symbol;
        protected bool isAttacking;
        protected string unitType;

        public abstract void Move(int direction);
        public abstract void Combat(Unit attacker);
        public abstract bool InRange(Unit other);
       // public abstract (Unit, int) Closest(List<Unit> units);
        public abstract void Death();
        public abstract override string ToString();


    }
}
