using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//task 3
namespace Task2_Kevin_Kramer
{
    [Serializable]
    public class Map
    {
        List<Building> buildings = new List<Building>();//task 2
        List<Unit> units = new List<Unit>();
        int numUnits = 0;
        int numBuildings = 0;//task 2
        TextBox txtInfo;
        Random rd = new Random();

        public List<Building> Buildings
        {
            get { return buildings; }
            set { buildings = value; }
        }
       public List<Unit> Units
        {
            get { return units; }
            set { units = value; }
        }

        public Map(int nb,int n,TextBox txt)
        {
            numBuildings = nb;
            numUnits = n;
            txtInfo = txt;
        }
        public void Spawn()
        {

        }
        
       
        public void Generate()
        {
          
            for(int i=0; i< numUnits; i++)
            {
                if(rd.Next(0,4)==0)//Generate MeleeUnit
                {
                    MeleeUnit m = new MeleeUnit(rd.Next(0, 20),
                                               rd.Next(0, 20),
                                               120,
                                               1,
                                               20,
                                              (i % 2 == 0 ? 1 : 0),
                                              "M",
                                              "Ninja");//task 2 unit type 
                    units.Add(m);
                }
                else if(rd.Next(0, 4)==1)// Generate RangedUnit
                {
                    RangedUnit r = new RangedUnit(rd.Next(0, 20),
                                               rd.Next(0, 20),
                                               100,
                                               1,
                                               20,
                                               5,
                                              (i % 2 == 0 ? 1 : 0),
                                              "R",
                                              "Archer");//task 2 unit type
                    units.Add(r);
                }
                else if(rd.Next(0, 4) == 2) //task 3-Generate WizzardUnit
                {
                    WizzardUnit w = new WizzardUnit(rd.Next(0, 20),
                                               rd.Next(0, 20),
                                               100,
                                               1,
                                               20,
                                               (i % 2 == 0 ? 1 : 0),
                                               "W",
                                               "Mage");
                    units.Add(w);
                }
                else
                {
                    NeutralTeam n = new NeutralTeam(rd.Next(0, 20),
                                               rd.Next(0, 20),
                                               100,
                                               1,
                                               20,
                                               "NW",
                                               "Rouge");
                    units.Add(n);
                }
                
            }
            for (int i = 0; i < numBuildings; i++)
            {
                if (rd.Next(0, 2) == 0)
                {
                    ResourceBuilding rb = new ResourceBuilding(rd.Next(0, 20),
                                                              rd.Next(0, 20),
                                                              200,
                                                              (i % 2 == 0 ? 1 : 0),
                                                              "RB");
                    buildings.Add(rb);
                }
                else
                {
                    FactoryBuilding fb = new FactoryBuilding(rd.Next(0, 20),
                                                              rd.Next(0, 20),
                                                              200,
                                                              (i % 2 == 0 ? 1 : 0),
                                                              "FB");
                    buildings.Add(fb);
                }
            }
           
        }
        public void Display(GroupBox groupBox)
        {
            groupBox.Controls.Clear();

            foreach (Unit u in units)
            {
                if( u is MeleeUnit)
                {
                    MeleeUnit mu = (MeleeUnit)u;
                    Button b = new Button();
                    b.Size = new Size(20, 20);
                    b.Location = new Point(mu.XPos * 20, mu.YPos * 20);
                    b.Text = mu.Symbol;
                    if(mu.Faction==0)
                    {
                        b.ForeColor = Color.Red;
                    }
                    else
                    {
                        b.ForeColor = Color.Blue;
                    }
                    b.Click += Unit_Click;
                    groupBox.Controls.Add(b);
                }
                else if(u is RangedUnit)
                {
                    RangedUnit ru = (RangedUnit)u;
                    Button b = new Button();
                    b.Size = new Size(20, 20);
                    b.Location = new Point(ru.XPos * 20, ru.YPos * 20);
                    b.Text = ru.Symbol;
                    if (ru.Faction == 0)
                    {
                        b.ForeColor = Color.Red;
                    }
                    else
                    {
                        b.ForeColor = Color.Blue;
                    }
                    b.Click += Unit_Click;
                    groupBox.Controls.Add(b);
                }
                else 
                {
                    //Task 3 WizzardUnit
                    WizzardUnit wu = (WizzardUnit)u;
                    Button b = new Button();
                    b.Size = new Size(20, 20);
                    b.Location = new Point(wu.XPos * 20, wu.YPos * 20);
                    b.Text = wu.Symbol;
                    if (wu.Faction == 0)
                    {
                        b.ForeColor = Color.Red;
                    }
                    else
                    {
                        b.ForeColor = Color.Blue;
                    }
                    b.Click += Unit_Click;
                    groupBox.Controls.Add(b);
                }
                  
            }
            foreach(Building d in buildings)
            {
                if(d is ResourceBuilding)
                {
                    ResourceBuilding rb = (ResourceBuilding)d;
                    Button b = new Button();
                    b.Size = new Size(50, 50);
                    b.Location = new Point(rb.XPos * 20, rb.YPos * 20);
                    b.Text = rb.Symbol;
                    if (rb.Faction == 0)
                    {
                        b.ForeColor = Color.Red;
                    }
                    else
                    {
                        b.ForeColor = Color.Blue;
                    }
                    b.Click += Unit_Click;
                    groupBox.Controls.Add(b);
                }
                else
                {
                    FactoryBuilding fb = (FactoryBuilding)d;
                    Button b = new Button();
                    b.Size = new Size(50, 50);
                    b.Location = new Point(fb.XPos * 20, fb.YPos * 20);
                    b.Text = fb.Symbol;
                    if (fb.Faction == 0)
                    {
                        b.ForeColor = Color.Red;
                    }
                    else
                    {
                        b.ForeColor = Color.Blue;
                    }
                    b.Click += Unit_Click;
                    groupBox.Controls.Add(b);
                }
            }
        }
        public void Unit_Click(Object sender, EventArgs e)
        {
            int x, y;
            Button b = (Button)sender;
            x = b.Location.X / 20;
            y = b.Location.Y / 20;

            foreach(Unit u in units)
            {
                if(u is RangedUnit)
                {
                    RangedUnit ru = (RangedUnit)u;
                    if(ru.XPos==x && ru.YPos==y)
                    {
                        txtInfo.Text = " ";
                        txtInfo.Text = ru.ToString();
                    }
                }
                else if (u is MeleeUnit)
                {
                    MeleeUnit mu = (MeleeUnit)u;
                    if (mu.XPos == x && mu.YPos == y)
                    {
                        txtInfo.Text = " ";
                        txtInfo.Text = mu.ToString();
                    }
                }
                else
                {
                    //Task 3 Wizzard unit
                    WizzardUnit wu = (WizzardUnit)u;
                    if(wu.XPos==x && wu.YPos==y)
                    {
                        txtInfo.Text = "";
                        txtInfo.Text = wu.ToString();
                    }
                }
            }
            foreach(Building d in buildings)
            {
                if(d is ResourceBuilding)
                {
                    ResourceBuilding rb = (ResourceBuilding)d;
                    if(rb.XPos==x && rb.YPos==y)
                    {
                        txtInfo.Text = " ";
                        txtInfo.Text = rb.ToString();
                    }
                }else if (d is FactoryBuilding)
                {
                    FactoryBuilding fb = (FactoryBuilding)d;
                    if(fb.XPos==x && fb.YPos==y)
                    {
                        txtInfo.Text = " ";
                        txtInfo.Text = fb.ToString();
                    }
                }
            }
        }
    }
}
