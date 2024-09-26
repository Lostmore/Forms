using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
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

        private string logFilePath = "log.txt";

        public Add()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();


            LoadMoviesToComboBox();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }





        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            String Name = textBox2.Text;
            int date = Convert.ToInt32(textBox3.Text);

            // Проверка, существует ли фильм в базе
            if (CheckIfMovieExists(Name, date))
            {
                MessageBox.Show("Фильм уже существует в базе данных.");
                return;
            }

            try
            {
                String Author = textBox4.Text;
                String Country = textBox5.Text;
                String Genry = textBox6.Text;
                String Description = textBox9.Text;
                String rating = Convert.ToString(textBox7.Text);
                String time = textBox8.Text;
                string dateAdded = dateTimePicker1.Value.ToString("dd.MM.yyyy");
                string dateEdit = dateTimePicker2.Value.ToString("dd.MM.yyyy");

                string query = "INSERT INTO Movies (Film_name, Year_of_issue, Director, Description, Country, Genre, Rating, Duration, Date_added, Date_of_change) " +
                               "VALUES (@Name, @Year, @Author, @Description, @Country, @Genre, @Rating, @Duration, @DateAdded, @DateEdit)";

                using (OleDbCommand command = new OleDbCommand(query, myConnection))
                {
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Year", date);
                    command.Parameters.AddWithValue("@Author", Author);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@Country", Country);
                    command.Parameters.AddWithValue("@Genre", Genry);
                    command.Parameters.AddWithValue("@Rating", rating);
                    command.Parameters.AddWithValue("@Duration", time);
                    command.Parameters.AddWithValue("@DateAdded", dateAdded);
                    command.Parameters.AddWithValue("@DateEdit", dateEdit);

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Данные о фильме добавлены.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
            finally
            {
                this.Close();
            }
        }


        private void ShowImage(string imagePath)
        {
            Form imageForm = new Form
            {
                StartPosition = FormStartPosition.CenterScreen,
                Size = new Size(400, 400) // Размер окна
            };

            PictureBox pictureBox = new PictureBox
            {
                Image = new Bitmap(imagePath),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Dock = DockStyle.Fill // Заполнение формы
            };

            imageForm.Controls.Add(pictureBox);
            imageForm.ShowDialog(); // Модальное окно
        }


        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Введите название фильма.");
                return false;
            }

            if (!int.TryParse(textBox3.Text, out _))
            {
                MessageBox.Show("Введите корректное число.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Введите имя режиссера.");
                return false;
            }

            // Другие проверки для полей
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            pictureBox2.Image = null;
        }


        private void Add_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (myConnection != null && myConnection.State == ConnectionState.Open)
            {
                myConnection.Close();
                LogEvent("Соединение с базой данных закрыто.");
            }
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


        private void LoadMovieDetails(int movieId)
        {
            string query = "SELECT * FROM Movies WHERE Movie_id = @id";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.Parameters.AddWithValue("@id", movieId);
            OleDbDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                textBox2.Text = reader["Film_name"].ToString();
                textBox3.Text = reader["Year_of_issue"].ToString();
                textBox4.Text = reader["Director"].ToString();
                textBox5.Text = reader["Country"].ToString();
                textBox6.Text = reader["Genre"].ToString();
                textBox7.Text = reader["Rating"].ToString();
                textBox8.Text = reader["Duration"].ToString();
                textBox9.Text = reader["Description"].ToString();

                if (reader["Date_added"] != DBNull.Value)
                {
                    dateTimePicker1.Value = Convert.ToDateTime(reader["Date_added"]);
                }

                // Загрузка даты изменения (dateTimePicker2)
                if (reader["Date_of_change"] != DBNull.Value)
                {
                    dateTimePicker2.Value = Convert.ToDateTime(reader["Date_of_change"]);
                }

            }
            reader.Close();
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

            public override string ToString() => $"{Name} ({Year})"; // Используем имя и год для отображения
        }

        private void LogEvent(string message)
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }



        private bool CheckIfMovieExists(string name, int year)
        {
            string query = $"SELECT COUNT(*) FROM Movies WHERE Film_name = @name AND Year_of_issue = @year";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@year", year);

            try
            {
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
            catch (Exception ex)
            {
                LogError("Ошибка при проверке существования фильма: " + ex.Message);
                MessageBox.Show("Произошла ошибка при проверке фильма. Подробности сохранены в лог.");
                return true;  // Предполагаем, что фильм существует, если произошла ошибка
            }
        }

        private void LogError(string errorMessage)
        {
            string logFilePath = "error_log.txt";
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {errorMessage}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Выберите изображение";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Загружаем изображение в PictureBox
                    pictureBox2.Image = new Bitmap(openFileDialog.FileName);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                ComboBoxItem selectedMovie = (ComboBoxItem)comboBox1.SelectedItem;
                LoadMovieDetails(selectedMovie.Id);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            if (comboBox1.SelectedItem != null)
            {
                ComboBoxItem selectedMovie = (ComboBoxItem)comboBox1.SelectedItem;

                string name = textBox2.Text;
                int year = Convert.ToInt32(textBox3.Text);
                string director = textBox4.Text;
                string country = textBox5.Text;
                string genre = textBox6.Text;
                string rating = textBox7.Text;
                string duration = textBox8.Text;
                string description = textBox9.Text;
                string dateAdded = dateTimePicker1.Value.ToString("dd.MM.yyyy");
                string dateEdit = dateTimePicker2.Value.ToString("dd.MM.yyyy");

                string query = "UPDATE Movies SET Film_name = @Name, Year_of_issue = @Year, Director = @Director, " +
                               "Description = @Description, Country = @Country, Genre = @Genre, Rating = @Rating, " +
                               "Duration = @Duration, Date_added = @DateAdded, Date_of_change = @DateEdit " +
                               "WHERE Movie_id = @MovieId";

                using (OleDbCommand command = new OleDbCommand(query, myConnection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Year", year);
                    command.Parameters.AddWithValue("@Director", director);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@Country", country);
                    command.Parameters.AddWithValue("@Genre", genre);
                    command.Parameters.AddWithValue("@Rating", rating);
                    command.Parameters.AddWithValue("@Duration", duration);
                    command.Parameters.AddWithValue("@DateAdded", dateAdded);
                    command.Parameters.AddWithValue("@DateEdit", dateEdit);
                    command.Parameters.AddWithValue("@MovieId", selectedMovie.Id);

                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Данные о фильме успешно обновлены.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при обновлении данных: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите фильм для редактирования.");
            }
        }

    }
}
