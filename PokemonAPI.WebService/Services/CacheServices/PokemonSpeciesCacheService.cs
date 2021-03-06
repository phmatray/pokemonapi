using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using PokemonAPI.Models.Rsc;
using PokemonAPI.WebService.Services.CacheServicesAbstractions;
using PokemonAPI.WebService.Services.ServicesAbstractions;

namespace PokemonAPI.WebService.Services.CacheServices
{
    public class PokemonSpeciesCacheService : IPokemonSpeciesCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<PokemonSpeciesCacheService> _logger;
        private readonly IPokemonSpeciesService _pokemonSpeciesService;
        private readonly string _typeName;

        public PokemonSpeciesCacheService(
            IMemoryCache memoryCache,
            ILogger<PokemonSpeciesCacheService> logger,
            IPokemonSpeciesService pokemonSpeciesService)
        {
            _memoryCache           = memoryCache;
            _logger                = logger;
            _pokemonSpeciesService = pokemonSpeciesService;
            _typeName              = GetType().Name;
        }

        public async Task<int> Count()
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Count",
                entry => _pokemonSpeciesService.Count());

        public async Task<List<NamedAPIResource>> GetAll(int limit, int offset)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-GetAll-{limit}-{offset}",
                entry => _pokemonSpeciesService.GetAll(limit, offset));

        public async Task<PokemonSpecies> Get(int id)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{id}",
                entry => _pokemonSpeciesService.Get(id));

        public async Task<PokemonSpecies> Get(string name)
            => await _memoryCache.GetOrCreateAsync(
                $"{_typeName}-Get-{name}",
                entry => _pokemonSpeciesService.Get(name));
    }
}