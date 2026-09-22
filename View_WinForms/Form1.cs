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

        private void Form1_OnLoad(object sender, EventArgs e)
        {
            characterBindingSource.DataSource = logic.GetAllCharacters();
        }

        private void button_create_OnClick(object sender, EventArgs e)
        {
            
        }
    }
}
