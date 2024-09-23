using System;
using System.Collections.Generic;

namespace KursovoiProject.Model;

public partial class Продажи
{
    public int НомерЧека { get; set; }

    public int КодТовара { get; set; }

    public string КоличествоПродано { get; set; } = null!;

    public DateTime ДатаПродажи { get; set; }

    public virtual Товары КодТовараNavigation { get; set; } = null!;
}
