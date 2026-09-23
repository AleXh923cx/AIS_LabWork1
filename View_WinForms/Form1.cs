using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace View_WinForms
{
    public partial class Form1 : Form
    {
        Logic logic = new Logic();

        public Form1()
        {
            InitializeComponent();
        }

        private void RefreshForm()
        {
            characterBindingSource.DataSource = logic.GetAllCharacters();
            characterBindingSource.ResetBindings(false);
        }

        private void Form1_OnLoad(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void button_create_OnClick(object sender, EventArgs e)
        {
            string charName = textBox_charName.Text;
            if (charName == null || charName.Length == 0)
            {
                MessageBox.Show("Имя персонажа не должно быть пустым", "Ошибка создания", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string charCls = textBox_charGenus.Text;
            if (charCls == null || charCls.Length == 0)
            {
                MessageBox.Show("Вид персонажа не должно быть пустым", "Ошибка создания", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (int.TryParse(textBox_charAge.Text, out int charAge))
            {
                if (charAge < 0)
                {
                    MessageBox.Show("Возраст должен быть выше нуля", "Ошибка создания", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                logic.AddCharacter(charName, charCls, charAge);
                RefreshForm();
            }
            else
            {
                MessageBox.Show("Возраст должен быть числом", "Ошибка создания", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
