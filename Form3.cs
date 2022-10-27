using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIFORM
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox4.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox5.Enabled = true;
        }
        public double hour { get; set; }
        public int response { get; set; }
        public int HR { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            Form4 f4 = new Form4();


            hour = double.Parse(textBox1.Text);
            Properties.Settings.Default.hour = hour;
            textBox1.Text = Convert.ToString(Properties.Settings.Default.hour);
            Properties.Settings.Default.Save();
            f4.Show();
            long intpart = (long)hour;
            int HOUR = Convert.ToInt32(intpart);
            double fractionalPart = (hour - intpart) * 100;
            HR = Convert.ToInt32(intpart);
            if (Convert.ToInt32(fractionalPart) >= 30)
                HR = HR + 1;
            else
                HR = HR;
            Properties.Settings.Default.HR = HR;
        }
    }
}
