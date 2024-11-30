﻿using Microsoft.Extensions.DependencyInjection;
using ReservaFacil.Data.Repositories;
using ReservaFacil.Domain.Interfaces.Repositories;
using ReservaFacil.Domain.Interfaces.Services;
using ReservaFacil.Domain.Services;

namespace ReservaFacil.IoC
{
    public static class StaticInjectorConfig
    {
        public static void RegisterStaticDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IPerfilRepository, PerfilRepository>();
            services.AddScoped<IPermissaoRepository, PermissaoRepository>();
            services.AddScoped<IUsuarioPermissaoRepository, UsuarioPermissaoRepository>();

            services.AddScoped<IUsuarioService, UsuarioService>();
        }
    }
}
