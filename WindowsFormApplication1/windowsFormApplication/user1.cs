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
    public partial class user1 : UserControl
    {
        BANKEntities db = new BANKEntities();
        public user1()
        {
            InitializeComponent();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.client_info.ToArray();
            this.dataGridView1.Columns["Transiction_history"].Visible = false;
            this.dataGridView1.Columns["Transiction_history1"].Visible = false;
            this.dataGridView1.Columns["Transiction_history2"].Visible = false;

        }
        private void button16_Click_1(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                try
                {
                    var a = db.client_info.Find(Convert.ToInt64(textBox4.Text)).account_Num;
                    if (a != null)
                    {
                        dataGridView1.DataSource = db.client_info.SqlQuery("select * from client_info where account_Num = {0}", Convert.ToInt64(textBox4.Text)).ToList();
                        this.dataGridView1.Columns["Transiction_history"].Visible = false;
                        this.dataGridView1.Columns["Transiction_history1"].Visible = false;
                        this.dataGridView1.Columns["Transiction_history2"].Visible = false;
                    }
                    else { MessageBox.Show("Client Does not Exist"); }
                }
                catch { }
            }
            else { MessageBox.Show("Insert the Account Number Please"); }
        }

        private void user1_Load(object sender, EventArgs e)
        {

        }
    }
}
