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
            characterBindingSource.DataSource = logic.GetAllCharacters();
            characterBindingSource.ResetBindings(false);
        }

        private void Form1_OnLoad(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void button_create_OnClick(object sender, EventArgs e)
        {
            CreateCharForm createForm = new CreateCharForm(this);
            createForm.ShowDialog();
        }

        private void button_delete_OnClick(object sender, EventArgs e) 
        {
            DeleteCharForm deleteForm = new DeleteCharForm(this);
            deleteForm.ShowDialog();
        }
    }
}
