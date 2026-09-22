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
            string charCls = textBox_charGenus.Text;

            if (int.TryParse(textBox_charAge.Text, out int charAge))
            {
                if (!logic.AddCharacter(charName, charCls, charAge))
                {
                    MessageBox.Show("Не удалось создать персонажа-дерево! (либо имя и вид пустая, либо возраст ниже 0)", "Ошибка создания", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                RefreshForm();
            }
            else
            {
                MessageBox.Show("Возраст должен быть числом", "Ошибка создания", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
