using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class UserClientInformation : UserControl
    {
        BANKEntities db = new BANKEntities();
        public UserClientInformation()
        {
            InitializeComponent();
        }
        private void UserClientInformation_Load_1(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox1.Width - 3, pictureBox1.Height - 3);
            Region rg = new Region(gp);
            pictureBox1.Region = rg;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    label2.Text = db.client_info.Find(Int64.Parse(textBox1.Text)).fullName;
                    label3.Text = db.client_info.Find(Int64.Parse(textBox1.Text)).gender;
                    textBox2.Text = db.client_info.Find(Int64.Parse(textBox1.Text)).card_type;
                    textBox4.Text = db.client_info.Find(Int64.Parse(textBox1.Text)).Nationality;
                    dateTimePicker1.Value = db.client_info.Find(Int64.Parse(textBox1.Text)).dateOfBirth.Value;
                    textBox7.Text = db.client_info.Find(Int64.Parse(textBox1.Text)).email;
                    label4.Text = db.client_info.Find(Int64.Parse(textBox1.Text)).Balance + " $";
                    textBox8.Text = db.client_info.Find(Int64.Parse(textBox1.Text)).phone.ToString();
                    textBox9.Text = db.client_info.Find(Int64.Parse(textBox1.Text)).countryNegative;
                    byte[] pic = db.client_info.Find(Int64.Parse(textBox1.Text)).picture;
                    MemoryStream mem = new MemoryStream(pic);
                    pictureBox1.Image = Image.FromStream(mem);
                }
                catch { if (label2.Text =="") { MessageBox.Show("Client doesn't existe"); } }//MessageBox.Show("Client doesn't existe");}
            }
            else { MessageBox.Show("Fill the Account Number"); }
        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {

        }
    }
}
