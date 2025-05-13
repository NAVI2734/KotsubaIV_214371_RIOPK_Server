namespace Server.Models.DTO
{
    public class DokumentDto
    {
        public int КодДокументаУдостоверяющегоЛичность { get; set; }
        public string? Фио { get; set; }
        public string? ТипДокумента { get; set; }
        public string? Серия { get; set; }
        public string? Номер { get; set; }
        public DateTime? ДатаВыдачи { get; set; }
        public DateTime? ДатаОкончанияСрокаДействия { get; set; }
        public string? КемВыдан { get; set; }
    }

}
