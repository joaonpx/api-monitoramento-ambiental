using Api.Monitoramento.Ambiental.Data;
using Api.Monitoramento.Ambiental.Models;
using Api.Monitoramento.Ambiental.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Api.Monitoramento.Ambiental.Services;

public class IrrigacaoService : IIrrigacaoService
{
  private readonly AppDbContext _context;

  public IrrigacaoService(AppDbContext context)
  {
    _context = context;
  }

  public async Task<Irrigacao> ControlarIrrigacaoAsync(IrrigacaoRequest request)
  {
    var irrigacao = new Irrigacao
    {
      Area = request.Area,
      Umidade = request.Umidade,
      Status = request.Status,
      DataHora = request.DataHora
    };

    _context.Irrigacoes.Add(irrigacao);
    await _context.SaveChangesAsync();
    return irrigacao;
  }

  public async Task<IEnumerable<Irrigacao>> ListarIrrigacoesAsync(int pageNumber, int pageSize)
  {
    return await _context.Irrigacoes
      .OrderByDescending(i => i.DataHora)
      .Skip((pageNumber - 1) * pageSize)
      .Take(pageSize)
      .ToListAsync();
  }
}