using System;
using System.Collections.Generic;

namespace KursovoiProject.Model;

public partial class Поставщик
{
    public int Код { get; set; }

    public string ИмяПоставщика { get; set; } = null!;

    public string ТипТовара { get; set; } = null!;

    public string Адрес { get; set; } = null!;

    public int Телефон { get; set; }

    public virtual ICollection<КоличествоТоваров> КоличествоТоваровs { get; set; } = new List<КоличествоТоваров>();
}
