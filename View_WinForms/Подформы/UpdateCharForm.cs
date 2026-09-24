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
    public partial class UpdateCharForm : Form
    {
        Form1 _form1;

        public UpdateCharForm(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
        }

        private void button1_OnClick(object sender, EventArgs e) 
        {
            if (!Validation.TryParseId(textBox_charId.Text, out int charId, out string error))
            {
                MessageBox.Show(error, "Ошибка изменения", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_form1.GetLogicInstance().GetCharacterById(charId) == null)
            {
                MessageBox.Show("Введённый № персонажа не существует в таблице", 
                    "Ошибка изменения", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string charName = textBox_charName.Text;
            string charCls = textBox_charGenus.Text;

            if (!Validation.TryParseAge(textBox_charAge.Text, out int charAge, out error))
            {
                MessageBox.Show(error, "Ошибка изменения",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Validation.ValidateCharacter(charName, charCls, charAge, out error))
            {
                MessageBox.Show(error, "Ошибка изменения",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _form1.GetLogicInstance().UpdateCharacter(charId, charName, charCls, charAge);
            _form1.RefreshForm();
            Close();
        }
    }
}
