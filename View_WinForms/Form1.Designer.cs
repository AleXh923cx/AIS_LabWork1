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
            logicBindingSource = new BindingSource(components);
            textBox_сharName = new TextBox();
            textBox_charAge = new TextBox();
            textBox3 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)characterBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logicBindingSource).BeginInit();
            SuspendLayout();
            // 
            // button_create
            // 
            button_create.Location = new Point(552, 169);
            button_create.Name = "button_create";
            button_create.Size = new Size(140, 30);
            button_create.TabIndex = 4;
            button_create.Text = "Создать персонажа";
            button_create.UseVisualStyleBackColor = true;
            // 
            // button_prvs
            // 
            button_prvs.Location = new Point(12, 168);
            button_prvs.Name = "button_prvs";
            button_prvs.Size = new Size(140, 30);
            button_prvs.TabIndex = 5;
            button_prvs.Text = "Удалить персонажа";
            button_prvs.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, genusDataGridViewTextBoxColumn, ageDataGridViewTextBoxColumn, levelDataGridViewTextBoxColumn });
            dataGridView1.DataSource = characterBindingSource;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(440, 150);
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
            // logicBindingSource
            // 
            logicBindingSource.DataSource = typeof(Model.Logic);
            // 
            // textBox_сharName
            // 
            textBox_сharName.BorderStyle = BorderStyle.FixedSingle;
            textBox_сharName.Location = new Point(552, 33);
            textBox_сharName.Name = "textBox_сharName";
            textBox_сharName.Size = new Size(140, 23);
            textBox_сharName.TabIndex = 7;
            // 
            // textBox_charAge
            // 
            textBox_charAge.BorderStyle = BorderStyle.FixedSingle;
            textBox_charAge.Location = new Point(552, 62);
            textBox_charAge.Name = "textBox_charAge";
            textBox_charAge.Size = new Size(140, 23);
            textBox_charAge.TabIndex = 8;
            // 
            // textBox3
            // 
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Location = new Point(552, 91);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(140, 23);
            textBox3.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label3.Location = new Point(506, 36);
            label3.Name = "label3";
            label3.Size = new Size(40, 20);
            label3.TabIndex = 10;
            label3.Text = "Имя";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label4.Location = new Point(510, 65);
            label4.Name = "label4";
            label4.Size = new Size(36, 20);
            label4.TabIndex = 11;
            label4.Text = "Вид";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label5.Location = new Point(482, 94);
            label5.Name = "label5";
            label5.Size = new Size(64, 20);
            label5.TabIndex = 12;
            label5.Text = "Возраст";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(704, 211);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(textBox_charAge);
            Controls.Add(textBox_сharName);
            Controls.Add(dataGridView1);
            Controls.Add(button_prvs);
            Controls.Add(button_create);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "АИС \"РПГ персонажи-деревьи\"";
            Load += Form1_OnLoad;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)characterBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)logicBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_charName;
        private TextBox textBox_charAge;
        private Button button_create;
        private Button button_prvs;
        private DataGridView dataGridView1;
        private BindingSource logicBindingSource;
        private BindingSource characterBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn genusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ageDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn levelDataGridViewTextBoxColumn;
        private TextBox textBox_сharName;
        private TextBox textBox3;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}