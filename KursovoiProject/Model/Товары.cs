using System;
using System.Collections.Generic;

namespace KursovoiProject.Model;

public partial class Товары
{
    public int Номер { get; set; }

    public string НазваниеТовара { get; set; } = null!;

    public string ОписаниеТовара { get; set; } = null!;

    public decimal Цена { get; set; }

    public string? Photo { get; set; }

    public virtual ICollection<КоличествоТоваров> КоличествоТоваровs { get; set; } = new List<КоличествоТоваров>();

    public virtual ICollection<Продажи> Продажиs { get; set; } = new List<Продажи>();

    public virtual ICollection<Склад> Складs { get; set; } = new List<Склад>();
}
