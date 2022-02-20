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
    public partial class UserDelete : UserControl
    {
        BANKEntities db = new BANKEntities();
        public UserDelete()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("Delete this customer ?", "Conformation", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    if (textBox1.Text != "" && textBox2.Text == "")
                    {
                        db.Database.ExecuteSqlCommand("delete from client_info where account_Num = {0}", textBox1.Text);
                        //db.client_info.Remove(db.client_info.Find(textBox1.Text));
                        MessageBox.Show("Client has been deleted");
                        textBox1.Text = ""; textBox2.Text = "";dataGridView1.DataSource = "";
                    }
                    if (textBox1.Text == "" && textBox2.Text != "")
                    {
                        db.Database.ExecuteSqlCommand("delete from client_info where fullName = {0}", textBox2.Text);
                        //db.client_info.Remove(db.client_info.Find(textBox2.Text));
                        MessageBox.Show("Client has been deleted");
                        textBox1.Text = ""; textBox2.Text = "";dataGridView1.DataSource = "";
                    }
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text == "")
                {
                    dataGridView1.DataSource = db.client_info.SqlQuery("select * from client_info where account_Num = {0}", textBox1.Text).ToList();
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    button1.Enabled = true;
                    this.dataGridView1.Columns["Transiction_history"].Visible = false;
                    this.dataGridView1.Columns["Transiction_history1"].Visible = false;
                }
                if (textBox1.Text == "" && textBox2.Text != "")
                {
                    dataGridView1.DataSource = db.client_info.SqlQuery("select * from client_info where fullName = {0}", textBox2.Text).ToList();
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    button1.Enabled = true;
                    this.dataGridView1.Columns["Transiction_history"].Visible = false;
                    this.dataGridView1.Columns["Transiction_history1"].Visible = false;
                }
            }
            catch
            {
                MessageBox.Show("Customer does not existe");
            }
        }

        private void UserDelete_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";textBox2.Text = "";
            textBox1.Enabled =true; textBox2.Enabled =true;
            button1.Enabled = false;
            dataGridView1.DataSource = null;
        }
    }
}
