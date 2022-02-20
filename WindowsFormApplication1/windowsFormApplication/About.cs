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
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void About_Load(object sender, EventArgs e)
        {
            ScrollBar sv = new VScrollBar();
            
        }

        private void lineShape1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text="Copyright © 2010 by Ayoub Salek \r\n \r\n"+
                "All rights reserved.No part of this publication may be reproduced, distributed, or transmitted in any form or by any means, including photocopying, recording, or other electronic or mechanical methods, without the prior written permission of the publisher, except in the case of brief quotations embodied in critical reviews and certain other noncommercial uses permitted by copyright law.For permission requests, write to the publisher, addressed “Attention: Permissions Coordinator,” at the address below.Imaginary Press quantity purchases by corporations, associations, and others. For details, contact the publisher at the address above. Please Contact Ayoub Salek for Source Code";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Email : Ayoub.salek8599@gmail.com \r\n"
                + "linkedin : AYOUB SALEK \r\n"
                + "Facebook : AYOUB SALEK\r\n"
                + "Twitter : @salek1999\r\n"                ;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Ayoub salek\r\nknowledge AT :\r\nC#\r\nSQL\r\nJavaScript\r\nC\r\nPython\r\n.Net(Entity FrameWork)\r\nHTML5/CSS3";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "AS Bank Management\r\nit's a bank software that made for manage databases easelly \r\nmade by C# language and SQL server both are belonging to Microsoft company";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
