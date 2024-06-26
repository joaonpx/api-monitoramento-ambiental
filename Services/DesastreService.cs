namespace Api.Monitoramento.Ambiental.Services;

using Api.Monitoramento.Ambiental.Data;
using Api.Monitoramento.Ambiental.Models;
using Api.Monitoramento.Ambiental.ViewModels;

using Microsoft.EntityFrameworkCore;

public class DesastreService : IDesastreService
{
  private readonly AppDbContext _context;

  public DesastreService(AppDbContext context)
  {
    _context = context;
  }

  public async Task<Desastre> CriarAlertaDesastreAsync(DesastreRequest request)
  {
    var desastre = new Desastre
    {
      Tipo = request.Tipo,
      Localizacao = request.Localizacao,
      NivelSeveridade = request.NivelSeveridade,
      DataHora = request.DataHora
    };

    _context.Desastres.Add(desastre);
    await _context.SaveChangesAsync();
    return desastre;
  }

  public async Task<IEnumerable<Desastre>> ListarDesastresAsync(int pageNumber, int pageSize)
  {
    return await _context.Desastres
      .OrderByDescending(d => d.DataHora)
      .Skip((pageNumber - 1) * pageSize)
      .Take(pageSize)
      .ToListAsync();
  }
}