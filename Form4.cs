using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace GUIFORM
{
    public partial class Form4 : Form
    {
        Dictionary<int, string> user_logins = new Dictionary<int, string>();
        Stack<string> user_log = new Stack<string>();
        
        public Form4()
        {
            InitializeComponent();
        }

        public double hour { get; set; }
        private List<string> login_dates = new List<string> { };
        TextWriter tsw;
        public DateTime date_selected { get; set; }
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
        private List<string> Schedule = new List<string> { };
        private List<string> mes = new List<string> { };
        private List<int> count = new List<int> { };
        private List<string> events = new List<string> { };
        private List<string> dates = new List<string> { };
        private List<string> bolded_dates = new List<string> { };
        private List<int> insulin = new List<int> { };
        private List<int> Shot = new List<int> { };
        int h;
        int m;
        int s;
        private bool isNotFour(int n)
        {
            return n != trackBar1.Value;
        }
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
        private void Form4_Load(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            user_log.Push(DateTime.Now.ToShortDateString());
            
            string s = DateTime.Now.ToShortDateString() + Environment.NewLine;
            File.AppendAllText("C:/Users/Asus/source/repos/GUIFORM/Login_info.txt", s);
            foreach (string line in File.ReadLines("C:/Users/Asus/source/repos/GUIFORM/Login_info.txt"))
                dates.Add(line);
            var b_d = dates.Distinct();
            foreach (string Item in b_d)
                bolded_dates.Add(Item);
            f3.hour = Properties.Settings.Default.hour;
            DateTime date1 = new DateTime(2022, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 00);
            hour = f3.hour;
            long intpart = (long)hour;
            int HOUR = Convert.ToInt32(intpart);
            double fractionalPart = (hour - intpart) * 100;
            int Minute = Convert.ToInt32(fractionalPart);
            DateTime date = new DateTime(2022, DateTime.Now.Month, DateTime.Now.Day, HOUR, Minute, 00);

            notifyIcon1.Text = "Take Your Insulin Shot";
            notifyIcon1.BalloonTipText = "Take Your Insulin Shot Hour:" + f3.hour;
            notifyIcon1.BalloonTipTitle = "Remindment";
            notifyIcon1.Icon = SystemIcons.Application;
            pictureBox1.ImageLocation = Properties.Settings.Default.imageloc;
            if (date1 == date)
                for (int i = 0; i < 3; i++)
                    notifyIcon1.ShowBalloonTip(50);
            Thread.Sleep(200);
            //if (date1 != date)
            //Thread.Sleep(Math.Abs((DateTime.Now.Hour - HOUR) * 3600000) + Math.Abs((DateTime.Now.Minute - Minute) * 60000));
            //for(int n = 0; n < 3; n++)
            //notifyIcon1.ShowBalloonTip(1000);
            //Thread.Sleep(1);
            //sleeptimeis28400000
            pictureBox1.ImageLocation = Properties.Settings.Default.imageloc;

            int HR = Convert.ToInt32(intpart);
            if (Convert.ToInt32(fractionalPart) >= 30)
                HR = HR + 1;
            else
                HR = HR;
            label5.Text = "For optimization of timer, please scroll to 24.";
            button2.Text = "Start Timer";
            var randomIndex = new Random().Next(0, FunInfo.Count - 1);
            var info = FunInfo[randomIndex];
            richTextBox1.Text = info;
            var randomIndex1 = new Random().Next(0, motivation.Count - 1);
            var info1 = motivation[randomIndex];
            richTextBox2.Text = info1;
            date_selected = new DateTime(2022, 9, 19,0,0,0);
            monthCalendar1.BoldedDates = new System.DateTime[] { new System.DateTime() };
            try
            {
                if (DateTime.Now.ToLongDateString() == Properties.Settings.Default.dates || monthCalendar1.SelectionStart == date_selected)
                {
                    monthCalendar1.BoldedDates.Append(date_selected);
                }
            }
            catch(Exception)
            { }
            for (int i = 0; i < bolded_dates.Count();i++)
            {
                DateTime myDate = DateTime.ParseExact(bolded_dates[i], "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
                monthCalendar1.AddAnnuallyBoldedDate(myDate);
                
            }
            monthCalendar1.UpdateBoldedDates();

            login_dates.Add(date_selected.ToLongDateString());

            if (login_dates.Contains(DateTime.Now.ToLongDateString())==false)
                login_dates.Add(DateTime.Now.ToLongDateString());
                Properties.Settings.Default.dates = Properties.Settings.Default.dates + login_dates.Last();

            label14.Text = DateTime.Now.ToShortDateString();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            Form2 f2 = new Form2();
            Form3 f3 = new Form3();

            Form5 f5 = new Form5();
            Form1 f1 = new Form1();
            f5.Close();
            f1.Username = f2.username;
            f1.Age = f2.age;
            f1.Med = f2.medical;
            f1.Gender = f2.gender;
            f2.ShowDialog();
            ;

        }
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            hour = f3.hour;
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


            int[] time = { 8, 12, 19 };

            for (int i = 0; i < 3; i++)
                if ((HR + (8 * i)) <= 24 && trackBar1.Value == HR + (8 * i))
                {
                    textBox1.Text = trackBar1.Value.ToString() + ":00 Take Your Insulin Shot";
                    insulin.Add(trackBar1.Value);
                    Schedule.Add(trackBar1.Value.ToString());
                    if (trackBar1.Value != 8 && trackBar1.Value != 12 && trackBar1.Value != 19)
                    {
                        if (Schedule.Contains((8).ToString()) == true || Schedule.Contains((12).ToString()) == true || Schedule.Contains((19).ToString()) == true)
                            return;
                        else
                            foreach (int n in time)
                                Schedule.Add((n).ToString());
                    }
                    else if (trackBar1.Value == 8 || trackBar1.Value == 12 || trackBar1.Value == 19)
                    {
                        time = Array.FindAll(time, isNotFour).ToArray();
                        int r = trackBar1.Value;

                        foreach (int n in time)
                            Schedule.Add((n).ToString());

                    }
                }

                else if (HR + (8 * i) > 24 && trackBar1.Value == HR + (8 * i) - 24)
                {
                    textBox1.Text = trackBar1.Value.ToString() + ":00 Take Your Insulin Shot";
                    Schedule.Add(trackBar1.Value.ToString());
                    insulin.Add(trackBar1.Value);
                    if (trackBar1.Value != 8 && trackBar1.Value != 12 && trackBar1.Value != 19)
                    {
                        if (Schedule.Contains((8).ToString()) == true || Schedule.Contains((12).ToString()) == true || Schedule.Contains((19).ToString()) == true)
                            return;
                        else
                            foreach (int n in time)
                                Schedule.Add((n).ToString());

                    }
                    else if (trackBar1.Value == 8 || trackBar1.Value == 12 || trackBar1.Value == 19)
                    {
                        time = Array.FindAll(time, isNotFour).ToArray();
                        foreach (int n in time)
                            Schedule.Add((n).ToString());
                    }
                }
            if (trackBar1.Value == 24 || textBox1.Text== "24:00 Take Your Insulin Shot")
            {
                button2.Enabled = true;
                button2.Text = "Start Timer";
            }
            

        }
        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            trackBar1.ResetText();
        }
        public string x { get; set; }
        public string y { get; set; }
        private void button2_Click(object sender, EventArgs e)
        {
            x = "Event Times:";
            var ms = Schedule.Distinct();
            foreach (var item in ms)
            {
                x=x+item+",";
                mes.Add(item);


            }
            mes.Sort();
            label6.Text = x;
            int C = DateTime.Now.Hour;
            for (int i = 0; i < mes.Count(); i++)
                if (Convert.ToInt32(mes[i]) > C)
                    count.Add(Convert.ToInt32(mes[i]));
            count.Sort();
            var shot=count.Select(i => i).Intersect(insulin);
            foreach (var item in shot)
            {
                y = y + item + ",";
                Shot.Add(item);
            }

            try
                {
                if (Shot[0] == count[0])
                    label11.Text = "Insulin Shot";
                else if (count[0] == 8)
                    label11.Text = "Breakfast";
                else if (count[0] == 12)
                    label11.Text = "Lunch";
                else if (count[0] == 19)
                    label11.Text = "Dinner";
                }
            catch(Exception)
            { }

            label10.Text = "Next Event:"+Convert.ToString(count[0])+":00" ;
            h = count[0] - (DateTime.Now.Hour + 1);
            m = 60 - (DateTime.Now.Minute + 1);
            s = 60 - DateTime.Now.Second;
            timer1.Start();
// var minutes = (count[n]-(DateTime.Now.Hour+1))*60+(60-DateTime.Now.Minute); //countdown time
  //          var start = DateTime.UtcNow; // Use UtcNow instead of Now
    //        var endTime = start.AddMinutes(minutes); //endTime is a member, not a local variable
      //      timer1.Enabled = true;
            
        //    TimeSpan remainingTime = endTime - DateTime.UtcNow;
          //  if (remainingTime < TimeSpan.Zero)
            //{
            //    label7.Text = "done, next event";
              //  n++;
                //minutes=count[n];
            //}
            //else
            //{
              //  label7.Text = remainingTime.ToString();
            //}


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
            string mm=Convert.ToString(m);
            string hh=Convert.ToString(h);
            string ss = Convert.ToString(s);
            label7.Text = hh;
            label8.Text = mm;
            label9.Text = ss;
            
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel1.LinkVisited = true;

            System.Diagnostics.Process.Start("https://www.cdc.gov/diabetes/managing/index.html");
        }
       
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            date_selected = monthCalendar1.SelectionRange.Start.ToLocalTime();

            label14.Text = date_selected.ToLongDateString();

            monthCalendar1.AddAnnuallyBoldedDate(date_selected);
            monthCalendar1.AddAnnuallyBoldedDate(Convert.ToDateTime(DateTime.Now.ToLongTimeString()).ToLocalTime());
            monthCalendar1.UpdateBoldedDates();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
