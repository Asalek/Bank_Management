using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class UserUpdate : UserControl
    {
        byte[] imga = null;
        string img = "";
        BANKEntities db = new BANKEntities();
        public UserUpdate()
        {
            InitializeComponent();
        }

        private void UserUpdate_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            button18.Enabled = false;
            pictureBox5.Visible = false;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Items.Add("Visa");
            comboBox2.Items.Add("MasterCard");
            comboBox3.Items.Add("Male");
            comboBox3.Items.Add("Female");

            List<string> list = new List<string>();
            list = CultureInfo.GetCultures(CultureTypes.SpecificCultures).Select(p => new RegionInfo(p.Name).EnglishName).Distinct().OrderBy(s => s).ToList();
            comboBox4.DataSource = list;
            /////////////////////
            string[] et = File.ReadAllLines("iso.csv");
            List<string> a = new List<string>();
            DataTable dt = new DataTable();
            for (int i = 0; i < et.Length; i++)
            {
                a.Add(et[i]);
            }
            comboBox1.DataSource = a.ToArray();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    textBox5.Text = db.client_info.Find(Int64.Parse(textBox1.Text)).fullName;
                    textBox6.Text = db.client_info.Find(Int64.Parse(textBox1.Text)).email;
                    textBox7.Text = db.client_info.Find(Int64.Parse(textBox1.Text)).phone.ToString();
                    comboBox1.SelectedItem = db.client_info.Find(Int64.Parse(textBox1.Text)).countryNegative.ToString();
                    comboBox2.SelectedItem = db.client_info.Find(Int64.Parse(textBox1.Text)).card_type.ToString();
                    comboBox3.SelectedItem = db.client_info.Find(Int64.Parse(textBox1.Text)).gender.ToString();
                    comboBox4.SelectedItem = db.client_info.Find(Int64.Parse(textBox1.Text)).Nationality.ToString();
                    dateTimePicker1.Value = db.client_info.Find(Int64.Parse(textBox1.Text)).dateOfBirth.Value;
                    button18.Enabled = true;
                    byte[] pic = db.client_info.Find(Int64.Parse(textBox1.Text)).picture;
                    MemoryStream mem = new MemoryStream(pic);
                    pictureBox5.Image = Image.FromStream(mem);
                    pictureBox5.Visible = true;
                    
                }
                catch {
                    //MessageBox.Show("Client doesn't existe !");
                 }
            }
            else
            {
                MessageBox.Show("Enter an Account Number");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fildlg = new OpenFileDialog();
                fildlg.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                fildlg.Title = "Select Employee Picture";
                if (fildlg.ShowDialog() == DialogResult.OK)
                {
                    img = fildlg.FileName.ToString();
                    pictureBox5.ImageLocation = img;
                }
                FileStream fs = new FileStream(img, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                imga = br.ReadBytes((int)fs.Length);
                pictureBox5.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("Update Client information ?", "Confermation", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    client_info t = db.client_info.Find(Int64.Parse(textBox1.Text));
                    if (t != null)
                    {
                        t.fullName = textBox5.Text;
                        t.email = textBox6.Text;
                        t.phone = Int64.Parse(textBox7.Text);
                        t.countryNegative = comboBox1.Text;
                        t.card_type = comboBox2.Text;
                        t.gender = comboBox3.Text;
                        t.Nationality = comboBox4.Text;
                        t.dateOfBirth = dateTimePicker1.Value;
                        t.picture = imga;
                        db.SaveChanges();
                        MessageBox.Show("Update succeed");
                        textBox5.Clear(); textBox6.Clear(); textBox7.Clear(); pictureBox5.ImageLocation = null;
                        comboBox2.SelectedIndex = -1; comboBox3.SelectedIndex = -1;textBox1.Clear();
                        pictureBox5.Visible = false;dateTimePicker1.Value = DateTime.Now;
                        button18.Enabled = false;
                    }
                    else { MessageBox.Show("Account Number invalid"); }
                }
            }
            catch { MessageBox.Show("Verify your information and try again"); }
        }
    }
}
