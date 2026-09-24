using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace View_WinForms.Подформы
{
    public partial class CharAgeFilterForm : Form
    {
        Form1 _form1;

        public CharAgeFilterForm(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
        }

        private void button_filter_OnClick(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox_charMinAge.Text, out int minAge))
            {
                MessageBox.Show("Минимальный возраст не должен быть пустой и должен быть числом", "Ошибка выборки", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _form1.MinAge = minAge;
            _form1.RefreshForm();
        }

        private void button_reset_OnClick(object sender, EventArgs e)
        {
            _form1.MinAge = null;
            textBox_charMinAge.Clear();
            _form1.RefreshForm();
        }
    }
}
