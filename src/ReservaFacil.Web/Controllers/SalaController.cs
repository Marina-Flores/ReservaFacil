using Microsoft.AspNetCore.Mvc;
using ReservaFacil.Application.ViewModels;
using ReservaFacil.Domain.Models;
using ReservaFacil.Web.Services;

namespace ReservaFacil.Web.Controllers;

public class SalaController(IConfiguration configuration) : Controller
{
    private readonly ApiService _apiService = new ApiService(configuration);

    public IActionResult Index()
        => View();

    public async Task<IActionResult> ListarSalas(int numeroPagina)
    {
        var salas = await _apiService.GetDataAsync<IEnumerable<Sala>>("Sala/Obter");
        var cursos = await _apiService.GetDataAsync<IEnumerable<Curso>>("Curso/Obter");

        var quantidadeSalas = salas?.ToList().Count ?? 0;
        var quantidadePaginas = (int)Math.Ceiling((double)quantidadeSalas / 10);
        
        var viewModel = new ListaSalasViewModel
        {
            Salas = salas?.Skip((numeroPagina - 1) * 10).Take(10).ToList(), 
            Cursos = cursos,
            PaginaAtiva = numeroPagina,
            QuantidadePaginas = quantidadePaginas,
            QuantidadeSalas = quantidadeSalas
        };

        return PartialView("_Salas", viewModel);
    }
    
    public async Task<IActionResult> Cadastro()
    {
        var cursos = await _apiService.GetDataAsync<IEnumerable<Curso>>("Curso/Obter");
        return View(cursos);
    }
}