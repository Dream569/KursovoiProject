using System;
using System.Collections.Generic;

namespace KursovoiProject.Model;

public partial class Склад
{
    public int НомерСклада { get; set; }

    public int КодТовара { get; set; }

    public string АдресСклада { get; set; } = null!;

    public int Телефон { get; set; }

    public string Фиодиректора { get; set; } = null!;

    public virtual Товары КодТовараNavigation { get; set; } = null!;
}
