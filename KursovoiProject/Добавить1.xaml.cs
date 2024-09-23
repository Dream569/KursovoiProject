using KursovoiProject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;

namespace KursovoiProject
{
    /// <summary>
    /// Логика взаимодействия для Добавить1.xaml
    /// </summary>
    public partial class Добавить1 : Window
    {
        public Добавить1()
        {
            InitializeComponent();
            _db.Товарыs.Load();
        }
        МагазинИгрушекContext _db = new МагазинИгрушекContext();
        Товары _тов;
        OpenFileDialog open = new OpenFileDialog();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Data.Tov == null)
            {
                WindowAddEdit.Title = "Добавление записи";
                AddEdit.Content = "Добавить";
                _тов = new Товары();
            }
            else
            {
                WindowAddEdit.Title = "Изменение записи";
                AddEdit.Content = "Изменить";
                _тов = _db.Товарыs.Find(Data.Tov.Номер);
            }
            WindowAddEdit.DataContext = _тов;
        }
        private void btnAdd(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (Naztov.Text.Length == 0) errors.AppendLine("Введите Название");
            if (Opistov.Text.Length == 0) errors.AppendLine("Введите описание");
            if (Cena.Text.Length == 0) errors.AppendLine("Введите цену");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            try
            {
                if (open.SafeFileName.Length != 0)
                {
                    string newNamePhoto = Directory.GetCurrentDirectory() + "\\image\\" + open.SafeFileName;
                    File.Copy(open.FileName, newNamePhoto, true);
                    _тов.Photo = open.SafeFileName.ToString();
                }
            }
            catch { }
            try
            {
                if (Data.Tov == null)
                {
                    _db.Товарыs.Add(_тов);
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
        private void AddPhoto(object sender, RoutedEventArgs e)
        {
            open.Filter = "Все файлы |*.*| Файлы *.jpg|*.jpg";
            open.FilterIndex = 2;
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                BitmapImage photoImage = new BitmapImage(new Uri(open.FileName));
                Photo.Source = photoImage;
            }
        }
        private void Clear(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
