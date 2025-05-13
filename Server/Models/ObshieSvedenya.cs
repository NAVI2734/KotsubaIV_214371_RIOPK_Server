using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class ObshieSvedenya
{
    public int КодОбщихСведений { get; set; }

    public string? Фио { get; set; }

    public DateOnly? ДатаРождения { get; set; }

    public string? Пол { get; set; }

    public string? АдресРегистрации { get; set; }

    public string? АдресПроживания { get; set; }

    public string? Телефон { get; set; }

    public virtual DocumentPredostavlaushiyLgotu? ДокументПредоставляющийЛьготу { get; set; }

    public virtual DokumentUdostoveraushiyLichnost? ДокументУдостоверяющийЛичность { get; set; }

    public virtual SocialnoePolojenie? СоциальноеПоложение { get; set; }

    public virtual ICollection<Uslugi> Услугиs { get; set; } = new List<Uslugi>();
}
