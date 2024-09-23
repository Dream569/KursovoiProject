using System;
using System.Collections.Generic;

namespace KursovoiProject.Model;

public partial class КоличествоТоваров
{
    public int НомерТовара { get; set; }

    public int КодПоставщика { get; set; }

    public int? Количество { get; set; }

    public virtual Поставщик КодПоставщикаNavigation { get; set; } = null!;

    public virtual Товары НомерТовараNavigation { get; set; } = null!;
}
