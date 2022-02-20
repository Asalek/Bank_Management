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
    public partial class UserTransfer : UserControl
    {
        BANKEntities db = new BANKEntities();
        public UserTransfer()
        {
            InitializeComponent();
        }

        private void UserTransfer_Load(object sender, EventArgs e)
        {
            textBox3.Enabled = false;
            label10.Visible = false;
            label9.Visible = false;
            label2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool ssender = false;
            bool reciever = false;
            if (textBox1.Text != "" && textBox2.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                try
                {
                    string a = db.client_info.Find(Int64.Parse(textBox1.Text)).fullName;
                    string b = db.client_info.Find(Int64.Parse(textBox4.Text)).fullName;
                    if (a == textBox2.Text)
                    {
                        label2.Text = "Exist";
                        label2.ForeColor = Color.Green;
                        ssender = true;
                    }
                    else
                    {
                        label2.Visible = true;
                        label2.Text = "Sender FullName wrong";
                        label2.ForeColor = Color.Red;
                    }
                    if (b == textBox5.Text)
                    {
                        label9.Text = "Exist";
                        label9.ForeColor = Color.Green;
                        reciever = true;
                    }
                    else
                    {
                        label9.Visible = true;
                        label9.Text = "Reciever FullName wrong";
                        label9.ForeColor = Color.Red;
                    }
                    if (ssender == true && reciever == true)
                    {
                        label10.Visible = true;
                        label10.Text = "Succeed";
                        label10.ForeColor = Color.Green;
                        label9.Visible = false;
                        label2.Visible = false;
                        textBox3.Enabled = true;
                        textBox1.Enabled = false;
                        textBox2.Enabled = false;
                        textBox4.Enabled = false;
                        textBox5.Enabled = false;
                    }
                }
                catch { MessageBox.Show("Sender or Reciever doesn't exist"); }
            }
            else { MessageBox.Show("Fill the in the blank with Account number and FullName"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label10.Visible = false;
            label9.Visible = false;
            label2.Visible = false;
            textBox3.Enabled = false;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Transfer to this Account", "Confermation", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
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
                        client_info t2 = db.client_info.Find(Int64.Parse(textBox4.Text));

                        var a = t2.Balance;
                        if (a == null)
                            t2.Balance = 0;
                        if (t.Balance >= float.Parse(textBox3.Text))
                        {
                            t.Balance = t.Balance - Math.Round(float.Parse(textBox3.Text), 2);
                            t2.Balance = t2.Balance + Math.Round(float.Parse(textBox3.Text), 2);
                            db.Database.ExecuteSqlCommand("insert into Transiction_history(amount,sender,receiver,transfer_Time) values ({0},{1},{2},{3})", Math.Round(float.Parse(textBox3.Text), 2), Int64.Parse(textBox1.Text), Int64.Parse(textBox4.Text), DateTime.Now);
                            db.SaveChanges();
                            MessageBox.Show("Transfer Successed");
                            textBox3.Enabled = false;
                            textBox1.Enabled = true;
                            textBox2.Enabled = true;
                            textBox4.Enabled = true;
                            textBox5.Enabled = true;
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            textBox5.Text = "";
                            label10.Text = "";
                        }
                        else { MessageBox.Show("Not enough money"); }
                    }
                }
                catch { }
            }
        }
    }
}
