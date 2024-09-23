using KursovoiProject.Model;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KursovoiProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        void LoadDBIListView()
        {
            using (МагазинИгрушекContext _db = new МагазинИгрушекContext())
            {
                int selectedIndex = List1.SelectedIndex;
                List1.ItemsSource = _db.Товарыs.ToList();
                if (selectedIndex != -1)
                {
                    if (selectedIndex == List1.Items.Count) selectedIndex--;
                    List1.SelectedIndex = selectedIndex;
                    List1.ScrollIntoView(List1.SelectedItem);
                }
                List1.Focus();
            }
            using (МагазинИгрушекContext _db = new МагазинИгрушекContext())
            {
                int selectedIndex = DataGrid2.SelectedIndex;
                DataGrid2.ItemsSource = _db.Поставщикs.ToList();
                if (selectedIndex != -1)
                {
                    if (selectedIndex == DataGrid2.Items.Count) selectedIndex--;
                    DataGrid2.SelectedIndex = selectedIndex;
                    DataGrid2.ScrollIntoView(DataGrid2.SelectedItem);
                }
                DataGrid2.Focus();
            }
            using (МагазинИгрушекContext _db = new МагазинИгрушекContext())
            {
                int selectedIndex = DataGrid4.SelectedIndex;
                DataGrid4.ItemsSource = _db.КоличествоТоваровs.ToList();
                if (selectedIndex != -1)
                {
                    if (selectedIndex == DataGrid4.Items.Count) selectedIndex--;
                    DataGrid4.SelectedIndex = selectedIndex;
                    DataGrid4.ScrollIntoView(DataGrid4.SelectedItem);
                }
                DataGrid4.Focus();
            }
            using (МагазинИгрушекContext _db = new МагазинИгрушекContext())
            {
                int selectedIndex = DataGrid3.SelectedIndex;
                DataGrid3.ItemsSource = _db.Складs.ToList();
                if (selectedIndex != -1)
                {
                    if (selectedIndex == DataGrid3.Items.Count) selectedIndex--;
                    DataGrid3.SelectedIndex = selectedIndex;
                    DataGrid3.ScrollIntoView(DataGrid3.SelectedItem);
                }
                DataGrid3.Focus();
            }
            using (МагазинИгрушекContext _db = new МагазинИгрушекContext())
            {
                int selectedIndex = DataGrid5.SelectedIndex;
                DataGrid5.ItemsSource = _db.Продажиs.ToList();
                if (selectedIndex != -1)
                {
                    if (selectedIndex == DataGrid5.Items.Count) selectedIndex--;
                    DataGrid5.SelectedIndex = selectedIndex;
                    DataGrid5.ScrollIntoView(DataGrid5.SelectedItem);
                }
                DataGrid3.Focus();
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDBIListView();
        }
        private void Window_Initialized(object sender, EventArgs e)
        {
            Авторизация f = new Авторизация();
            f.ShowDialog();
            if (Data.login == false) Close();
            if (Data.Right == "Admin")
            {

            }
            else
            {
                btnEdit.IsEnabled = false;
                btnAdd.IsEnabled = false;
                btnDelete.IsEnabled = false;
                btnEdit1.IsEnabled = false;
                btnAdd1.IsEnabled = false;
                btnDelete1.IsEnabled = false;
                btnAdd2.IsEnabled = false;
                btnDelete2.IsEnabled = false;
                btnAdd5.IsEnabled = false;
                btnDelete5.IsEnabled = false;
                btnEdit3.IsEnabled = false;
                btnAdd3.IsEnabled = false;
                btnDelete3.IsEnabled = false;
                T1.Opacity = 0.0;
                T2.Opacity = 0.0;
                T3.Opacity = 0.0;
                T4.Opacity = 0.0;
            }
            Title = Title + " " + Data.UserSurname + " " + Data.UserName + " (" + Data.Right + ")";
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Data.Tov = null;
            Добавить1 f = new Добавить1();
            f.Owner = this;
            f.ShowDialog();
            LoadDBIListView();
        }
        private void Redact_Click(object sender, RoutedEventArgs e)
        {
            if (List1.SelectedItem != null)
            {
                Data.Tov = (Товары)List1.SelectedItem;
                Добавить1 f = new Добавить1();
                f.Owner = this;
                f.ShowDialog();
                LoadDBIListView();
            }
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Товары row = (Товары)List1.SelectedItem;
                    if (row != null)
                    {
                        using (МагазинИгрушекContext _db = new МагазинИгрушекContext())
                        {
                            _db.Товарыs.Remove(row);
                            _db.SaveChanges();
                        }
                        LoadDBIListView();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка удаления");
                }
            }
            else List1.Focus();
        }
        private void Add_Click1(object sender, RoutedEventArgs e)
        {
            Data.Post = null;
            Добавить2 f = new Добавить2();
            f.Owner = this;
            f.ShowDialog();
            LoadDBIListView();
        }
        private void Redact_Click1(object sender, RoutedEventArgs e)
        {
            if (DataGrid2.SelectedItem != null)
            {
                Data.Post = (Поставщик)DataGrid2.SelectedItem;
                Добавить2 f = new Добавить2();
                f.Owner = this;
                f.ShowDialog();
                LoadDBIListView();
            }
        }
        private void Clear_Click1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Поставщик row = (Поставщик)DataGrid2.SelectedItem;
                    if (row != null)
                    {
                        using (МагазинИгрушекContext _db = new МагазинИгрушекContext())
                        {
                            _db.Поставщикs.Remove(row);
                            _db.SaveChanges();
                        }
                        LoadDBIListView();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка удаления");
                }
            }
            else DataGrid2.Focus();
        }
        private void Add_Click3(object sender, RoutedEventArgs e)
        {
            Data.Koltov = null;
            Добавить3 f = new Добавить3();
            f.Owner = this;
            f.ShowDialog();
            LoadDBIListView();
        }
        private void Clear_Click3(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    КоличествоТоваров tow = (КоличествоТоваров)DataGrid4.SelectedItem;
                    if (tow != null)
                    {
                        using (МагазинИгрушекContext _db = new МагазинИгрушекContext())
                        {
                            _db.КоличествоТоваровs.Remove(tow);
                            _db.SaveChanges();
                        }
                        LoadDBIListView();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка удаления");
                }
            }
            else DataGrid4.Focus();
        }
        private void Add_Click5(object sender, RoutedEventArgs e)
        {
            Data.Prod = null;
            Добавить4 f = new Добавить4();
            f.Owner = this;
            f.ShowDialog();
            LoadDBIListView();
        }
        private void Clear_Click5(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Продажи tow1 = (Продажи)DataGrid5.SelectedItem;
                    if (tow1 != null)
                    {
                        using (МагазинИгрушекContext _db = new МагазинИгрушекContext())
                        {
                            _db.Продажиs.Remove(tow1);
                            _db.SaveChanges();
                        }
                        LoadDBIListView();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка удаления");
                }
            }
            else DataGrid5.Focus();
        }
        private void Add_Click4(object sender, RoutedEventArgs e)
        {
            Data.Sklad = null;
            Добавить5 f = new Добавить5();
            f.Owner = this;
            f.ShowDialog();
            LoadDBIListView();
        }
        private void Redact_Click4(object sender, RoutedEventArgs e)
        {
            if (DataGrid3.SelectedItem != null)
            {
                Data.Sklad = (Склад)DataGrid3.SelectedItem;
                Добавить5 f = new Добавить5();
                f.Owner = this;
                f.ShowDialog();
                LoadDBIListView();
            }
        }
        private void Clear_Click4(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Склад row = (Склад)DataGrid3.SelectedItem;
                    if (row != null)
                    {
                        using (МагазинИгрушекContext _db = new МагазинИгрушекContext())
                        {
                            _db.Складs.Remove(row);
                            _db.SaveChanges();
                        }
                        LoadDBIListView();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка удаления");
                }
            }
            else DataGrid3.Focus();
        }
        private void Poisk_Click(object sender, RoutedEventArgs e)
        {
            List<Товары> listItem = (List<Товары>)List1.ItemsSource;
            var filtered = listItem.Where(p => p.НазваниеТовара.Contains(Poisk.Text)
            || (!string.IsNullOrEmpty(p.ОписаниеТовара) ? p.ОписаниеТовара.Contains(Poisk.Text) : false)
            );
            if (filtered.Count() > 0)
            {
                var item = filtered.First();
                List1.SelectedItem = item;
                List1.ScrollIntoView(item);
                List1.Focus();
            }
        }
        private void Filtr_Click(object sender, RoutedEventArgs e)
        {
            if (Filtr.Text.IsNullOrEmpty() == false)
            {
                using (МагазинИгрушекContext _db = new МагазинИгрушекContext())
                {
                    var filtered = _db.Товарыs.Where(p => p.НазваниеТовара.Contains(Filtr.Text)
                    || (!string.IsNullOrEmpty(p.ОписаниеТовара) ? p.ОписаниеТовара.Contains(Filtr.Text) : false)
                    );
                    List1.ItemsSource = filtered.ToList();
                }
            }
            else
            {
                LoadDBIListView();
            }
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Курсовой проект\n" +
         "Курсовой проект Магазин игрушек",
         "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}