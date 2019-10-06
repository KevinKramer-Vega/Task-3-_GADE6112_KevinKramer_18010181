using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Task 3
namespace Task2_Kevin_Kramer
{
    [Serializable]
    public abstract class Building
    {
        protected int xPos;
        protected int yPos;
        protected int health;
        protected int maxHealth;
        protected int faction;
        protected string symbol;

        public abstract void Destruction();
        public abstract override string ToString();
    }
}
