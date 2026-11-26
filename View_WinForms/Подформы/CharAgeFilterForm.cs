using Model;
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
            if (!Validation.TryParseAge(textBox_charMinAge.Text, out int minAge, out string error))
            {
                MessageBox.Show(error, "Ошибка выборки",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _form1.RaiseFilterRequest(minAge);
            Close();
        }

        private void button_reset_OnClick(object sender, EventArgs e)
        {
            textBox_charMinAge.Clear();
            _form1.RaiseFilterRequest(null);
            Close();
        }
    }
}
