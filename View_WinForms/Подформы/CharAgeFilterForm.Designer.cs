namespace View_WinForms.Подформы
{
    partial class CharAgeFilterForm
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
            characterBindingSource = new BindingSource(components);
            textBox_charMinAge = new TextBox();
            button_filter = new Button();
            button_reset = new Button();
            ((System.ComponentModel.ISupportInitialize)characterBindingSource).BeginInit();
            SuspendLayout();
            // 
            // characterBindingSource
            // 
            characterBindingSource.DataSource = typeof(Model.Character);
            // 
            // textBox_charMinAge
            // 
            textBox_charMinAge.Location = new Point(12, 12);
            textBox_charMinAge.Name = "textBox_charMinAge";
            textBox_charMinAge.PlaceholderText = "Введите минимальный возраст";
            textBox_charMinAge.Size = new Size(203, 23);
            textBox_charMinAge.TabIndex = 1;
            // 
            // button_filter
            // 
            button_filter.Location = new Point(292, 7);
            button_filter.Name = "button_filter";
            button_filter.Size = new Size(97, 31);
            button_filter.TabIndex = 2;
            button_filter.Text = "Фильтровать";
            button_filter.UseVisualStyleBackColor = true;
            button_filter.Click += button_filter_OnClick;
            // 
            // button_reset
            // 
            button_reset.Location = new Point(221, 7);
            button_reset.Name = "button_reset";
            button_reset.Size = new Size(65, 31);
            button_reset.TabIndex = 3;
            button_reset.Text = "Сброс";
            button_reset.UseVisualStyleBackColor = true;
            button_reset.Click += button_reset_OnClick;
            // 
            // CharAgeFilterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(401, 46);
            Controls.Add(button_reset);
            Controls.Add(button_filter);
            Controls.Add(textBox_charMinAge);
            MaximizeBox = false;
            Name = "CharAgeFilterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Выборка по минимальному возрасту";
            ((System.ComponentModel.ISupportInitialize)characterBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private BindingSource characterBindingSource;
        private TextBox textBox_charMinAge;
        private Button button_filter;
        private Button button_reset;
    }
}