using Api.Monitoramento.Ambiental.Services;
using Api.Monitoramento.Ambiental.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Monitoramento.Ambiental.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IrrigacaoController : ControllerBase
{
  private readonly IIrrigacaoService _irrigacaoService;

  public IrrigacaoController(IIrrigacaoService irrigacaoService)
  {
    _irrigacaoService = irrigacaoService;
  }

  [HttpPost]
  [Authorize(Policy = "Admin")]
  public async Task<IActionResult> ControlarIrrigacao([FromBody] IrrigacaoRequest request)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }

    var result = await _irrigacaoService.ControlarIrrigacaoAsync(request);
    return Ok(result);
  }

  [HttpGet]
  public async Task<IActionResult> ListarIrrigacoes([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
  {
    var result = await _irrigacaoService.ListarIrrigacoesAsync(pageNumber, pageSize);
    return Ok(result);
  }
}