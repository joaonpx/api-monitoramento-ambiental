using Api.Monitoramento.Ambiental.Models;
using Api.Monitoramento.Ambiental.ViewModels;

namespace Api.Monitoramento.Ambiental.Services;

public interface IIrrigacaoService
{
  Task<Irrigacao> ControlarIrrigacaoAsync(IrrigacaoRequest request);
  Task<IEnumerable<Irrigacao>> ListarIrrigacoesAsync(int pageNumber, int pageSize);
}