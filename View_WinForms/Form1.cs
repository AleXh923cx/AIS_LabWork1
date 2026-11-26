using Shared;
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
    public partial class Form1 : Form, IView
    {
        public int? MinAge;
        // Последний результат операции; подформы читают его после Raise...Request.
        private OperationResult? _lastOperationResult;
        /// <summary>
        /// Результат последней операции (только для чтения из подформ).
        /// </summary>
        public OperationResult? LastOperationResult => _lastOperationResult;

        public event EventHandler<CharacterDto>? RequestAdd;
        public event EventHandler<CharacterDto>? RequestUpdate;
        public event EventHandler<int>? RequestDelete;
        public event EventHandler<int?>? RequestFilter;
        public event EventHandler<SortOption>? RequestSort;

        public Form1()
        {
            InitializeComponent();
        }

        public void ShowList(List<CharacterDto> characters)
        {
            characterBindingSource.DataSource = characters;
            characterBindingSource.ResetBindings(false);
        }
        
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void ShowOperationResult(OperationResult result)
        {
            _lastOperationResult = result;
            
            if (!result.IsSuccess) return;

            // Показываем текст результата
            MessageBox.Show(result.Message, "Готово");
        }

        public void Run()
        {
            this.ShowDialog();
        }

        /// <summary>
        /// Вызов сообщении об добавлении
        /// </summary>
        public void RaiseAddRequest(CharacterDto character)
        {
            _lastOperationResult = null;
            RequestAdd?.Invoke(this, character);
        }
        /// <summary>
        /// Вызов сообщении об удалении
        /// </summary>
        public void RaiseDeleteRequest(int id)
        {
            _lastOperationResult = null;
            RequestDelete?.Invoke(this, id);
        }
        /// <summary>
        /// Вызов сообщении об изменении
        /// </summary>
        public void RaiseUpdateRequest(CharacterDto character)
        {
            _lastOperationResult = null;
            RequestUpdate?.Invoke(this, character);
        }

        /// <summary>
        /// Вызов сообщении об фильтрации по минимальному возраста
        /// </summary>
        /// <param name="minAge">Минимальный возраст</param>
        public void RaiseFilterRequest(int? minAge)
        {
            MinAge = minAge;
            label_minAgeIndicator.Text = MinAge.HasValue ?
                $"Минимальный возраст: {(MinAge.Value)}" :
                $"Минимальный возраст: не задан";

            RequestFilter?.Invoke(this, MinAge);
        }

        private void Form1_OnLoad(object sender, EventArgs e)
        {
            
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
            SortOption sortOption = checkBox1.Checked
                ? SortOption.ByGenus
                : SortOption.ById;

            RequestSort?.Invoke(this, sortOption);
        }

        private void button_agefilter_OnClick(object sender, EventArgs e)
        {
            new CharAgeFilterForm(this).ShowDialog();
        }
    }
}
