    using Api.Monitoramento.Ambiental.Controllers;
    using Api.Monitoramento.Ambiental.Models;
    using Api.Monitoramento.Ambiental.Services;
    using Api.Monitoramento.Ambiental.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Xunit;

    public class DesastresControllerTests
    {
        [Fact]
        public async Task CriarAlertaDesastre_DeveRetornarOkObjectResult()
        {
            // Arrange
            var mockService = new Mock<IDesastreService>();
            var controller = new DesastresController(mockService.Object);

            var request = new DesastreRequest()
            {
                Tipo = "Incêndio",
                Localizacao = "Latitude: 123, Longitude: 456",
                NivelSeveridade = 3,
                DataHora = DateTime.Now
            };

            var desastreCriado = new Desastre()
            {
                Id = 1,
                Tipo = request.Tipo,
                Localizacao = request.Localizacao,
                NivelSeveridade = request.NivelSeveridade,
                DataHora = request.DataHora
            };

            mockService.Setup(service => service.CriarAlertaDesastreAsync(request))
                       .ReturnsAsync(desastreCriado);

            // Act
            var result = await controller.CriarAlertaDesastre(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<Desastre>(okResult.Value);
            Assert.Equal(desastreCriado.Id, model.Id);
            Assert.Equal(desastreCriado.Tipo, model.Tipo);
            // Continue with other assertions as needed...
        }

        [Fact]
        public async Task ListarDesastres_DeveRetornarOkObjectResult()
        {
            // Arrange
            var mockService = new Mock<IDesastreService>();
            var controller = new DesastresController(mockService.Object);

            var pageNumber = 1;
            var pageSize = 10;
            var desastres = new List<Desastre>
            {
                new Desastre { Id = 1, Tipo = "Incêndio", Localizacao = "Latitude: 123, Longitude: 456", NivelSeveridade = 3, DataHora = DateTime.Now },
                new Desastre { Id = 2, Tipo = "Inundação", Localizacao = "Latitude: 456, Longitude: 789", NivelSeveridade = 2, DataHora = DateTime.Now.AddDays(-1) }
            };

            mockService.Setup(service => service.ListarDesastresAsync(pageNumber, pageSize))
                       .ReturnsAsync(desastres);

            // Act
            var result = await controller.ListarDesastres(pageNumber, pageSize);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Desastre>>(okResult.Value);
            Assert.Collection(model,
                item => Assert.Equal(desastres[0].Id, item.Id),
                item => Assert.Equal(desastres[1].Id, item.Id)
                // Continue with other assertions as needed...
            );
        }
    }