using BusinessLogic;
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
    public partial class CreateCharForm : Form
    {
        Form1 _form1;

        private readonly ICharacterWrite _writer;
        
        public CreateCharForm(Form1 form1, ICharacterWrite writer)
        {
            InitializeComponent();
            _form1 = form1;
            _writer = writer;
        }

        private void button1_OnClick(object sender, EventArgs e)
        {
            string charName = textBox_charName.Text;
            string charCls = textBox_charGenus.Text;

            if (!Validation.TryParseAge(textBox_charAge.Text, out int charAge, out string error))
            {
                MessageBox.Show(error, "Ошибка создания",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Validation.ValidateCharacter(charName, charCls, charAge, out error))
            {
                MessageBox.Show(error, "Ошибка создания",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _writer.AddCharacter(charName, charCls, charAge);
            _form1.RefreshForm();
            Close();
        }
    }
}
