using Api.Monitoramento.Ambiental.Models;
using Api.Monitoramento.Ambiental.ViewModels;

namespace Api.Monitoramento.Ambiental.Services;

public interface IDesastreService
{
  Task<Desastre> CriarAlertaDesastreAsync(DesastreRequest request);
  Task<IEnumerable<Desastre>> ListarDesastresAsync(int pageNumber, int pageSize);
}