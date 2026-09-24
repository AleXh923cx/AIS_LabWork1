namespace View_WinForms
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            button_create = new Button();
            button_prvs = new Button();
            dataGridView1 = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            genusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ageDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            levelDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            characterBindingSource = new BindingSource(components);
            button1 = new Button();
            checkBox1 = new CheckBox();
            button_agefilter = new Button();
            label_minAgeIndicator = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)characterBindingSource).BeginInit();
            SuspendLayout();
            // 
            // button_create
            // 
            button_create.Location = new Point(155, 184);
            button_create.Name = "button_create";
            button_create.Size = new Size(137, 29);
            button_create.TabIndex = 4;
            button_create.Text = "Создать персонажа";
            button_create.UseVisualStyleBackColor = true;
            button_create.Click += button_create_OnClick;
            // 
            // button_prvs
            // 
            button_prvs.Location = new Point(12, 183);
            button_prvs.Name = "button_prvs";
            button_prvs.Size = new Size(137, 30);
            button_prvs.TabIndex = 5;
            button_prvs.Text = "Удалить персонажа";
            button_prvs.UseVisualStyleBackColor = true;
            button_prvs.Click += button_delete_OnClick;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, genusDataGridViewTextBoxColumn, ageDataGridViewTextBoxColumn, levelDataGridViewTextBoxColumn });
            dataGridView1.DataSource = characterBindingSource;
            dataGridView1.Location = new Point(12, 26);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(423, 150);
            dataGridView1.TabIndex = 6;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "№";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            idDataGridViewTextBoxColumn.Width = 40;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Имя";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // genusDataGridViewTextBoxColumn
            // 
            genusDataGridViewTextBoxColumn.DataPropertyName = "Genus";
            genusDataGridViewTextBoxColumn.HeaderText = "Вид";
            genusDataGridViewTextBoxColumn.Name = "genusDataGridViewTextBoxColumn";
            genusDataGridViewTextBoxColumn.ReadOnly = true;
            genusDataGridViewTextBoxColumn.Width = 80;
            // 
            // ageDataGridViewTextBoxColumn
            // 
            ageDataGridViewTextBoxColumn.DataPropertyName = "Age";
            ageDataGridViewTextBoxColumn.HeaderText = "Возраст";
            ageDataGridViewTextBoxColumn.Name = "ageDataGridViewTextBoxColumn";
            ageDataGridViewTextBoxColumn.ReadOnly = true;
            ageDataGridViewTextBoxColumn.Width = 70;
            // 
            // levelDataGridViewTextBoxColumn
            // 
            levelDataGridViewTextBoxColumn.DataPropertyName = "Level";
            levelDataGridViewTextBoxColumn.HeaderText = "Уровень";
            levelDataGridViewTextBoxColumn.Name = "levelDataGridViewTextBoxColumn";
            levelDataGridViewTextBoxColumn.ReadOnly = true;
            levelDataGridViewTextBoxColumn.Width = 60;
            // 
            // characterBindingSource
            // 
            characterBindingSource.DataSource = typeof(Model.Character);
            // 
            // button1
            // 
            button1.Location = new Point(298, 184);
            button1.Name = "button1";
            button1.Size = new Size(137, 29);
            button1.TabIndex = 13;
            button1.Text = "Изменить персонажа";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button_update_OnClick;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(12, 219);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(137, 19);
            checkBox1.TabIndex = 14;
            checkBox1.Text = "Сортировка по виду";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkbox1_Checked;
            // 
            // button_agefilter
            // 
            button_agefilter.Location = new Point(155, 219);
            button_agefilter.Name = "button_agefilter";
            button_agefilter.Size = new Size(280, 22);
            button_agefilter.TabIndex = 15;
            button_agefilter.Text = "Выборка по возрасту";
            button_agefilter.UseVisualStyleBackColor = true;
            button_agefilter.Click += button_agefilter_OnClick;
            // 
            // label_minAgeIndicator
            // 
            label_minAgeIndicator.AutoSize = true;
            label_minAgeIndicator.Location = new Point(12, 8);
            label_minAgeIndicator.Name = "label_minAgeIndicator";
            label_minAgeIndicator.Size = new Size(147, 15);
            label_minAgeIndicator.TabIndex = 16;
            label_minAgeIndicator.Text = "Минимальный возраст: 0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(443, 248);
            Controls.Add(label_minAgeIndicator);
            Controls.Add(button_agefilter);
            Controls.Add(checkBox1);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(button_prvs);
            Controls.Add(button_create);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "АИС \"РПГ персонажи-деревьи\"";
            Load += Form1_OnLoad;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)characterBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button_create;
        private Button button_prvs;
        private DataGridView dataGridView1;
        private BindingSource characterBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn genusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ageDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn levelDataGridViewTextBoxColumn;
        private Button button1;
        private CheckBox checkBox1;
        private Button button_agefilter;
        private Label label_minAgeIndicator;
    }
}