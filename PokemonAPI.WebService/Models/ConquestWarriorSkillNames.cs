﻿using PokemonAPI.WebService.Models.Interfaces;

namespace PokemonAPI.WebService.Models
{
    public class EFConquestWarriorSkillNames : IEFModel
    {
        public int SkillId { get; set; }
        public int LocalLanguageId { get; set; }
        public string Name { get; set; }

        public virtual EFLanguages LocalLanguage { get; set; }
        public virtual EFConquestWarriorSkills Skill { get; set; }
    }
}
