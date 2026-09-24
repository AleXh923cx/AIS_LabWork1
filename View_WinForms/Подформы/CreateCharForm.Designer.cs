namespace View_WinForms.Подформы
{
    partial class CreateCharForm
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
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            textBox_charAge = new TextBox();
            textBox_charGenus = new TextBox();
            textBox_charName = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label5.Location = new Point(10, 73);
            label5.Name = "label5";
            label5.Size = new Size(64, 20);
            label5.TabIndex = 18;
            label5.Text = "Возраст";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label4.Location = new Point(38, 44);
            label4.Name = "label4";
            label4.Size = new Size(36, 20);
            label4.TabIndex = 17;
            label4.Text = "Вид";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label3.Location = new Point(34, 15);
            label3.Name = "label3";
            label3.Size = new Size(40, 20);
            label3.TabIndex = 16;
            label3.Text = "Имя";
            // 
            // textBox_charAge
            // 
            textBox_charAge.BorderStyle = BorderStyle.FixedSingle;
            textBox_charAge.Location = new Point(80, 70);
            textBox_charAge.Name = "textBox_charAge";
            textBox_charAge.Size = new Size(140, 23);
            textBox_charAge.TabIndex = 15;
            // 
            // textBox_charGenus
            // 
            textBox_charGenus.BorderStyle = BorderStyle.FixedSingle;
            textBox_charGenus.Location = new Point(80, 41);
            textBox_charGenus.Name = "textBox_charGenus";
            textBox_charGenus.Size = new Size(140, 23);
            textBox_charGenus.TabIndex = 14;
            // 
            // textBox_charName
            // 
            textBox_charName.BorderStyle = BorderStyle.FixedSingle;
            textBox_charName.Location = new Point(80, 12);
            textBox_charName.Name = "textBox_charName";
            textBox_charName.Size = new Size(140, 23);
            textBox_charName.TabIndex = 13;
            // 
            // button1
            // 
            button1.Location = new Point(197, 99);
            button1.Name = "button1";
            button1.Size = new Size(74, 23);
            button1.TabIndex = 19;
            button1.Text = "Создать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_OnClick;
            // 
            // CreateCharForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(283, 131);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox_charAge);
            Controls.Add(textBox_charGenus);
            Controls.Add(textBox_charName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "CreateCharForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Создание персонажа";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox textBox_charAge;
        private TextBox textBox_charGenus;
        private TextBox textBox_charName;
        private Button button1;
    }
}