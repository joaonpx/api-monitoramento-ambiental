using Api.Monitoramento.Ambiental.Controllers;
using Api.Monitoramento.Ambiental.Models;
using Api.Monitoramento.Ambiental.Services;
using Api.Monitoramento.Ambiental.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Monitoramento.Ambiental.Tests;

   public class QualidadeControllerTests
    {
        [Fact]
        public async Task MonitorarQualidade_DeveRetornarOkObjectResult()
        {
            // Arrange
            var mockService = new Mock<IQualidadeService>();
            var controller = new QualidadeController(mockService.Object);

            var request = new QualidadeRequest()
            {
                Tipo = "Ar",
                Localizacao = "Sala",
                Valor = 20.0f,
                DataHora = DateTime.Now
            };

            var qualidadeMonitorada = new Qualidade()
            {
                Id = 1,
                Tipo = request.Tipo,
                Localizacao = request.Localizacao,
                Valor = request.Valor,
                DataHora = request.DataHora
            };

            mockService.Setup(service => service.MonitorarQualidadeAsync(request))
                       .ReturnsAsync(qualidadeMonitorada);

            // Act
            var result = await controller.MonitorarQualidade(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<Qualidade>(okResult.Value);
            Assert.Equal(qualidadeMonitorada.Id, model.Id);
            Assert.Equal(qualidadeMonitorada.Tipo, model.Tipo);
            // Continue with other assertions as needed...
        }

        [Fact]
        public async Task ListarQualidades_DeveRetornarOkObjectResult()
        {
            // Arrange
            var mockService = new Mock<IQualidadeService>();
            var controller = new QualidadeController(mockService.Object);

            var pageNumber = 1;
            var pageSize = 10;
            var qualidades = new List<Qualidade>
            {
                new Qualidade { Id = 1, Tipo = "Ar", Localizacao = "Sala", Valor = 20.0f, DataHora = DateTime.Now },
                new Qualidade { Id = 2, Tipo = "Água", Localizacao = "Rio", Valor = 15.0f, DataHora = DateTime.Now.AddDays(-1) }
            };

            mockService.Setup(service => service.ListarQualidadesAsync(pageNumber, pageSize))
                       .ReturnsAsync(qualidades);

            // Act
            var result = await controller.ListarQualidades(pageNumber, pageSize);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Qualidade>>(okResult.Value);
            Assert.Collection(model,
                item => Assert.Equal(qualidades[0].Id, item.Id),
                item => Assert.Equal(qualidades[1].Id, item.Id)
                // Continue with other assertions as needed...
            );
        }
    }