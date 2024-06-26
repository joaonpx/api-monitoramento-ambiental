namespace Api.Monitoramento.Ambiental.Models;

public class Irrigacao
{
  public int Id { get; set; }
  public string Area { get; set; }
  public float Umidade { get; set; }
  public bool Status { get; set; }
  public DateTime DataHora { get; set; }
}