using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Task 3
namespace Task_1_Working__ClassWork_
{
    public partial class Form1 : Form
    {
        GameEngine engine;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            engine = new GameEngine(20, txtInfo, gBoxMap);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblRound.Text ="Round : " + engine.Round.ToString();
            engine.Update();
        }
    }
}
