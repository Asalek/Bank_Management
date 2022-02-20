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
    public partial class Userhistory : UserControl
    {
        BANKEntities db = new BANKEntities();
        public Userhistory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = "";
            if(textBox1.Text != "")
            {
                try
                {
                    dataGridView1.DataSource = db.Transiction_history.SqlQuery("select * from Transiction_history where drawer = {0}", Int64.Parse(textBox1.Text)).ToList();
                    this.dataGridView1.Columns["id"].Visible = false;
                    this.dataGridView1.Columns["sender"].Visible = false;
                    this.dataGridView1.Columns["receiver"].Visible = false;
                    this.dataGridView1.Columns["transfer_Time"].Visible = false;
                    this.dataGridView1.Columns["client_info"].Visible = false;
                    this.dataGridView1.Columns["client_info1"].Visible = false;
                    this.dataGridView1.Columns["client_info2"].Visible = false;
                }
                catch { MessageBox.Show("No Transiction"); }
        }
            else { MessageBox.Show("Write the Account Number Please"); }
        }

        private void Userhistory_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = "";
            if (textBox1.Text != "")
            {
                try
                {
                    dataGridView1.DataSource = db.Transiction_history.SqlQuery("select * from Transiction_history where receiver = {0} ana receiver !={0}", Int64.Parse(textBox1.Text)).ToList();
                    this.dataGridView1.Columns["id"].Visible = false;
                    this.dataGridView1.Columns["drawer"].Visible = false;
                    this.dataGridView1.Columns["withdraw_Time"].Visible = false;
                    this.dataGridView1.Columns["client_info"].Visible = false;
                    this.dataGridView1.Columns["client_info1"].Visible = false;
                    this.dataGridView1.Columns["client_info2"].Visible = false;
                }
                catch { MessageBox.Show("No Transiction"); }
            }
            else { MessageBox.Show("Write the Account Number Please"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = "";
            if (textBox1.Text != "")
            {
                try
                {
                    dataGridView1.DataSource = db.Transiction_history.SqlQuery("select * from Transiction_history where sender = {0} and receiver !={0}", Int64.Parse(textBox1.Text)).ToList();
                    this.dataGridView1.Columns["id"].Visible = false;
                    this.dataGridView1.Columns["drawer"].Visible = false;
                    this.dataGridView1.Columns["withdraw_Time"].Visible = false;
                    this.dataGridView1.Columns["client_info"].Visible = false;
                    this.dataGridView1.Columns["client_info1"].Visible = false;
                    this.dataGridView1.Columns["client_info2"].Visible = false;
                }
                catch { MessageBox.Show("No Transiction"); }
            }
            else { MessageBox.Show("Write the Account Number Please"); }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = "";
            if (textBox1.Text != "")
            {
                try
                {
                    dataGridView1.DataSource = db.Transiction_history.SqlQuery("select * from Transiction_history where sender = {0} or drawer = {0} or receiver = {0}", Int64.Parse(textBox1.Text)).ToList();
                    this.dataGridView1.Columns["id"].Visible = false;
                    this.dataGridView1.Columns["client_info"].Visible = false;
                    this.dataGridView1.Columns["client_info1"].Visible = false;
                    this.dataGridView1.Columns["client_info2"].Visible = false;
                }
                catch { MessageBox.Show("No Transiction"); }
            }
            else { MessageBox.Show("Write the Account Number Please"); }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = "";
            if (textBox1.Text != "")
            {
                try
                {
                    dataGridView1.DataSource = db.Transiction_history.SqlQuery("select * from Transiction_history where sender = {0} and receiver = {0}", Int64.Parse(textBox1.Text)).ToList();
                    this.dataGridView1.Columns["id"].Visible = false;
                    this.dataGridView1.Columns["client_info"].Visible = false;
                    this.dataGridView1.Columns["client_info1"].Visible = false;
                    this.dataGridView1.Columns["client_info2"].Visible = false;

                    this.dataGridView1.Columns["drawer"].Visible = false;
                    this.dataGridView1.Columns["withdraw_Time"].Visible = false;
                }
                catch { MessageBox.Show("No Transiction"); }
            }
            else { MessageBox.Show("Write the Account Number Please"); }

        }
    }
}
