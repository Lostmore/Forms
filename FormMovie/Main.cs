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
using OfficeOpenXml;
using LicenseContext = OfficeOpenXml.LicenseContext;
using System.Globalization;

namespace FormMovie
{

    public partial class Main : Form
    {
        public static string connectString = "Provider = Microsoft.ACE.OLEDB.12.0;Data Source = 17..20.mdb";
        private OleDbConnection myConnection;
        private bool isUpdatingComboBox = false;

        public Main()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();


            LoadMoviesToComboBox();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
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
            if (int.TryParse(textBox2.Text.Trim(), out int kod))
            {
                string checkQuery = "SELECT COUNT(*) FROM Movies WHERE Movie_id = @kod";
                using (OleDbCommand checkCommand = new OleDbCommand(checkQuery, myConnection))
                {
                    checkCommand.Parameters.AddWithValue("@kod", kod);
                    int count = (int)checkCommand.ExecuteScalar();

                    if (count == 0)
                    {
                        MessageBox.Show("Фильм с указанным ID не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                string query = "DELETE FROM Movies WHERE Movie_id = @kod";
                using (OleDbCommand command = new OleDbCommand(query, myConnection))
                {
                    command.Parameters.AddWithValue("@kod", kod);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Данные о фильме удалены.");
                    this.moviesTableAdapter.Fill(this._17__20DataSet.Movies);
                }
            }
            else
            {
                MessageBox.Show("Введите корректный ID фильма.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int kod))
            {
                if (double.TryParse(textBox3.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double rating))
                {
                    string query = "UPDATE Movies SET Rating = @Rating WHERE Movie_id = @MovieId";
                    using (OleDbCommand command = new OleDbCommand(query, myConnection))
                    {
                        command.Parameters.AddWithValue("@Rating", rating);
                        command.Parameters.AddWithValue("@MovieId", kod);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Данные о фильме обновлены.");
                    this.moviesTableAdapter.Fill(this._17__20DataSet.Movies);
                }
                else
                {
                    MessageBox.Show("Введите корректный рейтинг.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите корректный ID фильма.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Add add = new Add();
            add.Owner = this; // Устанавливаем владельца для новой формы
            this.Hide(); // Скрываем текущую форму
            add.FormClosed += (s, args) => this.Show(); // Возвращаем текущую форму при закрытии новой
            add.Show(); // Показываем новую форму
            myConnection.Close(); // Закрываем соединение
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
            string input = textBox5.Text.Trim();
            System.Data.DataTable resultTable = new System.Data.DataTable();

            if (int.TryParse(input, out int yearValue))
            {
                string sqlSearchByYear = "SELECT * FROM Movies WHERE Year_of_issue = @Year";
                using (OleDbCommand commandSearchByYear = new OleDbCommand(sqlSearchByYear, myConnection))
                {
                    commandSearchByYear.Parameters.AddWithValue("@Year", yearValue);
                    OleDbDataAdapter adapterByYear = new OleDbDataAdapter(commandSearchByYear);
                    adapterByYear.Fill(resultTable);
                }

                if (resultTable.Rows.Count > 0)
                {
                    dataGridView1.DataSource = resultTable;
                }
                else
                {
                    MessageBox.Show("Нет фильмов с годом выпуска " + yearValue, "Результат поиска", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Введите корректный год выпуска фильма.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (myConnection.State == ConnectionState.Closed)
            {
                myConnection.Open();
            }

            string sqlCount = "SELECT TOP 3 BH.Movie_id, COUNT(*) AS ViewsCount, M.Film_name " +
                              "FROM [Browsing history] BH " +
                              "INNER JOIN Movies M ON BH.Movie_id = M.Movie_id " +
                              "GROUP BY BH.Movie_id, M.Film_name " +
                              "ORDER BY COUNT(*) DESC";

            using (OleDbCommand commandCount = new OleDbCommand(sqlCount, myConnection))
            {
                List<string> results = new List<string>();

                using (OleDbDataReader reader = commandCount.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string movieId = reader["Movie_id"].ToString();
                        string filmName = reader["Film_name"].ToString();
                        int viewsCount = Convert.ToInt32(reader["ViewsCount"]);

                        string result = $"Фильм ID: {movieId}, Название: {filmName},\nКоличество просмотров: {viewsCount}";
                        results.Add(result);
                    }
                }

                MessageBox.Show("Топ-3 фильмов с наибольшим количеством просмотров:\n\n" + string.Join("\n", results), "Результаты запроса", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }   
            myConnection.Close();
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


        private void SortMovies(string sortBy)
        {
            string query = $"SELECT * FROM Movies ORDER BY {sortBy}";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            System.Data.DataTable dataTable = new System.Data.DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void sortByNameToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Сортировка по имени сработала");
            SortMovies("Film_name");
        }

        private void sortByYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Сортировка по году сработала");
            SortMovies("Year_of_issue");
        }

        private void sortByRatingToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Сортировка по рейтингу сработала");
            SortMovies("Val(Rating)");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form tempForm = new Form
            {
                Text = "Экспорт данных в Excel",
                Size = new Size(330, 220),
                StartPosition = FormStartPosition.CenterParent
            };

            Button moviesButton = new Button
            {
                Text = "Movies",
                Dock = DockStyle.Top,
                Height = 40
            };

            Button usersButton = new Button
            {
                Text = "Users",
                Dock = DockStyle.Top,
                Height = 40
            };

            Button browsingHistoryButton = new Button
            {
                Text = "Browsing history",
                Dock = DockStyle.Top,
                Height = 40
            };

            Button exportButton = new Button
            {
                Text = "Экспортировать",
                Dock = DockStyle.Bottom
            };

            tempForm.Controls.Add(moviesButton);
            tempForm.Controls.Add(usersButton);
            tempForm.Controls.Add(browsingHistoryButton);
            tempForm.Controls.Add(exportButton);

            string selectedTable = ""; 

            moviesButton.Click += (s, args) => selectedTable = "Movies";
            usersButton.Click += (s, args) => selectedTable = "Users";
            browsingHistoryButton.Click += (s, args) => selectedTable = "Browsing history";

            exportButton.Click += (s, args) =>
            {
                if (string.IsNullOrEmpty(selectedTable))
                {
                    MessageBox.Show("Пожалуйста, выберите таблицу для экспорта.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel файлы (*.xlsx)|*.xlsx", // Фильтр для формата Excel
                    Title = "Сохранить файл как",
                    FileName = selectedTable + ".xlsx" 
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                        using (ExcelPackage excelPackage = new ExcelPackage())
                        {
                            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add(selectedTable);

                            string query = $"SELECT * FROM {selectedTable}";
                            OleDbCommand command = new OleDbCommand(query, myConnection);
                            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            for (int i = 0; i < dataTable.Columns.Count; i++)
                            {
                                worksheet.Cells[1, i + 1].Value = dataTable.Columns[i].ColumnName;
                            }

                            for (int i = 0; i < dataTable.Rows.Count; i++)
                            {
                                for (int j = 0; j < dataTable.Columns.Count; j++)
                                {
                                    worksheet.Cells[i + 2, j + 1].Value = dataTable.Rows[i][j].ToString();
                                }
                            }

                            excelPackage.SaveAs(new System.IO.FileInfo(saveFileDialog.FileName));
                            MessageBox.Show("Экспорт данных завершен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при экспорте данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };

            tempForm.ShowDialog();
        }


        private void ExportTable(string tableName)
        {
            try
            {
                string query = $"SELECT * FROM [{tableName}]";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    var workSheet = excelPackage.Workbook.Worksheets.Add(tableName);
                    workSheet.Cells["A1"].LoadFromDataTable(dataTable, true);
                    string filePath = $"{tableName}.xlsx";
                    System.IO.FileInfo excelFile = new System.IO.FileInfo(filePath);
                    excelPackage.SaveAs(excelFile);
                    MessageBox.Show($"Экспорт таблицы '{tableName}' завершен. Файл сохранен как '{filePath}'.", "Экспорт завершен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при экспорте: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuSort.Show(button5, new Point(0, button5.Height));
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                ComboBoxItem selectedMovie = (ComboBoxItem)comboBox1.SelectedItem;

                int movieId = selectedMovie.Id;

                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить фильм?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string query = "DELETE FROM Movies WHERE Movie_id = @MovieId";
                    using (OleDbCommand command = new OleDbCommand(query, myConnection))
                    {
                        command.Parameters.AddWithValue("@MovieId", movieId);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Данные о фильме удалены.");
                        comboBox1.Items.Remove(selectedMovie); 
                        this.moviesTableAdapter.Fill(this._17__20DataSet.Movies);
                    }
                }
            }
        }

        private class ComboBoxItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Year { get; set; }
            public string Director { get; set; }
            public string Country { get; set; }
            public string Genre { get; set; }
            public string Rating { get; set; }

            public override string ToString() => $"{Name} ({Year})";
        }


        private void LoadMoviesToComboBox()
        {
            string query = "SELECT Movie_id, Film_name, Year_of_issue FROM Movies";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ComboBoxItem item = new ComboBoxItem
                {
                    Id = Convert.ToInt32(reader["Movie_id"]),
                    Name = reader["Film_name"].ToString(),
                    Year = Convert.ToInt32(reader["Year_of_issue"])
                };
                comboBox1.Items.Add(item);
            }
            reader.Close();
        }
    }
}
