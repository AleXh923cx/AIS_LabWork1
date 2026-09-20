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
            textBox_charName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBox_charAge = new TextBox();
            button_nxt = new Button();
            button_prvs = new Button();
            SuspendLayout();
            // 
            // textBox_charName
            // 
            textBox_charName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox_charName.Location = new Point(86, 30);
            textBox_charName.Name = "textBox_charName";
            textBox_charName.ReadOnly = true;
            textBox_charName.Size = new Size(232, 29);
            textBox_charName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(37, 33);
            label1.Name = "label1";
            label1.Size = new Size(43, 21);
            label1.TabIndex = 1;
            label1.Text = "Имя";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(10, 68);
            label2.Name = "label2";
            label2.Size = new Size(70, 21);
            label2.TabIndex = 3;
            label2.Text = "Возраст";
            // 
            // textBox_charAge
            // 
            textBox_charAge.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox_charAge.Location = new Point(86, 65);
            textBox_charAge.Name = "textBox_charAge";
            textBox_charAge.ReadOnly = true;
            textBox_charAge.Size = new Size(232, 29);
            textBox_charAge.TabIndex = 2;
            // 
            // button_nxt
            // 
            button_nxt.Location = new Point(183, 135);
            button_nxt.Name = "button_nxt";
            button_nxt.Size = new Size(100, 30);
            button_nxt.TabIndex = 4;
            button_nxt.Text = "Следующий";
            button_nxt.UseVisualStyleBackColor = true;
            // 
            // button_prvs
            // 
            button_prvs.Location = new Point(58, 135);
            button_prvs.Name = "button_prvs";
            button_prvs.Size = new Size(100, 30);
            button_prvs.TabIndex = 5;
            button_prvs.Text = "Предыдущий";
            button_prvs.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 201);
            Controls.Add(button_prvs);
            Controls.Add(button_nxt);
            Controls.Add(label2);
            Controls.Add(textBox_charAge);
            Controls.Add(label1);
            Controls.Add(textBox_charName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "АИС \"РПГ персонажи-деревьи\"";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_charName;
        private Label label1;
        private Label label2;
        private TextBox textBox_charAge;
        private Button button_nxt;
        private Button button_prvs;
    }
}