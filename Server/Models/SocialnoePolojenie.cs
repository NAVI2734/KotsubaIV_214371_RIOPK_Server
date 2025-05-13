using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class SocialnoePolojenie
{
    public int КодСоциальногоПоложения { get; set; }

    public string? Фио { get; set; }

    public string? СоциальнаяКатегория { get; set; }

    public string? Инвалидность { get; set; }

    public string? ГруппаИнвалидности { get; set; }

    public string? СемейноеПоложение { get; set; }

    public virtual ObshieSvedenya КодСоциальногоПоложенияNavigation { get; set; } = null!;
}
