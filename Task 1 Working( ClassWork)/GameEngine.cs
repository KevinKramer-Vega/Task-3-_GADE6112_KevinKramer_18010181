using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

//Task 3
namespace Task2_Kevin_Kramer
{
    [Serializable]
    public class GameEngine
    {
        Map map;
        Random r = new Random();
        GroupBox gBoxMap;

        private int round;

        public int Round
        {
            get { return round; }
        }


        public GameEngine(int numBuildings,int numUnits, TextBox txtInfo, GroupBox gMap)
        {
            gBoxMap = gMap;
            map = new Map(numBuildings,numUnits, txtInfo);
            map.Generate();
            map.Display(gBoxMap);

            round = 1;
        }
        public void Update()
        {
            foreach(Building d in map.Buildings)
            {
                if(d is FactoryBuilding)
                {
                    FactoryBuilding fb = (FactoryBuilding)d;
                    if(fb.ProductionSpeed % Round ==0)
                    {
                        map.Units.Add(fb.Spawn());
                    }
                }
            }
            for (int i = 0; i < map.Units.Count; i++)
            {
                if (map.Units[i] is MeleeUnit)
                {
                    MeleeUnit mu = (MeleeUnit)map.Units[i];
                    mu.Health = 10;// tests code
                    if (mu.Health <= mu.MaxHealth * 0.25)// Escape!!!( Running away)
                    {
                        mu.Move(r.Next(0, 4));
                    }
                    else
                    {
                        int shortest = 100;
                        Unit closest = mu;
                        foreach (Unit u in map.Units)
                        {
                            if (u is MeleeUnit)
                            {
                                MeleeUnit otherMu = (MeleeUnit)u;
                                int distance = Math.Abs(mu.XPos - otherMu.XPos)
                                         + Math.Abs(mu.YPos - otherMu.YPos);
                                if (distance < shortest)
                                {
                                    shortest = distance;
                                    closest = otherMu;
                                }
                            }
                        }
                        //Check In Range
                        if (shortest <= mu.AttackRange)
                        {
                            mu.IsAttacking = true;
                            mu.Combat(closest);
                        }
                        else // Move towards
                        {
                            if (closest is MeleeUnit)
                            {
                                MeleeUnit closestMu = (MeleeUnit)closest;
                                if (mu.XPos > closestMu.XPos)//North
                                {
                                    mu.Move(0);
                                }
                                else if (mu.XPos < closestMu.XPos)//South
                                {
                                    mu.Move(2);
                                }
                                else if (mu.XPos > closestMu.YPos)//West
                                {
                                    mu.Move(3);
                                }
                                else if (mu.XPos < closestMu.YPos)//East
                                {
                                    mu.Move(1);
                                }
                            }
                        }
                    }
                }
                if (map.Units[i] is RangedUnit)
                {
                    RangedUnit ru = (RangedUnit)map.Units[i];
                   // ru.Health = 10;// tests code
                    if (ru.Health <= ru.MaxHealth * 0.25)// Escape!!!( Running away)
                    {
                        ru.Move(r.Next(0, 4));
                    }
                    else
                    {
                        int shortest = 100;
                        Unit closest = ru;
                        foreach (Unit u in map.Units)
                        {
                            if (u is RangedUnit)
                            {
                                RangedUnit otherRu = (RangedUnit)u;
                                int distance = Math.Abs(ru.XPos - otherRu.XPos)
                                         + Math.Abs(ru.YPos - otherRu.YPos);
                                if (distance < shortest)
                                {
                                    shortest = distance;
                                    closest = otherRu;
                                }
                            }
                        }
                        //Check In Range
                        if (shortest <= ru.AttackRange)
                        {
                            ru.IsAttacking = true;
                            ru.Combat(closest);
                        }
                        else // Move towards
                        {
                            if (closest is RangedUnit)
                            {
                                RangedUnit closestRu = (RangedUnit)closest;
                                if (ru.XPos > closestRu.XPos)//North
                                {
                                    ru.Move(0);
                                }
                                else if (ru.XPos < closestRu.XPos)//South
                                {
                                    ru.Move(2);
                                }
                                else if (ru.XPos > closestRu.YPos)//West
                                {
                                    ru.Move(3);
                                }
                                else if (ru.XPos < closestRu.YPos)//East
                                {
                                    ru.Move(1);
                                }
                            }
                        }
                    }
                }
               
            }
            map.Display(gBoxMap);
            round++;
        }

        public int DistanceTo(Unit a, Unit b)
        {
            int distance = 0;

            if (a is MeleeUnit && b is MeleeUnit)
            {
                MeleeUnit start = (MeleeUnit)a;
                MeleeUnit end = (MeleeUnit)b;
                distance = Math.Abs(start.XPos - end.XPos) + Math.Abs(start.YPos - end.YPos);
            }
            else if (a is RangedUnit && b is MeleeUnit)
            {
                RangedUnit start = (RangedUnit)a;
                MeleeUnit end = (MeleeUnit)b;
                distance = Math.Abs(start.XPos - end.XPos) + Math.Abs(start.YPos - end.YPos);
            }
            else if (a is RangedUnit && b is RangedUnit)
            {
                RangedUnit start = (RangedUnit)a;
                RangedUnit end = (RangedUnit)b;
                distance = Math.Abs(start.XPos - end.XPos) + Math.Abs(start.YPos - end.YPos);
            }
            else if (a is MeleeUnit && b is RangedUnit)
            {
                MeleeUnit start = (MeleeUnit)a;
                RangedUnit end = (RangedUnit)b;
                distance = Math.Abs(start.XPos - end.XPos) + Math.Abs(start.YPos - end.YPos);
            }
            return distance;
        }

    }

}







