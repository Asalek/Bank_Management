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
    public partial class Login : Form
    {
        BANKEntities db = new BANKEntities();
        int movx;
        int movy;
        int mov;
        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            textBox2.Text = "UserName";
            textBox1.Text = "Password";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "Password" && textBox2.Text != "UserName" && textBox1.Text != "" && textBox2.Text != "")
            {
                try
                {
                    var a = db.Login1.Find(textBox2.Text).UserName;
                    var b = db.Login1.Find(textBox2.Text).Password1;
                    if (textBox2.Text == a && textBox1.Text == b)
                    {
                        Form2 f = new Form2(textBox2.Text); this.Hide(); f.Show();
                    }
                    else { MessageBox.Show("Wrong Password"); }
                }
                catch (Exception) { MessageBox.Show("Nick name deosn't existe!"); }
            }
            else
            {
                MessageBox.Show("Fill in the blank with You're USERNAME and PASSWORD");
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            textBox1.PasswordChar = '*';
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.PasswordChar = '\0';
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == "UserName")
                textBox2.Text = "";
        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
                textBox2.Text = "UserName";
        }

        private void textBox2_MouseHover(object sender, EventArgs e)
        {
            if (textBox2.Text == "UserName")
                textBox2.Text = "";
        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            if (textBox1.Text == "Password")
                textBox1.Text = "";
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            textBox1.TabStop = false;
            if (textBox1.Text == "")
                textBox1.Text = "Password";
            if(textBox1.Text == "Password")
            { textBox1.PasswordChar = '\0'; }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "Password")
                textBox1.PasswordChar = '*';
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Password")
                textBox1.Text = "";
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(mov == 1)
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
