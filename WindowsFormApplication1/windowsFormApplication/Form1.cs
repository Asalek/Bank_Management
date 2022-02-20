using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int ticks = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label2.Text = "Starting App ...";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ticks +=1;
            label1.Text = ticks + " %";
            if (ticks == 10) { label2.Text = "Getting start with SQL..."; }
            if (ticks == 30) { label2.Text = "Getting info from dataBase..."; }
            if (ticks == 50) { label2.Text = "Getting App ready..."; }
            if (ticks == 70) { label2.Text = "Starting The Bank APP..."; }
            if (ticks == 100) {
                timer1.Stop();
                Login f = new Login();
                this.Hide();
                f.Show();
            }

        }
    }
}
