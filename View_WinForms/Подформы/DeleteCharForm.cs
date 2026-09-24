using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using View_WinForms;

namespace View_WinForms.Подформы
{
    public partial class DeleteCharForm : Form
    {
        Form1 _form1;

        public DeleteCharForm(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
        }

        private void button1_OnClick(object sender, EventArgs e) 
        {
            if (!Validation.TryParseId(textBox1.Text, out int charId, out string error)) 
            {
                MessageBox.Show(error, "Ошибка удаления",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_form1.GetLogicInstance().DeleteCharacter(charId))
            {
                MessageBox.Show("Персонаж с таким № не найден в таблице.",
                    "Ошибка удаления",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _form1.RefreshForm();
            Close();
        }
    }
}
