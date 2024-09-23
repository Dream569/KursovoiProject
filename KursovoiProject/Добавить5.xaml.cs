using KursovoiProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KursovoiProject
{
    /// <summary>
    /// Логика взаимодействия для Добавить5.xaml
    /// </summary>
    public partial class Добавить5 : Window
    {
        public Добавить5()
        {
            InitializeComponent();
        }
        МагазинИгрушекContext _db = new МагазинИгрушекContext();
        Склад _Sklad;

        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (Kodtov.Text.Length == 0) errors.AppendLine("Введите Код");
            if (FIO.Text.Length == 0) errors.AppendLine("Введите ФИО");
            if (Adres.Text.Length == 0) errors.AppendLine("Введите адрес");
            if (tel.Text.Length == 0) errors.AppendLine("Введите телефон");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            try
            {
                if (Data.Sklad == null)
                {
                    _db.Складs.Add(_Sklad);
                    _db.SaveChanges();
                }
                else
                {
                    _db.SaveChanges();
                }
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void Cansel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_Loaded2(object sender, RoutedEventArgs e)
        {
            Kodtov.ItemsSource = _db.Складs.ToList();
            Kodtov.DisplayMemberPath = "КодТовара";
            if (Data.Sklad == null)
            {
                WindowAddEdit.Title = "Добавление записи";
                btnAddEdit.Content = "Добавить товар";
                _Sklad = new Склад();
            }
            else
            {
                WindowAddEdit.Title = "Изменение записи";
                btnAddEdit.Content = "Изменить товар";
                _Sklad = _db.Складs.Find(Data.Sklad.НомерСклада);
            }
            WindowAddEdit.DataContext = _Sklad;
        }
    }
}
