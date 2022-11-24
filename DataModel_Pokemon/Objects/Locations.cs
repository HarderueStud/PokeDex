using Newtonsoft.Json;
using System.Collections.Generic;

namespace DataModel
{
    public class Location : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "location";
        public override string Name { get; set; }
        public NamedApiResource<Region> Region { get; set; }
        public List<Names> Names { get; set; }
        public List<NamedApiResource<LocationArea>> Areas { get; set; }


        [JsonProperty("game_indices")]
        public List<GenerationGameIndex> GameIndices { get; set; }
    }

    public class LocationArea : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "location-area";
        public override string Name { get; set; }
        public NamedApiResource<Location> Location { get; set; }
        public List<Names> Names { get; set; }


        [JsonProperty("game_index")]
        public int GameIndex { get; set; }


        [JsonProperty("encounter_method_rates")]
        public List<EncounterMethodRate> EncounterMethodRates { get; set; }


        [JsonProperty("pokemon_encounters")]
        public List<PokemonEncounter> PokemonEncounters { get; set; }
    }

    public class EncounterMethodRate
    {
        [JsonProperty("encounter_method")]
        public NamedApiResource<EncounterMethod> EncounterMethod { get; set; }


        [JsonProperty("version_details")]
        public List<EncounterVersionDetails> VersionDetails { get; set; }
    }

    public class EncounterVersionDetails
    {
        public int Rate { get; set; }
        public NamedApiResource<Version> Version { get; set; }
    }

    public class PokemonEncounter
    {
        public NamedApiResource<Pokemon> Pokemon { get; set; }


        [JsonProperty("version_details")]
        public List<VersionEncounterDetail> VersionDetails { get; set; }
    }

    public class PalParkArea : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "pal-park-area";
        public override string Name { get; set; }
        public List<Names> Names { get; set; }


        [JsonProperty("pokemon_encounters")]
        public List<PalParkEncounterSpecies> PokemonEncounters { get; set; }
    }

    public class PalParkEncounterSpecies
    {
        public int Rate { get; set; }


        [JsonProperty("base_score")]
        public int BaseScore { get; set; }

        
        [JsonProperty("pokemon_species")]
        public NamedApiResource<PokemonSpecies> PokemonSpecies { get; set; }
    }

    public class Region : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "region";
        public List<NamedApiResource<Location>> Locations { get; set; }
        public override string Name { get; set; }
        public List<Names> Names { get; set; }
        public List<NamedApiResource<Pokedex>> Pokedexes { get; set; }


        [JsonProperty("main_generation")]
        public NamedApiResource<Generation> MainGeneration { get; set; }

       
        [JsonProperty("version_groups")]
        public List<NamedApiResource<VersionGroup>> VersionGroups { get; set; }
    }
}
