namespace Api.Monitoramento.Ambiental.ViewModels;

public class QualidadeRequest
{
  public string Tipo { get; set; }
  public string Localizacao { get; set; }
  public float Valor { get; set; }
  public DateTime DataHora { get; set; }
}