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
    /// Логика взаимодействия для Добавить3.xaml
    /// </summary>
    public partial class Добавить3 : Window
    {
        public Добавить3()
        {
            InitializeComponent();
        }
        МагазинИгрушекContext _db = new МагазинИгрушекContext();
        КоличествоТоваров _Nal;
        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (Nom.Text.Length == 0) errors.AppendLine("Введите номер");
            if (Kod.Text.Length == 0) errors.AppendLine("Введите код");
            if (Kol.Text.Length == 0) errors.AppendLine("Введите количество");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            try
            {
                if (Data.Koltov == null)
                {
                    _db.КоличествоТоваровs.Add(_Nal);
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
#if DEBUG
                throw;
#endif
            }
        }
        private void Cansel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_Loaded3(object sender, RoutedEventArgs e)
        {
            Nom.ItemsSource = _db.КоличествоТоваровs.ToList();
            Nom.DisplayMemberPath = "НомерТовара";
            Kod.ItemsSource = _db.КоличествоТоваровs.ToList();
            Kod.DisplayMemberPath = "КодПоставщика";
            if (Data.Koltov == null)
            {
                WindowAddEdit.Title = "Добавление записи";
                btnAddEdit.Content = "Добавить поставщика";
                _Nal = new КоличествоТоваров();
            }
            else
            {
                WindowAddEdit.Title = "Изменение записи";
                btnAddEdit.Content = "Изменить поставщика";
                _Nal = _db.КоличествоТоваровs.Find(Data.Koltov.КодПоставщика, Data.Koltov.НомерТовара);
            }
            WindowAddEdit.DataContext = _Nal;
        }
    }
}
