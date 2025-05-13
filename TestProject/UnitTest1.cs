using Server.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Server.Data;
using Server.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Server.Tests
{
    public class DocumentsControllerTests
    {
        private Mock<DbSet<DokumentUdostoveraushiyLichnost>> GetMockDbSet()
        {
            var data = new List<DokumentUdostoveraushiyLichnost>
            {
                new DokumentUdostoveraushiyLichnost
                {
                     одƒокумента”достовер€ющегоЋичность = 1,
                    ‘ио = "»ванов »ван",
                    “ипƒокумента = "ѕаспорт"
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<DokumentUdostoveraushiyLichnost>>();
            mockSet.As<IQueryable<DokumentUdostoveraushiyLichnost>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<DokumentUdostoveraushiyLichnost>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<DokumentUdostoveraushiyLichnost>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<DokumentUdostoveraushiyLichnost>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return mockSet;
        }
        [Fact]
        public async Task SaveDocument_ValidModel_ReturnsOk()
        {
            // Arrange
            var mockSet = GetMockDbSet();

            var mockContext = new Mock<NaselenieDbContext>();
            mockContext.Setup(c => c.DokumentUdostoveraushiyLichnost).Returns(mockSet.Object);
            mockContext.Setup(c => c.SaveChangesAsync(default)).ReturnsAsync(1);

            var controller = new DocumentsController(mockContext.Object);

            var model = new DokumentDto
            {
                 одƒокумента”достовер€ющегоЋичность = 1,
                ‘ио = "»ванов »ван",
                “ипƒокумента = "ѕаспорт"
            };

            // Act
            var result = await controller.UpdateDocument(model);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
