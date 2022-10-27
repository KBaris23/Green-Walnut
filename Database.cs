using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace GUIFORM
{
    public partial class Database : Form
    {
        private System.Data.DataSet dataSet;
        public Database()
        {
            Console.WriteLine("Heyo");
            InitializeComponent();
            System.Data.DataTable table = new DataTable("Login_Dates");
            DataColumn column;
            DataRow days;
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "dates";
            column.ReadOnly = true;
            column.Unique = true;
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "logins";
            column.AutoIncrement = false;
            column.Caption = "logins";
            column.ReadOnly = true;
            column.Unique = false;
            // Add the column to the table.
            table.Columns.Add(column);

            // Make the ID column the primary key column.
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["dates"];
            table.PrimaryKey = PrimaryKeyColumns;

            // Instantiate the DataSet variable.
            dataSet = new DataSet();
            // Add the new DataTable to the DataSet.
            dataSet.Tables.Add(table);
            Object[] rows =
        {
            new Object[] {DateTime.Now.ToLongDateString() }

        };
            foreach (Object[] row in rows)
            {
                table.Rows.Add(row);
            }
            table.Rows.Add(DateTime.Now.ToLongDateString());
            
            Properties.Settings.Default.dates += ",";
            Properties.Settings.Default.dates +=  DateTime.Now.ToLongDateString();
            Properties.Settings.Default.dates += ",";
            // Properties.Settings.Default.dates
            Properties.Settings.Default.Save();





            // foreach (DataColumn col in table.Columns)
            //{
              //  Console.Write("{0,-14}", col.ColumnName);
            //}
            //Console.WriteLine();
            foreach (char s in Properties.Settings.Default.dates)
            {
                Console.WriteLine(s);
            }
            //foreach (DataRow row in table.Rows)
            //{
              //  foreach (DataColumn col in table.Columns)
                //{
                  //  if (col.DataType.Equals(typeof(DateTime)))
                    //    Console.Write("{0,-14:d}", row[col]);
                    //else if (col.DataType.Equals(typeof(Decimal)))
                      //  Console.Write("{0,-14:C}", row[col]);
                    //else
                      //  Console.Write("{0,-14}", row[col]);
                //}
                //Console.WriteLine();
            //}
            //Console.WriteLine();
        }
            private void Form6_Load(object sender, EventArgs e)
        {
            label1.Text= Properties.Settings.Default.username;
            label2.Text=Properties.Settings.Default.age;
            label3.Text=Properties.Settings.Default.medical;
            label4.Text= Properties.Settings.Default.gender;

            
            Properties.Settings.Default.Save();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
