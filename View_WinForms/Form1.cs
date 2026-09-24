using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using View_WinForms.Подформы;

namespace View_WinForms
{
    public partial class Form1 : Form
    {
        Logic logic = new Logic();

        public bool IsSortByGenus;
        public int? MinAge;

        public Form1()
        {
            InitializeComponent();
        }
        
        // Для подформы Form1 (DeleteForm)
        public Logic GetLogicInstance()
        {
            return logic;
        }

        public void RefreshForm()
        {
            var list = logic.GetProcessedCharacters(IsSortByGenus, MinAge);
            ShowCharacaterList(list);

            label_minAgeIndicator.Text = MinAge.HasValue ? 
                $"Минимальный возраст: {(MinAge.Value)}" : 
                $"Минимальный возраст: не задан";
        }

        public void ShowCharacaterList(List<Character> chars)
        {
            characterBindingSource.DataSource = chars;
            characterBindingSource.ResetBindings(false);
        }

        private void Form1_OnLoad(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void button_create_OnClick(object sender, EventArgs e)
        {
            new CreateCharForm(this).ShowDialog();
        }

        private void button_delete_OnClick(object sender, EventArgs e) 
        {
            new DeleteCharForm(this).ShowDialog();
        }

        private void button_update_OnClick(object sender, EventArgs e)
        {
            new UpdateCharForm(this).ShowDialog();
        }

        // Сортировка по виду
        private void checkbox1_Checked(object sender, EventArgs e)
        {
            IsSortByGenus = checkBox1.Checked;
            RefreshForm();
        }

        private void button_agefilter_OnClick(object sender, EventArgs e)
        {
            new CharAgeFilterForm(this).ShowDialog();
        }
    }
}
