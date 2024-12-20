﻿using Microsoft.AspNetCore.Mvc;
using ReservaFacil.Application.DTOs;
using ReservaFacil.Web.Services;

namespace ReservaFacil.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ApiService _apiService;

        public UsuarioController(IConfiguration configuration)
        {
            _apiService = new ApiService(configuration);
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Cadastro()
        {
            try
            {
                var perfilComPermissoes = await _apiService.GetDataAsync<List<PerfilComPermissoesDTO>>("perfil/perfil-com-permissoes");
            
                var permissoes = perfilComPermissoes
                    .SelectMany(p => p.Permissoes)  
                    .Where(p => p != null && p.IdPermissao > 0)
                    .DistinctBy(p => p.IdPermissao)                    
                    .ToList();
            
                ViewBag.PerfilComPermissoes = perfilComPermissoes;
                ViewBag.Permissoes = permissoes;

                return View();
            }
            catch (Exception)
            {
                ViewBag.PerfilComPermissoes = new List<PerfilComPermissoesDTO>();
                ViewBag.Permissoes = new List<PermissaoDTO>();
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Cadastro(UsuarioDTO usuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var success = await _apiService.PostDataAsync("usuario", usuario);

                    return Json(success ? new { success = true, message = "Usuário adicionado com sucesso!" } : new { success = false, message = "Erro ao adicionar o usuário. Tente novamente mais tarde." });
                }
                catch (Exception ex)
                {
                    return Json(new
                    {
                        success = false, message = "Ocorreu um erro interno. Tente novamente mais tarde.",
                        errorDetails = ex.Message
                    });
                }
            }
            
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            return Json(new { success = false, errors });
        }
    }
}