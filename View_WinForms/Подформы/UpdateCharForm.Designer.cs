namespace View_WinForms.Подформы
{
    partial class UpdateCharForm
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
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label5.Location = new Point(49, 102);
            label5.Name = "label5";
            label5.Size = new Size(64, 20);
            label5.TabIndex = 24;
            label5.Text = "Возраст";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label4.Location = new Point(77, 73);
            label4.Name = "label4";
            label4.Size = new Size(36, 20);
            label4.TabIndex = 23;
            label4.Text = "Вид";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label3.Location = new Point(73, 44);
            label3.Name = "label3";
            label3.Size = new Size(40, 20);
            label3.TabIndex = 22;
            label3.Text = "Имя";
            // 
            // textBox_charAge
            // 
            textBox_charAge.BorderStyle = BorderStyle.FixedSingle;
            textBox_charAge.Location = new Point(119, 99);
            textBox_charAge.Name = "textBox_charAge";
            textBox_charAge.Size = new Size(140, 23);
            textBox_charAge.TabIndex = 21;
            // 
            // textBox_charGenus
            // 
            textBox_charGenus.BorderStyle = BorderStyle.FixedSingle;
            textBox_charGenus.Location = new Point(119, 70);
            textBox_charGenus.Name = "textBox_charGenus";
            textBox_charGenus.Size = new Size(140, 23);
            textBox_charGenus.TabIndex = 20;
            // 
            // textBox_charName
            // 
            textBox_charName.BorderStyle = BorderStyle.FixedSingle;
            textBox_charName.Location = new Point(119, 41);
            textBox_charName.Name = "textBox_charName";
            textBox_charName.Size = new Size(140, 23);
            textBox_charName.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label1.Location = new Point(4, 15);
            label1.Name = "label1";
            label1.Size = new Size(109, 20);
            label1.TabIndex = 26;
            label1.Text = "№ персонажа";
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(119, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(140, 23);
            textBox1.TabIndex = 25;
            // 
            // button1
            // 
            button1.Location = new Point(167, 128);
            button1.Name = "button1";
            button1.Size = new Size(130, 27);
            button1.TabIndex = 27;
            button1.Text = "Изменить";
            button1.UseVisualStyleBackColor = true;
            // 
            // UpdateCharForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(309, 167);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox_charAge);
            Controls.Add(textBox_charGenus);
            Controls.Add(textBox_charName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "UpdateCharForm";
            Text = "Изменение персонажа";
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
        private Label label1;
        private TextBox textBox1;
        private Button button1;
    }
}