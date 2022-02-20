using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;


namespace WindowsFormsApplication1
{
    public partial class user22 : UserControl
    {
        string validEmailPattern = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
        byte[] imga = null;
        string img = "";
        bool error = false;
        BANKEntities db = new BANKEntities();
        public user22()
        {
            InitializeComponent();
        }
        private void user22_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            string[] et = File.ReadAllLines("iso.csv");
            List<string> a = new List<string>();
            DataTable dt = new DataTable();
            for(int i = 0;i<et.Length;i++)
            {
                a.Add(et[i]);
            }
            comboBox1.DataSource = a.ToArray();

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
            comboBox4.SelectedIndex = 149;
            comboBox1.SelectedIndex = 147;
            
        }
        
        private void check()
        {
            if (!Regex.IsMatch(textBox6.Text, validEmailPattern))
            {
                errorProvider1.SetError(textBox6, "Wrong Format");
                error = true;
            }
            else
            {
                error = false;
                errorProvider1.Clear();
            }
            if (textBox7.Text == "")
            {
                errorProvider2.SetError(textBox7, "insert phone number");
                error = true;
            }
            else
            {
                error = false;
                errorProvider2.Clear();
            }
            if (comboBox2.Text == "")
            {
                errorProvider3.SetError(comboBox2, "You need to choose");
                error = true;
            }
            else
            {
                error = false;
                errorProvider3.Clear();
            }
            if (comboBox3.Text == "")
            {
                errorProvider4.SetError(comboBox3, "Choose One");
                error = true;
            }
            else
            {
                error = false;
                errorProvider4.Clear();
            }
            if(textBox5.Text=="")
            {
                errorProvider6.SetError(textBox5, "Enter The Full Name");
                error = true;
            }
            else
            {
                error = false;
                errorProvider6.Clear();
            }
            if (dateTimePicker1.Value >= DateTime.Now.Date)
            {
                errorProvider6.SetError(dateTimePicker1, "The birth date must be smaller than today date");
                error = true;
            }
            else
            {
                error = false;
                errorProvider6.Clear();
            }
        }
        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                check();
                Regex rx = new Regex(validEmailPattern);
                if (rx.IsMatch(textBox6.Text) && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && textBox7.Text != "" && dateTimePicker1.Value<DateTime.Now.Date)
                {
                    DialogResult res = MessageBox.Show("You wanna add a new Client", "Confermation", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        db.client_info.Add(new client_info
                        {
                            fullName = textBox5.Text,
                            email = textBox6.Text,
                            phone = Int64.Parse(textBox7.Text),
                            countryNegative = comboBox1.Text,
                            card_type = comboBox2.Text,
                            gender = comboBox3.Text,
                            Nationality = comboBox4.Text,
                            dateOfBirth = dateTimePicker1.Value.Date,
                            picture = imga
                        });
                        db.SaveChanges();
                        MessageBox.Show("the Client had enregistred successfully");
                        textBox5.Clear();textBox6.Clear();textBox7.Clear();pictureBox5.ImageLocation = null;
                        comboBox2.SelectedIndex = -1;comboBox3.SelectedIndex = -1;img = "";
                    }
                }
                else
                {}
            }
            catch{ MessageBox.Show("Verify you're information"); }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fildlg = new OpenFileDialog();
                fildlg.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                fildlg.Title = "Select Employee Picture";
                if(fildlg.ShowDialog() == DialogResult.OK)
                {
                    img = fildlg.FileName.ToString();
                    pictureBox5.ImageLocation = img;
                }
                FileStream fs = new FileStream(img, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                imga = br.ReadBytes((int)fs.Length);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            int isNumber = 0;
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
