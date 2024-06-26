using Api.Monitoramento.Ambiental.Services;
using Api.Monitoramento.Ambiental.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Monitoramento.Ambiental.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DesastresController : ControllerBase
{
  private readonly IDesastreService _desastreService;

  public DesastresController(IDesastreService desastreService)
  {
    _desastreService = desastreService;
  }

  [HttpPost]
  [Authorize(Policy = "Admin")]
  public async Task<IActionResult> CriarAlertaDesastre([FromBody] DesastreRequest request)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }

    var result = await _desastreService.CriarAlertaDesastreAsync(request);
    return Ok(result);
  }

  [HttpGet]
  public async Task<IActionResult> ListarDesastres([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
  {
    var result = await _desastreService.ListarDesastresAsync(pageNumber, pageSize);
    return Ok(result);
  }
}