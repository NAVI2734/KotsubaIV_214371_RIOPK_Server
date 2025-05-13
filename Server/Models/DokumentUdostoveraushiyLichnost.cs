using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Server.Models;

public partial class DokumentUdostoveraushiyLichnost
{
    public int КодДокументаУдостоверяющегоЛичность { get; set; }

    public string? Фио { get; set; }

    public string? ТипДокумента { get; set; }

    public string? Серия { get; set; }

    public string? Номер { get; set; }

    public DateTime? ДатаВыдачи { get; set; }

    public DateTime? ДатаОкончанияСрокаДействия { get; set; }

    public string? КемВыдан { get; set; }


    [JsonIgnore] 
    public virtual ObshieSvedenya КодДокументаУдостоверяющегоЛичностьNavigation { get; set; } = null!;
}
