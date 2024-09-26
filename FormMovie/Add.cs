using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormMovie
{
    public partial class Add : Form
    {
        public static string connectString = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source = 17..20.mdb";
        private OleDbConnection myConnection;
        public Add()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox1.Text);
            String Name = textBox2.Text;
            int date = Convert.ToInt32(textBox3.Text);
            String Author = textBox4.Text;
            String Country = textBox5.Text;
            String Genry = textBox6.Text;
            String Description = textBox9.Text;
            String rating = Convert.ToString(textBox7.Text);
            String time = textBox8.Text;
            string dateAdded = dateTimePicker1.Value.ToString("dd.MM.yyyy");
            string dateEdit = dateTimePicker2.Value.ToString("dd.MM.yyyy");
            string query = "INSERT INTO Movies (Movie_id, Film_name, Year_of_issue, Director, Description, Country, Genre, Rating, Duration, Date_added, Date_of_change) VALUES (" + kod + ",'" + Name + "','" + date + "','" + Author + "','" + Description + "','" + Country + "','" + Genry + "','" + rating + "','" + time + "','" + dateAdded + "','" + dateEdit + "')";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные о фильме добавлены.");
            this.Close();
        }

    }
}
