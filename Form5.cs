using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Drawing.Drawing2D;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



namespace GUIFORM
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        public void RetrieveData()
        {
            Form2 f2 = new Form2();
            f2.username = Properties.Settings.Default.username;
            f2.age = Properties.Settings.Default.age;
            f2.medical = Properties.Settings.Default.medical;
            f2.gender = Properties.Settings.Default.gender;
        }
        int h;
        int m;
        int s;
        private List<string> FunInfo = new List<string> { "You tend to blink your eyes about 20 times a minute, which equals ten million times a year.","While your height stops growing after one hits puberty, your ears and nose are constantly lengthening, and gravity is to blame for this phenomenon.",
"Our cornea, the transparent front part of the eyes, doesn’t get any blood supply and receives oxygen directly from the air!",
"Did you know? A weird fact about the human body is that it consists of so much fat that it can make up to seven bars of soap.",
"Once the oxygen supply is cut off, a human brain can survive up to three to six minutes.",
"Humans develop fingertips from the time they were embryos, only three months after they are conceived. This means that just after the first trimester, the baby has fully developed fingertips.",
"When a human blushes, they feel it in the lining of the stomach too as it also turns red.",
 "A weird fact about height is that when in space, astronauts can grow almost up to two inches.",
 "Your heart can sync to the rhythm when you listen to music.",
"Throughout their lifespan, humans go from having 300 bones to 206 bones.",
 "A human heart can beat outside the body as well."};
        private List<string> motivation = new List<string> { "You’ve gotta dance like there’s nobody watching, love like you’ll never be hurt, sing like there’s nobody listening, and live like it’s heaven on earth.” —William W. Purkey",
"“Fairy tales are more than true: not because they tell us that dragons exist, but because they tell us that dragons can be beaten.”―Neil Gaiman",
"“Everything you can imagine is real.”―Pablo Picasso",
"“When one door of happiness closes, another opens; but often we look so long at the closed door that we do not see the one which has been opened for us.” ―Helen Keller",
"“Do one thing every day that scares you.” ―Eleanor Roosevelt",
"“It’s no use going back to yesterday, because I was a different person then.” ―Lewis Carroll",
"“Smart people learn from everything and everyone, average people from their experiences, stupid people already have all the answers.” —Socrates",
"“Do what you feel in your heart to be right―for you’ll be criticized anyway.” ―Eleanor Roosevelt",
"“Happiness is not something ready made. It comes from your own actions.” ―Dalai Lama XIV",
"“Whatever you are, be a good one.” ―Abraham Lincoln" };
        private List<string> dates = new List<string> { };
        private List<string> bolded_dates = new List<string> { };
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            Form5 f5 = new Form5();
            Form1 f1 = new Form1();

            Database f6 = new Database();
            RetrieveData();
            f1.Username= f2.username;
            f1.Age = f2.age;
            f1.Med= f2.medical;
            f1.Gender = f2.gender;
            f5.Hide();

            f2.ShowDialog();


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        public List<int> events = new List<int> {8,12,19 };
        public List<int> times = new List<int> { };
        private void Form5_Load(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            string imaglocation = Properties.Settings.Default.imageloc;
            int C = DateTime.Now.Hour;
            for (int i = 0; i < events.Count(); i++)
                if (events[i] > C)
                    times.Add(events[i]);
            times.Sort();

            pictureBox1.ImageLocation = imaglocation;
            label6.Text = DateTime.Now.ToString();
            var randomIndex = new Random().Next(0, FunInfo.Count - 1);
            var info = FunInfo[randomIndex];
            var randomIndex1 = new Random().Next(0, motivation.Count - 1);
            var info1 = motivation[randomIndex];
            
            richTextBox1.Text = info;
            richTextBox2.Text = info1;
            foreach (string line in File.ReadLines("C:/Users/Asus/source/repos/GUIFORM/Login_info.txt"))
                dates.Add(line);
            var b_d = dates.Distinct();
            foreach (string Item in b_d)
                bolded_dates.Add(Item);
            for (int i = 0; i < bolded_dates.Count(); i++)
            {
                DateTime myDate = DateTime.ParseExact(bolded_dates[i], "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                monthCalendar1.AddAnnuallyBoldedDate(myDate);

            }
            monthCalendar1.UpdateBoldedDates();

        }
        private List<string> _BackgroundColours = new List<string> { "339966", "3366CC", "CC33FF", "FF5050" };
        public MemoryStream GenerateCircle(string firstName)
        {
            firstName = Properties.Settings.Default.username;

            var avatarString = string.Format("{0}{1}", firstName[0], firstName[1]).ToUpper();


            var randomIndex = new Random().Next(0, _BackgroundColours.Count - 1);
            var bgColour = _BackgroundColours[randomIndex];

            var bmp = new Bitmap(192, 192);
            
            var sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            var font = new Font("Arial", 72, FontStyle.Bold, GraphicsUnit.Pixel);
            var graphics = Graphics.FromImage(bmp);

            graphics.Clear(Color.Blue);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            using (Brush b = new SolidBrush(ColorTranslator.FromHtml("#" + bgColour)))
            {
                graphics.FillEllipse(b, new Rectangle(0, 0, 192, 192));
            }
            graphics.DrawString(avatarString, font, new SolidBrush(Color.WhiteSmoke), 95, 100, sf);
            graphics.Flush();
            pictureBox1.Image = bmp;
            var ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Png);
            return ms;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string firstName = Properties.Settings.Default.username;
            var avatarString = string.Format("{0}{1}", firstName[0], firstName[1]).ToUpper();


            var randomIndex = new Random().Next(0, _BackgroundColours.Count - 1);
            var bgColour = _BackgroundColours[randomIndex];

            var bmp = new Bitmap(192, 192);

            var sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            var font = new Font("Arial", 72, FontStyle.Bold, GraphicsUnit.Pixel);
            var graphics = Graphics.FromImage(bmp);

            graphics.Clear(Color.Blue);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            using (Brush b = new SolidBrush(ColorTranslator.FromHtml("#" + bgColour)))
            {
                graphics.FillEllipse(b, new Rectangle(0, 0, 192, 192));
            }
            graphics.DrawString(avatarString, font, new SolidBrush(Color.WhiteSmoke), 95, 100, sf);
            graphics.Flush();
            pictureBox1.Image = bmp;
            var ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Png);

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            int HR = Properties.Settings.Default.HR;
            trackBar1.Maximum = 24;
            trackBar1.Minimum = 0;
            trackBar1.TickFrequency = 1;
            textBox1.Text = trackBar1.Value.ToString() + ":00";
            if (trackBar1.Value == 8)
                textBox1.Text = trackBar1.Value.ToString() + ":00 Breakfast";
            if (trackBar1.Value == 12)
                textBox1.Text = trackBar1.Value.ToString() + ":00 Lunch";
            if (trackBar1.Value == 19)
                textBox1.Text = trackBar1.Value.ToString() + ":00 Dinner";
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                label5.Text = "Next Event" + times[0].ToString() + ":00";
                if (times[0] == 8)
                    label4.Text = "Breakfast";
                else if (times[0] == 12)
                    label4.Text = "Lunch";
                else if (times[0] == 19)
                    label4.Text = "Dinner";
                h = times[0] - (DateTime.Now.Hour + 1);
                m = 60 - (DateTime.Now.Minute + 1);
                s = 60 - DateTime.Now.Second;
                timer1.Start();
            }
            catch (Exception)
            { }


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            s = s - 1;
            if (s == -1)
            {
                m = m - 1;
                s = 59;
            }
            if (m == -1)
            {
                h = h - 1;
                m = 59;
            }
            if (h == 0 && m == 0 && s == 0)
                timer1.Stop();
            string mm = Convert.ToString(m);
            string hh = Convert.ToString(h);
            string ss = Convert.ToString(s);
            label1.Text = hh;
            label2.Text = mm;
            label3.Text = ss;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel1.LinkVisited = true;

            System.Diagnostics.Process.Start("https://www.uhc.com/health-and-wellness/fitness/exercise-tips");
        }
        private DateTime date_selected = new DateTime();
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            date_selected = monthCalendar1.SelectionRange.Start.ToLocalTime();

            label5.Text = date_selected.ToLongDateString();

            monthCalendar1.AddAnnuallyBoldedDate(date_selected);
            monthCalendar1.AddAnnuallyBoldedDate(Convert.ToDateTime(DateTime.Now.ToLongTimeString()).ToLocalTime());
            monthCalendar1.UpdateBoldedDates();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
