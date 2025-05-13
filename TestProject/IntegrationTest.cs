using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Server;
using Server.Models;
using Xunit;

namespace Server.Tests
{
    public class DocumentsControllerGetLiveDbTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public DocumentsControllerGetLiveDbTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetDokumentUdostoveraushiyLichnost_LiveDb_ReturnsList()
        {
            // Act
            var response = await _client.GetAsync("/api/Documents/GetDokumentUdostoveraushiyLichnost");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var documents = await response.Content.ReadFromJsonAsync<List<DocumentPredostavlaushiyLgotu>>();
            documents.Should().NotBeNull();

            documents!.Count.Should().BeGreaterThan(0);
        }
    }
}
