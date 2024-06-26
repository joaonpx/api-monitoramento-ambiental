namespace Api.Monitoramento.Ambiental.Models;

public class Desastre
{
  public int Id { get; set; }
  public string Tipo { get; set; }
  public string Localizacao { get; set; }
  public int NivelSeveridade { get; set; }
  public DateTime DataHora { get; set; }
}