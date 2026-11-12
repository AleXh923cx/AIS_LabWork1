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

        private readonly ICharacterQuery characterQueryService = ninjectKernel.Get<ICharacterQuery>();
        private readonly ICharacterWrite characterWriter = ninjectKernel.Get<ICharacterWrite>();
        private readonly ICharacterRead characterReader = ninjectKernel.Get<ICharacterRead>();

        public bool IsSortByGenus;
        public int? MinAge;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Маппинг пользовательского выбора в ключ сортировки (OCP-safe граница UI→BL)
        /// </summary>
        private Func<Character, object> GetSortKey()
            => IsSortByGenus ? (c => c.Genus) : (c => c.Id);

        /// <summary>
        /// Обновляет форму для сихронизации
        /// </summary>
        public void RefreshForm()
        {
            IEnumerable<Character> chars = characterQueryService
                .GetProcessedCharacters(GetSortKey(), MinAge);

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
            new CreateCharForm(this, characterWriter).ShowDialog();
        }

        private void button_delete_OnClick(object sender, EventArgs e) 
        {
            new DeleteCharForm(this, characterWriter).ShowDialog();
        }

        private void button_update_OnClick(object sender, EventArgs e)
        {
            new UpdateCharForm(this, characterReader, characterWriter).ShowDialog();
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
