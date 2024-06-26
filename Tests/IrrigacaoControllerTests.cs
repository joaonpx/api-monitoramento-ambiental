using Api.Monitoramento.Ambiental.Controllers;
using Api.Monitoramento.Ambiental.Models;
using Api.Monitoramento.Ambiental.Services;
using Api.Monitoramento.Ambiental.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Monitoramento.Ambiental.Tests;

    public class IrrigacaoControllerTests
    {
        [Fact]
        public async Task ControlarIrrigacao_DeveRetornarOkObjectResult()
        {
            // Arrange
            var mockService = new Mock<IIrrigacaoService>();
            var controller = new IrrigacaoController(mockService.Object);

            var request = new IrrigacaoRequest()
            {
                Area = "Área A",
                Umidade = 60.5f,
                Status = true,
                DataHora = DateTime.Now
            };

            var irrigacaoCriada = new Irrigacao()
            {
                Id = 1,
                Area = request.Area,
                Umidade = request.Umidade,
                Status = request.Status,
                DataHora = request.DataHora
            };

            mockService.Setup(service => service.ControlarIrrigacaoAsync(request))
                       .ReturnsAsync(irrigacaoCriada);

            // Act
            var result = await controller.ControlarIrrigacao(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<Irrigacao>(okResult.Value);
            Assert.Equal(irrigacaoCriada.Id, model.Id);
            Assert.Equal(irrigacaoCriada.Area, model.Area);
            // Continue with other assertions as needed...
        }

        [Fact]
        public async Task ListarIrrigacoes_DeveRetornarOkObjectResult()
        {
            // Arrange
            var mockService = new Mock<IIrrigacaoService>();
            var controller = new IrrigacaoController(mockService.Object);

            var pageNumber = 1;
            var pageSize = 10;
            var irrigacoes = new List<Irrigacao>
            {
                new Irrigacao { Id = 1, Area = "Área A", Umidade = 60.5f, Status = true, DataHora = DateTime.Now },
                new Irrigacao { Id = 2, Area = "Área B", Umidade = 55.2f, Status = false, DataHora = DateTime.Now.AddDays(-1) }
            };

            mockService.Setup(service => service.ListarIrrigacoesAsync(pageNumber, pageSize))
                       .ReturnsAsync(irrigacoes);

            // Act
            var result = await controller.ListarIrrigacoes(pageNumber, pageSize);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Irrigacao>>(okResult.Value);
            Assert.Collection(model,
                item => Assert.Equal(irrigacoes[0].Id, item.Id),
                item => Assert.Equal(irrigacoes[1].Id, item.Id)
                // Continue with other assertions as needed...
            );
        }
    }