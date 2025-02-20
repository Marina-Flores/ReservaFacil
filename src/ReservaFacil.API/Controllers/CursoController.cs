﻿using Microsoft.AspNetCore.Mvc;
using ReservaFacil.Domain.Interfaces.Repositories;

namespace ReservaFacil.API.Controllers;

[ApiController]
[Route("/[controller]")]
public class CursoController(ICursoRepository cursoRepository) : Controller
{
    [HttpGet("Obter")]
    public async Task<IActionResult> Obter()
    {
        var cursos = await cursoRepository.ObterAsync();

        return Ok(cursos);
    }
}
