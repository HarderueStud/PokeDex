using Newtonsoft.Json;
using System.Collections.Generic;

namespace DataModel
{
    public class Generation : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "generation";
        public override string Name { get; set; }
        public List<NamedApiResource<Ability>> Abilities { get; set; }
        public List<Names> Names { get; set; }
        public List<NamedApiResource<Type>> Types { get; set; }
        public List<NamedApiResource<Move>> Moves { get; set; }


        [JsonProperty("main_region")]
        public NamedApiResource<Region> MainRegion { get; set; }


        [JsonProperty("pokemon_species")]
        public List<NamedApiResource<PokemonSpecies>> PokemonSpecies { get; set; }


        [JsonProperty("version_groups")]
        public List<NamedApiResource<VersionGroup>> VersionGroups { get; set; }
    }

    public class Pokedex : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "pokedex";
        public override string Name { get; set; }
        public List<Descriptions> Descriptions { get; set; }
        public List<Names> Names { get; set; }
        public NamedApiResource<Region> Region { get; set; }

        [JsonProperty("is_main_series")]
        public bool IsMainSeries { get; set; }

        
        [JsonProperty("pokemon_entries")]
        public List<PokemonEntry> PokemonEntries { get; set; }


        [JsonProperty("version_groups")]
        public List<NamedApiResource<VersionGroup>> VersionGroups { get; set; }
    }

    public class PokemonEntry
    {
        [JsonProperty("entry_number")]
        public int EntryNumber { get; set; }


        [JsonProperty("pokemon_species")]
        public NamedApiResource<PokemonSpecies> PokemonSpecies { get; set; }
    }

    public class Version : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "version";
        public override string Name { get; set; }
        public List<Names> Names { get; set; }


        [JsonProperty("version_group")]
        public NamedApiResource<VersionGroup> VersionGroup { get; set; }
    }

    public class VersionGroup : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "version-group";
        public override string Name { get; set; }
        public int Order { get; set; }
        public NamedApiResource<Generation> Generation { get; set; }


        [JsonProperty("move_learn_methods")]
        public List<NamedApiResource<MoveLearnMethod>> MoveLearnMethods { get; set; }


        public List<NamedApiResource<Pokedex>> Pokedexes { get; set; }
        public List<NamedApiResource<Region>> Regions { get; set; }
        public List<NamedApiResource<Version>> Versions { get; set; }
    }
}
