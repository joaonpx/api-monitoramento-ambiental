using Api.Monitoramento.Ambiental.Services;
using Api.Monitoramento.Ambiental.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Monitoramento.Ambiental.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QualidadeController : ControllerBase
{
  private readonly IQualidadeService _qualidadeService;

  public QualidadeController(IQualidadeService qualidadeService)
  {
    _qualidadeService = qualidadeService;
  }

  [HttpPost]
  [Authorize(Policy = "Admin")]
  public async Task<IActionResult> MonitorarQualidade([FromBody] QualidadeRequest request)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState);
    }

    var result = await _qualidadeService.MonitorarQualidadeAsync(request);
    return Ok(result);
  }

  [HttpGet]
  public async Task<IActionResult> ListarQualidades([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
  {
    var result = await _qualidadeService.ListarQualidadesAsync(pageNumber, pageSize);
    return Ok(result);
  }
}