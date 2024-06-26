namespace Api.Monitoramento.Ambiental.ViewModels;

public class DesastreRequest
{
  public string Tipo { get; set; }
  public string Localizacao { get; set; }
  public int NivelSeveridade { get; set; }
  public DateTime DataHora { get; set; }
}