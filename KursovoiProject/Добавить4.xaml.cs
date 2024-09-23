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
    /// Логика взаимодействия для Добавить4.xaml
    /// </summary>
    public partial class Добавить4 : Window
    {
        public Добавить4()
        {
            InitializeComponent();
        }
        МагазинИгрушекContext _db = new МагазинИгрушекContext();
        Продажи _Prod;

        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (Kodtov.Text.Length == 0) errors.AppendLine("Введите Код");
            if (Kol.Text.Length == 0) errors.AppendLine("Введите количество");
            if (Datapost.SelectedDate == null) errors.AppendLine("Введите дату");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            try
            {
                if (Data.Prod == null)
                {
                    _db.Продажиs.Add(_Prod);
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
        private void Window_Loaded3(object sender, RoutedEventArgs e)
        {
            Kodtov.ItemsSource = _db.Продажиs.ToList();
            Kodtov.DisplayMemberPath = "КодТовара";
            if (Data.Prod == null)
            {
                WindowAddEdit.Title = "Добавление записи";
                btnAddEdit.Content = "Добавить товар";
                _Prod = new Продажи();
            }
            else
            {
                WindowAddEdit.Title = "Изменение записи";
                btnAddEdit.Content = "Изменить товар";
                _Prod = _db.Продажиs.Find(Data.Prod.НомерЧека);
            }
            WindowAddEdit.DataContext = _Prod;
        }
    }
}
