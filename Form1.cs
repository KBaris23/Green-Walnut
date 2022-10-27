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
    public partial class Form1 : Form
    {
        public string Username { get; set; }
        public string Age { get; set; }

        public string Med
        {
            get; set;
        }
        public string Gender { get; set; }
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do You Want to Exit the Application?", "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                this.Hide();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.gender = radioButton1.Text;
            Gender = radioButton1.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.gender = radioButton2.Text;
            Gender= radioButton2.Text;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button3.Enabled = checkBox1.Checked;
        }

       
        public void GetSettings()
        {
            Form2 f2 = new Form2();
            textbox1.Text = Properties.Settings.Default.username;
            textBox2.Text = Properties.Settings.Default.age.ToString();
            comboBox1.Text= Properties.Settings.Default.medical;
            if (radioButton1.Checked == true)
                radioButton1.Text=Properties.Settings.Default.gender;
            if (radioButton2.Checked == true)
                radioButton2.Text=Properties.Settings.Default.gender;


        }
        public void SaveSettings()
        {

            Properties.Settings.Default.username = textbox1.Text;
            Properties.Settings.Default.age = textBox2.Text;
            Properties.Settings.Default.medical = comboBox1.Text;
            if (radioButton1.Checked == true)
                Properties.Settings.Default.gender=radioButton1.Text ;
            if (radioButton2.Checked == true)
                Properties.Settings.Default.gender= radioButton2.Text ;
            Properties.Settings.Default.username.Insert(0,textbox1.Text);
            
            Properties.Settings.Default.Save();
        }


        private void Form1_Load_1(object sender, EventArgs e)
        {
            GetSettings();

        }
         private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("welcome");
            Form1 f1 = new Form1();
            Form2 f2 = new Form2();
            Form5 f5 = new Form5();
            if (radioButton1.Checked == true)
                Gender = radioButton1.Text;
            if (radioButton2.Checked ==true)
            {
                Gender = radioButton2.Text;
            }
            f2.gender = Gender;
            string Username = textbox1.Text;
            string Age = textBox2.Text;
            string Med = comboBox1.Text;
            f2.username = Username;
            f2.gender = Gender;
            f2.age = Age;
            f2.medical = Med;
            Form3 f3 = new Form3();

            if (comboBox1.Text == "Diabetes or Muscular Diseases")
                f3.Show();
                
            if (comboBox1.Text != "Diabetes or Muscular Diseases")
                f2.ShowDialog();
            SaveSettings();
            GetSettings();
        }
    }



}


        
    
    



