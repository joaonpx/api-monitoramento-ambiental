namespace Api.Monitoramento.Ambiental.ViewModels;

public class IrrigacaoRequest
{
  public string Area { get; set; }
  public float Umidade { get; set; }
  public bool Status { get; set; }
  public DateTime DataHora { get; set; }
}