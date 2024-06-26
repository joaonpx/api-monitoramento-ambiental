using Api.Monitoramento.Ambiental.Models;
using Api.Monitoramento.Ambiental.ViewModels;

namespace Api.Monitoramento.Ambiental.Services;

public interface IQualidadeService
{
  Task<Qualidade> MonitorarQualidadeAsync(QualidadeRequest request);
  Task<IEnumerable<Qualidade>> ListarQualidadesAsync(int pageNumber, int pageSize);
}