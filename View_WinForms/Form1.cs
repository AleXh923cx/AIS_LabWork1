using BusinessLogic;
using Model;
using Ninject;
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
        static IKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());
        CharacterService characterService = ninjectKernel.Get<CharacterService>();

        public bool IsSortByGenus;
        public int? MinAge;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Для подформы главного окна - Form1
        /// </summary>
        /// <returns>Служба персонажа</returns>
        public ICharacterService GetCharacterService()
        {
            return characterService;
        }

        /// <summary>
        /// Обновляет форму для сихронизации
        /// </summary>
        public void RefreshForm()
        {
            IEnumerable<Character> chars = characterService.GetAllCharacters();

            if (MinAge.HasValue)
                chars = characterService.FilterByMinAge(chars, MinAge.Value);

            chars = characterService.Sort(chars, IsSortByGenus);

            ShowCharacaterList(chars.ToList());

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
