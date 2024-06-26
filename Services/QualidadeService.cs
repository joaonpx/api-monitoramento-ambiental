using Api.Monitoramento.Ambiental.Data;
using Api.Monitoramento.Ambiental.Models;
using Api.Monitoramento.Ambiental.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Api.Monitoramento.Ambiental.Services;

public class QualidadeService : IQualidadeService
{
  private readonly AppDbContext _context;

  public QualidadeService(AppDbContext context)
  {
    _context = context;
  }

  public async Task<Qualidade> MonitorarQualidadeAsync(QualidadeRequest request)
  {
    var qualidade = new Qualidade
    {
      Tipo = request.Tipo,
      Localizacao = request.Localizacao,
      Valor = request.Valor,
      DataHora = request.DataHora
    };

    _context.Qualidades.Add(qualidade);
    await _context.SaveChangesAsync();
    return qualidade;
  }

  public async Task<IEnumerable<Qualidade>> ListarQualidadesAsync(int pageNumber, int pageSize)
  {
    return await _context.Qualidades
      .OrderByDescending(q => q.DataHora)
      .Skip((pageNumber - 1) * pageSize)
      .Take(pageSize)
      .ToListAsync();
  }
}