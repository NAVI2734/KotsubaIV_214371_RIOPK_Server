using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.Models;
using Server.Models.DTO;

[ApiController]
[Route("api/[controller]")]
public class DocumentsController : ControllerBase
{
    private readonly NaselenieDbContext _context;

    public DocumentsController(NaselenieDbContext context)
    {
        _context = context;
    }

    [HttpPost("saveDokumentUdostoveraushiyLichnost")]
    public async Task<IActionResult> UpdateDocument([FromBody] DokumentDto updatedDoc)
    {
        // Получение объекта для редактирования по его id
        var existingDoc =  _context.DokumentUdostoveraushiyLichnost
            .FirstOrDefault(x => x.КодДокументаУдостоверяющегоЛичность == updatedDoc.КодДокументаУдостоверяющегоЛичность);
        if (existingDoc == null)
        {
            return NotFound(new { message = "Документ не найден." });
        }

        // Обновляем поля
        existingDoc.Фио = updatedDoc.Фио;
        existingDoc.ТипДокумента = updatedDoc.ТипДокумента;
        existingDoc.Серия = updatedDoc.Серия;
        existingDoc.Номер = updatedDoc.Номер;
        existingDoc.ДатаВыдачи = updatedDoc.ДатаВыдачи;
        existingDoc.ДатаОкончанияСрокаДействия = updatedDoc.ДатаОкончанияСрокаДействия;
        existingDoc.КемВыдан = updatedDoc.КемВыдан;

        try
        {
            // Сохранение изменений объекта
            await _context.SaveChangesAsync();
            return Ok(new { message = "Запись успешно обновлена." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Ошибка при сохранении изменений.", error = ex.Message });
        }
    }

    [HttpGet("GetDokumentUdostoveraushiyLichnost")]
    public IEnumerable<DocumentPredostavlaushiyLgotu> GetA()
    {
        var a = _context.DocumentPredostavlaushiyLgotu.ToList();

        return a;
    }
}
