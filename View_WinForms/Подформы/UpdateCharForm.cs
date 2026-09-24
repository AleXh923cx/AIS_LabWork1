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
            if (!int.TryParse(textBox_charId.Text, out int charId))
            {
                MessageBox.Show("№ персонажа не должен быть пустой и должен быть числом", "Ошибка изменения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_form1.GetLogicInstance().GetCharacterById(charId) == null)
            {
                MessageBox.Show("Введённый № персонажа не существует в таблице", "Ошибка изменения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string charName = textBox_charName.Text;
            if (charName == null || charName.Length == 0)
            {
                MessageBox.Show("Имя персонажа не должно быть пустым", "Ошибка изменения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string charCls = textBox_charGenus.Text;
            if (charCls == null || charCls.Length == 0)
            {
                MessageBox.Show("Вид персонажа не должно быть пустым", "Ошибка изменения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(textBox_charAge.Text, out int charAge))
            {
                MessageBox.Show("Возраст не должен быть пустой и должен быть числом", "Ошибка изменения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (charAge < 0)
            {
                MessageBox.Show("Возраст должен быть выше нуля", "Ошибка изменения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _form1.GetLogicInstance().UpdateCharacter(charId, charName, charCls, charAge);
            _form1.RefreshForm();
            Close();
        }
    }
}
