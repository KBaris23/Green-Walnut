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
    public partial class Form2 : Form
    {
        public string username { get; set; }
        public string age { get; set; }
        public string medical { get; set; }
        public string gender { get; set; }

        public Form2()
        {
            InitializeComponent();
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(.*jpg)|*.jpg| PNG files(.*png)|*.png| All Files(*.*)|*.*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                    imageLocation = dialog.FileName;
                    image1.ImageLocation = imageLocation;
                    Properties.Settings.Default.imageloc = imageLocation;
                    Properties.Settings.Default.Save();


                }
            }
            catch (Exception) {
                MessageBox.Show("An error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.username;
            textBox2.Text = Properties.Settings.Default.age;
            textBox3.Text = Properties.Settings.Default.medical;
            textBox4.Text = Properties.Settings.Default.gender;
            Form1 f1 = new Form1();
            f1.Gender = gender;
            f1.Username = username;
            f1.Age = age;
            f1.Med = medical;
            username = Properties.Settings.Default.username;
            age = Properties.Settings.Default.age;
            gender = Properties.Settings.Default.gender;
            medical = Properties.Settings.Default.medical;

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            if (radioButton1.Checked == true)
                textBox1.Text = Properties.Settings.Default.username;
                textBox2.Text = Properties.Settings.Default.age;
                textBox4.Text = Properties.Settings.Default.medical;
                textBox3.Text = Properties.Settings.Default.gender;
                image1.ImageLocation = Properties.Settings.Default.imageloc;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            Form5 f5 = new Form5();
            Form1 f1 = new Form1();
            Form2 f2 = new Form2();
            f2.Hide();
            if (textBox4.Text == "Diabetes or Muscular Diseases")
                f4.Show();
            if (textBox4.Text != "Diabetes or Muscular Diseases")
                f5.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
        }
    }
        
}
