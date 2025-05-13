using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class Uslugi
{
    public int КодУслуги { get; set; }

    public int? КодОбщихСведений { get; set; }

    public string? Фио { get; set; }

    public string? НаименованиеУслуги { get; set; }

    public DateOnly? ДатаОказанияУслуги { get; set; }

    public virtual ObshieSvedenya? КодОбщихСведенийNavigation { get; set; }
}
