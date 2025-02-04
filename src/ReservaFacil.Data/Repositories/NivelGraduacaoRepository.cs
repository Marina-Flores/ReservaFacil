﻿using Microsoft.Extensions.Configuration;
using ReservaFacil.Data.Repositories.Shared;
using ReservaFacil.Domain.Interfaces.Repositories;
using ReservaFacil.Domain.Models;

namespace ReservaFacil.Data.Repositories;

public class NivelGraduacaoRepository : BaseRepository<NivelGraduacao>, INivelGraduacaoRepository
{
    public NivelGraduacaoRepository(IConfiguration configuration)
            : base(configuration) { }
}
