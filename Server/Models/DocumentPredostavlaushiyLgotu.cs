using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class DocumentPredostavlaushiyLgotu
{
    public int КодДокументаПредоставляющегоЛьготу { get; set; }

    public string? Фио { get; set; }

    public string? ТипДокумента { get; set; }

    public string? Серия { get; set; }

    public string? Номер { get; set; }

    public DateOnly? ДатаВыдачи { get; set; }

    public DateOnly? ДатаОкончанияСрокаДействия { get; set; }

    public virtual ObshieSvedenya КодДокументаПредоставляющегоЛьготуNavigation { get; set; } = null!;
}
