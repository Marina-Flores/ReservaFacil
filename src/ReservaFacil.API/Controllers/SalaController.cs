using Microsoft.AspNetCore.Mvc;
using ReservaFacil.Domain.Interfaces.Repositories;

namespace ReservaFacil.API.Controllers;

[ApiController]
[Route("/[controller]")]
public class SalaController(ISalaRepository salaRepository) : Controller
{
    [HttpGet("Obter")]
    public async Task<IActionResult> Obter()
    {
        var salas = await salaRepository.ObterAsync();
        
        return Ok(salas);
    }
}