﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Models;

namespace PokemonAPI.WebService.Services.ServicesAbstractions
{
    public interface IEncounterMethodsService
    {
        Task<int> Count();
        Task<List<NamedAPIResource>> GetAll(int limit, int offset);
        Task<List<NamedAPIResource>> GetAll(Expression<Func<EFEncounterMethods, bool>> predicate, int limit, int offset);
        Task<EncounterMethod> Get(int id);
        Task<EncounterMethod> Get(string name);
        Task<EncounterMethod> Get(Expression<Func<EFEncounterMethods, bool>> predicate);
    }
}