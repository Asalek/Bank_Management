using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        BANKEntities db = new BANKEntities();
        int movx;
        int movy;
        int mov;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(string UN)
        {
            InitializeComponent();
            textBox1.Text = UN;
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            panel3.Visible = false;
            timer1.Start();
            hideUsers();          
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movx, MousePosition.Y - movy);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movx = e.X;
            movy = e.Y;
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Close", pictureBox1);
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {toolTip1.Show("Minimize", pictureBox1);}
  private void panel2_Paint_1(object sender, PaintEventArgs e)
        {
            //    this.BackColor = Color.Red;
            //    this.TransparencyKey = Color.Red;
            //    this.FormBorderStyle = FormBorderStyle.None;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("HH:mm");
            label3.Text = DateTime.Now.ToString("dddd dd MMMM yyyy");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe");
            //System.Diagnostics.Process.Start("notepad");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Fill the Boxes!");
                }
                else
                {
                    db.Database.ExecuteSqlCommand("update Login1 set password1 = {0} where UserName = {1} and password1 = {2}", textBox3.Text, textBox1.Text, textBox2.Text);
                    MessageBox.Show("password has been changed successfully");
                    textBox2.Text = "";
                    textBox3.Text = "";
                    panel3.Visible = false;
                }
            }
            catch { MessageBox.Show("Somthing Wrong"); }
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            panel3.Hide();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
         private void button6_Click(object sender, EventArgs e)
        {
            hideUsers();
            user11.Visible = true;
        }
        private void button7_Click_1(object sender, EventArgs e)
        {
            hideUsers();
            user221.Visible = true;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            hideUsers();
            userDelete1.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            hideUsers();
            userUpdate1.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            hideUsers();
            userClientInformation1.Visible = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            hideUsers();
            userDeposit1.Visible = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            hideUsers();
            withdraw1.Visible = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            hideUsers();
            userTransfer1.Visible = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            hideUsers();
            userhistory1.Visible = true;
        }
        public void hideUsers()
        {
            user11.Visible = false;
            user221.Visible = false;
            userDelete1.Visible = false;
            userUpdate1.Visible = false;
            userClientInformation1.Visible = false;
            userDeposit1.Visible = false;
            userTransfer1.Visible = false;
            withdraw1.Visible = false;
            userhistory1.Visible = false;
        }
    }
}
