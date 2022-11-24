using Newtonsoft.Json;
using System.Collections.Generic;

namespace DataModel
{
    public class NamedApiResource<T> : UrlNavigation<T> where T : ResourceBase
    {
        public string Name { get; set; }
    }

    public class Names
    {
        public string Name { get; set; }
        public NamedApiResource<Language> Language { get; set; }
    }

    public class Descriptions
    {
        public string Description { get; set; }
        public NamedApiResource<Language> Language { get; set; }
    }

    public class Language : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "language";
        public override string Name { get; set; }
        public bool Official { get; set; }
        public string Iso639 { get; set; }
        public string Iso3166 { get; set; }
        public List<Names> Names { get; set; }
    }

    public class ApiResource<T> : UrlNavigation<T> where T : ResourceBase { }

    public class Effects
    {
        public string Effect { get; set; }
        public NamedApiResource<Language> Language { get; set; }
    }

    public class FlavorTexts
    {
        public NamedApiResource<Language> Language { get; set; }


        [JsonProperty("flavor_text")]
        public string FlavorText { get; set; }
    }

    public class GenerationGameIndex
    {
        public NamedApiResource<Generation> Generation { get; set; }


        [JsonProperty("game_index")]
        public int GameIndex { get; set; }
    }

    public class VerboseEffect
    {
        public string Effect { get; set; }
        public NamedApiResource<Language> Language { get; set; }


        [JsonProperty("short_effect")]
        public string ShortEffect { get; set; }
    }

    public class VersionGameIndex
    {
        public NamedApiResource<Version> Version { get; set; }


        [JsonProperty("game_index")]
        public int GameIndex { get; set; }
    }

    public class VersionEncounterDetail
    {
        public NamedApiResource<Version> Version { get; set; }


        [JsonProperty("max_chance")]
        public int MaxChance { get; set; }


        [JsonProperty("encounter_details")]
        public List<Encounter> EncounterDetails { get; set; }
    }

    public class Encounter
    {
        public int Chance { get; set; }
        public NamedApiResource<EncounterMethod> Method { get; set; }


        [JsonProperty("min_level")]
        public int MinLevel { get; set; }


        [JsonProperty("max_level")]
        public int MaxLevel { get; set; }


        [JsonProperty("condition_values")]
        public List<NamedApiResource<EncounterConditionValue>> ConditionValues { get; set; }
    }

    public class MachineVersionDetail
    {
         public ApiResource<Machine> Machine { get; set; }


         [JsonProperty("version_group")]
         public NamedApiResource<VersionGroup> VersionGroup { get; set; }
     }

    public class VersionGroupFlavorText
    {
        public string Text { get; set; }
        public NamedApiResource<Language> Language { get; set; }


        [JsonProperty("version_group")]
        public NamedApiResource<VersionGroup> VersionGroup { get; set; }
    }
}
