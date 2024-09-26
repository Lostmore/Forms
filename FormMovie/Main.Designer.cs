namespace FormMovie
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this._17__20DataSet = new FormMovie._17__20DataSet();
            this.dataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.browsingHistoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.browsing_historyTableAdapter = new FormMovie._17__20DataSetTableAdapters.Browsing_historyTableAdapter();
            this.moviesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.moviesTableAdapter = new FormMovie._17__20DataSetTableAdapters.MoviesTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.movieidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.filmnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yearofissueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.directorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ratingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.durationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateaddedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateofchangeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moviesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._17__20DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.browsingHistoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moviesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moviesBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // _17__20DataSet
            // 
            this._17__20DataSet.DataSetName = "_17__20DataSet";
            this._17__20DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSetBindingSource
            // 
            this.dataSetBindingSource.DataSource = this._17__20DataSet;
            this.dataSetBindingSource.Position = 0;
            // 
            // browsingHistoryBindingSource
            // 
            this.browsingHistoryBindingSource.DataMember = "Browsing history";
            this.browsingHistoryBindingSource.DataSource = this._17__20DataSet;
            // 
            // browsing_historyTableAdapter
            // 
            this.browsing_historyTableAdapter.ClearBeforeFill = true;
            // 
            // moviesBindingSource
            // 
            this.moviesBindingSource.DataMember = "Movies";
            this.moviesBindingSource.DataSource = this._17__20DataSet;
            // 
            // moviesTableAdapter
            // 
            this.moviesTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.ForeColor = System.Drawing.Color.GreenYellow;
            this.label1.Location = new System.Drawing.Point(12, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выбор фильма";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 138);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(113, 22);
            this.textBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(5, 176);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 41);
            this.button1.TabIndex = 3;
            this.button1.Text = "Удаление";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.ForeColor = System.Drawing.Color.GreenYellow;
            this.label2.Location = new System.Drawing.Point(152, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Изменение рейтинга";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(155, 138);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(67, 22);
            this.textBox2.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(183, 176);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 41);
            this.button2.TabIndex = 6;
            this.button2.Text = "Обновить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label3.ForeColor = System.Drawing.Color.GreenYellow;
            this.label3.Location = new System.Drawing.Point(155, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Код фильма";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(228, 138);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(67, 22);
            this.textBox3.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label4.ForeColor = System.Drawing.Color.GreenYellow;
            this.label4.Location = new System.Drawing.Point(237, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Рейтинг";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(672, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(116, 76);
            this.button3.TabIndex = 10;
            this.button3.Text = "Добавить новый фильм";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.movieidDataGridViewTextBoxColumn,
            this.filmnameDataGridViewTextBoxColumn,
            this.yearofissueDataGridViewTextBoxColumn,
            this.directorDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.countryDataGridViewTextBoxColumn,
            this.genreDataGridViewTextBoxColumn,
            this.ratingDataGridViewTextBoxColumn,
            this.durationDataGridViewTextBoxColumn,
            this.dateaddedDataGridViewTextBoxColumn,
            this.dateofchangeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.moviesBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(1, 244);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(799, 207);
            this.dataGridView1.TabIndex = 11;
            // 
            // movieidDataGridViewTextBoxColumn
            // 
            this.movieidDataGridViewTextBoxColumn.DataPropertyName = "Movie_id";
            this.movieidDataGridViewTextBoxColumn.HeaderText = "Movie_id";
            this.movieidDataGridViewTextBoxColumn.Name = "movieidDataGridViewTextBoxColumn";
            // 
            // filmnameDataGridViewTextBoxColumn
            // 
            this.filmnameDataGridViewTextBoxColumn.DataPropertyName = "Film_name";
            this.filmnameDataGridViewTextBoxColumn.HeaderText = "Film_name";
            this.filmnameDataGridViewTextBoxColumn.Name = "filmnameDataGridViewTextBoxColumn";
            // 
            // yearofissueDataGridViewTextBoxColumn
            // 
            this.yearofissueDataGridViewTextBoxColumn.DataPropertyName = "Year_of_issue";
            this.yearofissueDataGridViewTextBoxColumn.HeaderText = "Year_of_issue";
            this.yearofissueDataGridViewTextBoxColumn.Name = "yearofissueDataGridViewTextBoxColumn";
            // 
            // directorDataGridViewTextBoxColumn
            // 
            this.directorDataGridViewTextBoxColumn.DataPropertyName = "Director";
            this.directorDataGridViewTextBoxColumn.HeaderText = "Director";
            this.directorDataGridViewTextBoxColumn.Name = "directorDataGridViewTextBoxColumn";
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // countryDataGridViewTextBoxColumn
            // 
            this.countryDataGridViewTextBoxColumn.DataPropertyName = "Country";
            this.countryDataGridViewTextBoxColumn.HeaderText = "Country";
            this.countryDataGridViewTextBoxColumn.Name = "countryDataGridViewTextBoxColumn";
            // 
            // genreDataGridViewTextBoxColumn
            // 
            this.genreDataGridViewTextBoxColumn.DataPropertyName = "Genre";
            this.genreDataGridViewTextBoxColumn.HeaderText = "Genre";
            this.genreDataGridViewTextBoxColumn.Name = "genreDataGridViewTextBoxColumn";
            // 
            // ratingDataGridViewTextBoxColumn
            // 
            this.ratingDataGridViewTextBoxColumn.DataPropertyName = "Rating";
            this.ratingDataGridViewTextBoxColumn.HeaderText = "Rating";
            this.ratingDataGridViewTextBoxColumn.Name = "ratingDataGridViewTextBoxColumn";
            // 
            // durationDataGridViewTextBoxColumn
            // 
            this.durationDataGridViewTextBoxColumn.DataPropertyName = "Duration";
            this.durationDataGridViewTextBoxColumn.HeaderText = "Duration";
            this.durationDataGridViewTextBoxColumn.Name = "durationDataGridViewTextBoxColumn";
            // 
            // dateaddedDataGridViewTextBoxColumn
            // 
            this.dateaddedDataGridViewTextBoxColumn.DataPropertyName = "Date_added";
            this.dateaddedDataGridViewTextBoxColumn.HeaderText = "Date_added";
            this.dateaddedDataGridViewTextBoxColumn.Name = "dateaddedDataGridViewTextBoxColumn";
            // 
            // dateofchangeDataGridViewTextBoxColumn
            // 
            this.dateofchangeDataGridViewTextBoxColumn.DataPropertyName = "Date_of_change";
            this.dateofchangeDataGridViewTextBoxColumn.HeaderText = "Date_of_change";
            this.dateofchangeDataGridViewTextBoxColumn.Name = "dateofchangeDataGridViewTextBoxColumn";
            // 
            // moviesBindingSource1
            // 
            this.moviesBindingSource1.DataMember = "Movies";
            this.moviesBindingSource1.DataSource = this.dataSetBindingSource;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(662, 184);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(126, 41);
            this.button4.TabIndex = 12;
            this.button4.Text = "Обновить таблицу";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.textBox4.Location = new System.Drawing.Point(117, 41);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(385, 32);
            this.textBox4.TabIndex = 13;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(508, 41);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(116, 32);
            this.button5.TabIndex = 14;
            this.button5.Text = "Поиск";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 20F);
            this.label5.ForeColor = System.Drawing.Color.YellowGreen;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(278, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(198, 31);
            this.label5.TabIndex = 15;
            this.label5.Text = "FilmExplorerPro";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(323, 138);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(153, 22);
            this.textBox5.TabIndex = 16;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(350, 176);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(107, 41);
            this.button6.TabIndex = 17;
            this.button6.Text = "Поиск";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.ForeColor = System.Drawing.Color.GreenYellow;
            this.label6.Location = new System.Drawing.Point(304, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(218, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Поиск по рейтингу/году фильма";
            this.label6.UseMnemonic = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label7.ForeColor = System.Drawing.Color.GreenYellow;
            this.label7.Location = new System.Drawing.Point(334, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Год фильма или рейтинг";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label8.ForeColor = System.Drawing.Color.GreenYellow;
            this.label8.Location = new System.Drawing.Point(32, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Код фильма";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(662, 138);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(126, 41);
            this.button7.TabIndex = 21;
            this.button7.Text = "3 лучших фильма";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(662, 94);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(126, 41);
            this.button8.TabIndex = 22;
            this.button8.Text = "Самый активный пользователь";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FilmExplorer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this._17__20DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.browsingHistoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moviesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moviesBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource dataSetBindingSource;
        private _17__20DataSet _17__20DataSet;
        private System.Windows.Forms.BindingSource browsingHistoryBindingSource;
        private _17__20DataSetTableAdapters.Browsing_historyTableAdapter browsing_historyTableAdapter;
        private System.Windows.Forms.BindingSource moviesBindingSource;
        private _17__20DataSetTableAdapters.MoviesTableAdapter moviesTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn movieidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn filmnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yearofissueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn directorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn genreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ratingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn durationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateaddedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateofchangeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource moviesBindingSource1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
    }
}

