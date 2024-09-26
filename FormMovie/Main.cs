using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace FormMovie
{

    public partial class Main : Form
    {
        public static string connectString = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source = 17..20.mdb";
        private OleDbConnection myConnection;
        public Main()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_17__20DataSet.Movies". При необходимости она может быть перемещена или удалена.
            this.moviesTableAdapter.Fill(this._17__20DataSet.Movies);
            dataGridView1.AllowUserToAddRows = false;
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_17__20DataSet.Browsing_history". При необходимости она может быть перемещена или удалена.
            this.browsing_historyTableAdapter.Fill(this._17__20DataSet.Browsing_history);

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox1.Text);
            string query = "DELETE FROM Movies WHERE Movie_id = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные о фильме удалены.");
            this.moviesTableAdapter.Fill(this._17__20DataSet.Movies);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int kod = Convert.ToInt32(textBox2.Text);
            string query = "UPDATE Movies SET Rating = " + Convert.ToString(textBox3.Text) + " WHERE Movie_id = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные о фильме обновлены.");
            this.moviesTableAdapter.Fill(this._17__20DataSet.Movies);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Add add = new Add();
            add.Owner = this;
            add.Show();
            myConnection.Close();
        }


        private void button4_Click(object sender, EventArgs e)
        {

            string searchTerm = textBox4.Text.Trim();
            string sqlSearch = "SELECT * FROM Movies WHERE Film_name LIKE @SearchTerm";
            OleDbCommand commandSearch = new OleDbCommand(sqlSearch, myConnection);
            commandSearch.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
            OleDbDataAdapter adapter = new OleDbDataAdapter(commandSearch);
            System.Data.DataTable dataTable = new System.Data.DataTable();
            adapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;
            this.moviesTableAdapter.Fill(this._17__20DataSet.Movies);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string searchTerm = textBox4.Text.Trim();
            string rating;
            int year;

            string sqlSearch = "SELECT * FROM Movies WHERE Film_name LIKE @SearchTerm";
            OleDbCommand commandSearch = new OleDbCommand(sqlSearch, myConnection);
            commandSearch.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
            OleDbDataAdapter adapter = new OleDbDataAdapter(commandSearch);
            System.Data.DataTable dataTable = new System.Data.DataTable();
            adapter.Fill(dataTable);

            dataGridView1.DataSource = dataTable;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string Rating = textBox5.Text.Trim();
            string Year = textBox5.Text.Trim();
            try
            {
                String ratingValue = Convert.ToString(Rating);
                string sqlSearchByRating = "SELECT * FROM Movies WHERE Val(Rating) >= @Rating";

                OleDbCommand commandSearchByRating = new OleDbCommand(sqlSearchByRating, myConnection);
                commandSearchByRating.Parameters.AddWithValue("@Rating", ratingValue);
                OleDbDataAdapter adapterByRating = new OleDbDataAdapter(commandSearchByRating);
                System.Data.DataTable dataTableByRating = new System.Data.DataTable();
                adapterByRating.Fill(dataTableByRating);

                dataGridView1.DataSource = dataTableByRating;

            }
            catch (FormatException)
            {
                MessageBox.Show("Введите корректное числовое значение рейтинга или год выпуска фильма.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                int yearValue = Convert.ToInt32(Year);

                string sqlSearchByYear = "SELECT * FROM Movies WHERE Year_of_issue = @Year";

                OleDbCommand commandSearchByYear = new OleDbCommand(sqlSearchByYear, myConnection);
                commandSearchByYear.Parameters.AddWithValue("@Year", yearValue);
                OleDbDataAdapter adapterByYear = new OleDbDataAdapter(commandSearchByYear);
                System.Data.DataTable dataTableByYear = new System.Data.DataTable();
                adapterByYear.Fill(dataTableByYear);

                dataGridView1.DataSource = dataTableByYear;

            }
            catch (FormatException)
            {

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string sqlCount = "SELECT TOP 3 BH.Movie_id, COUNT(*) AS ViewsCount, M.Film_name " +
                       "FROM [Browsing history] BH " +
                       "INNER JOIN Movies M ON BH.Movie_id = M.Movie_id " +
                       "GROUP BY BH.Movie_id, M.Film_name " +
                       "ORDER BY COUNT(*) DESC";

            OleDbCommand commandCount = new OleDbCommand(sqlCount, myConnection);

            List<string> results = new List<string>();
            using (OleDbDataReader reader = commandCount.ExecuteReader())
            {
                while (reader.Read())
                {
                    string movieId = reader["Movie_id"].ToString();
                    string filmName = reader["Film_name"].ToString();
                    int viewsCount = Convert.ToInt32(reader["ViewsCount"]);

                    string result = $"Фильм ID: {movieId}, Название: {filmName},\n Количество просмотров: {viewsCount}";
                    results.Add(result);
                }
            }
            MessageBox.Show("Топ-3 фильмов с наибольшим количеством просмотров:\n\n" + string.Join("\n", results), "Результаты запроса", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string sqlCount = "SELECT BH.User_id, U.User_name, U.User_surname, COUNT(*) AS ViewsCount " +
                              "FROM [Browsing history] BH " +
                              "INNER JOIN Users U ON BH.User_id = U.User_id " +
                              "GROUP BY BH.User_id, U.User_name, U.User_surname " +
                              "ORDER BY COUNT(*) DESC";

            OleDbCommand commandCount = new OleDbCommand(sqlCount, myConnection);

            OleDbDataAdapter adapterCount = new OleDbDataAdapter(commandCount);
            System.Data.DataTable dataTableCount = new System.Data.DataTable();
            adapterCount.Fill(dataTableCount);

            if (dataTableCount.Rows.Count > 0)
            {
                string mostActiveUserId = dataTableCount.Rows[0]["User_id"].ToString();
                string mostActiveUserName = dataTableCount.Rows[0]["User_name"].ToString();
                string mostActiveUserSurname = dataTableCount.Rows[0]["User_surname"].ToString();
                int viewsCount = Convert.ToInt32(dataTableCount.Rows[0]["ViewsCount"]);

                MessageBox.Show($"Самый активный пользователь: {mostActiveUserName} {mostActiveUserSurname} (ID: {mostActiveUserId})\nКоличество просмотров: {viewsCount}", "Самый активный пользователь", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Нет данных о просмотрах в таблице.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
