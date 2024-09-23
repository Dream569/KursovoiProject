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
    /// Логика взаимодействия для Добавить2.xaml
    /// </summary>
    public partial class Добавить2 : Window
    {
        public Добавить2()
        {
            InitializeComponent();
        }
        МагазинИгрушекContext _db = new МагазинИгрушекContext();
        Поставщик _Postav;

        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (Tupetov.Text.Length == 0) errors.AppendLine("Введите тип товара");
            if (Postav.Text.Length == 0) errors.AppendLine("Введите поставщика");
            if (Adres.Text.Length == 0) errors.AppendLine("Введите адрес");
            if (tel.Text.Length == 0) errors.AppendLine("Введите телефон");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            try
            {
                if (Data.Post == null)
                {
                    _db.Поставщикs.Add(_Postav);
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
            if (Data.Post == null)
            {
                WindowAddEdit.Title = "Добавление записи";
                btnAddEdit.Content = "Добавить поставщика";
                _Postav = new Поставщик();
            }
            else
            {
                WindowAddEdit.Title = "Изменение записи";
                btnAddEdit.Content = "Изменить поставщика";
                _Postav = _db.Поставщикs.Find(Data.Post.Код);
            }
            WindowAddEdit.DataContext = _Postav;
        }
    }
}
