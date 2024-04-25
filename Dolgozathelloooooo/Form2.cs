using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Dolgozathelloooooo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string orszag = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int honap = int.Parse(textBox3.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            int nap = int.Parse(textBox4.Text);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            int hossz = int.Parse(textBox5.Text);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string ellatas = textBox6.Text;
        }
    }
}
