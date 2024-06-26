namespace Api.Monitoramento.Ambiental.Models;

public class Qualidade
{
  public int Id { get; set; }
  public string Tipo { get; set; }
  public string Localizacao { get; set; }
  public float Valor { get; set; }
  public DateTime DataHora { get; set; }
}