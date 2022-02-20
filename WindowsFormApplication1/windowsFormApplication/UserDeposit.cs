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
    public partial class UserDeposit : UserControl
    {
        BANKEntities db = new BANKEntities();
        public UserDeposit()
        {
            InitializeComponent();
        }

        private void UserDeposit_Load(object sender, EventArgs e)
        {
            textBox3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "" )
            {
                try
                {
                    string a = db.client_info.Find(Int64.Parse(textBox1.Text)).fullName;
                    if (a == textBox2.Text)
                    {
                        textBox3.Enabled = true;
                        textBox1.Enabled = false;
                        textBox2.Enabled = false;
                        label7.Text = "Succeed";
                        label7.ForeColor = Color.Green;
                        label6.Visible = false;
                    }
                    else
                    {
                        label7.Text = "Client FullName wrong try Fisrt Alphabet in First and last name in Capital letter";
                        label7.ForeColor = Color.Red;
                    }
                }catch { MessageBox.Show("Client doesn't exist"); }
            }
            else { MessageBox.Show("Fill the in the blank with Account number and FullName"); }
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Fisrt Alphabet in First and last name must be Capital letter", label6);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Enabled = false;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            label7.Text = "";
            label6.Visible = true;
            //textBox1.Text = "";
            //textBox2.Text = "";
            //textBox3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Deposit to this Account", "Confermation", MessageBoxButtons.YesNo);
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
                        var a = t.Balance;
                        if (a == null)
                            t.Balance = 0;
                        t.Balance = t.Balance + Math.Round(float.Parse(textBox3.Text), 2);
                        db.SaveChanges();
                        //db.Database.ExecuteSqlCommand("update client_info set sold +={0} where account_Num = {1}", Int64.Parse(textBox3.Text),Int64.Parse(textBox1.Text));
                        db.Database.ExecuteSqlCommand("insert into Transiction_history(amount,sender,receiver,transfer_Time) values ({0},{1},{2},{3})", Math.Round(float.Parse(textBox3.Text), 2), Int64.Parse(textBox1.Text), Int64.Parse(textBox1.Text), DateTime.Now);

                        MessageBox.Show("Amount Added");
                        textBox3.Enabled = false;
                        textBox1.Enabled = true;
                        textBox2.Enabled = true;
                        label7.Text = "";
                        label6.Visible = true;
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                    }
                }
                catch { }
            }
        }
    }
}
