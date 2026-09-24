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
            
        }

        private void button_reset_OnClick(object sender, EventArgs e)
        {

        }
    }
}
