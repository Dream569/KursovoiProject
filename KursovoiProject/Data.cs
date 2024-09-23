using KursovoiProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursovoiProject
{
    public static class Data
    {
        public static Товары? Tov;
        public static Поставщик? Post;
        public static Продажи? Prod;
        public static Склад? Sklad;
        public static КоличествоТоваров? Koltov;
        public static bool login = false;
        public static string UserSurname;
        public static string UserName;
        public static string UserPatrononymic;
        public static string Right;
    }
}
