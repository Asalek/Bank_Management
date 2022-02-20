using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class withdraw : UserControl
    {
        int i = 0;
        BANKEntities db = new BANKEntities();
        public withdraw()
        {
            InitializeComponent();
            axWindowsMediaPlayer1.uiMode = "none";

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "")
            {
                try
                {
                    string a = db.client_info.Find(Int64.Parse(textBox1.Text)).fullName;
                    if (a == textBox2.Text)
                    {
                        textBox3.Enabled = true;
                        textBox1.Enabled = false;
                        textBox2.Enabled = false;
                        label4.Text = "Succeed";
                        label4.ForeColor = Color.Green;
                    }
                    else
                    {
                        label4.Text = "Client FullName wrong";
                        label4.ForeColor = Color.Red;
                    }
                }
                catch { MessageBox.Show("Client doesn't exist"); }
            }
            else { MessageBox.Show("Fill the in the blank with Account number and FullName"); }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                DialogResult res = MessageBox.Show("Withdraw From This Account?", "Confermation", MessageBoxButtons.YesNo);
                {
                    try
                    {
                        if (float.Parse(textBox3.Text) < 0)
                        {
                            MessageBox.Show("Only Positive Number Can Type");
                        }
                        else
                        {
                            client_info t = db.client_info.Find(Int64.Parse(textBox1.Text));
                            var a = t.Balance;
                            if (a == null)
                                t.Balance = 0;
                            if (t.Balance >= float.Parse(textBox3.Text))
                            {
                                t.Balance = t.Balance - Math.Round(float.Parse(textBox3.Text), 2);
                                db.Database.ExecuteSqlCommand("insert into Transiction_history(drawer,withdraw_Time,amount) values({2},{1},{0})", Math.Round(float.Parse(textBox3.Text), 2),DateTime.Now,Int64.Parse(textBox1.Text));
                                MessageBox.Show("Withdraw Done");
                                axWindowsMediaPlayer1.Visible = true;
                                axWindowsMediaPlayer1.URL = @"C:\Users\ayoub\Desktop\Projects\Bank.1\money.mp4";
                                axWindowsMediaPlayer1.Ctlcontrols.play();
                                timer1.Start();
                                db.SaveChanges();
                                textBox3.Enabled = false;
                                textBox1.Enabled = true;
                                textBox2.Enabled = true;
                                label4.Text = "";
                                textBox1.Text = "";
                                textBox2.Text = "";
                                textBox3.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("Not enough money");
                            }
                        }
                    }
                    catch { }
                }
            }
            else { MessageBox.Show("Fill in the blank with Account Number and FullName"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Enabled = false;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            label4.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            if(i == 6)
            {
                axWindowsMediaPlayer1.Visible = false;
            }
        }

        private void withdraw_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Visible = false;
            textBox3.Enabled = false;
        }
    }
}
