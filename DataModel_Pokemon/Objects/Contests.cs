using Newtonsoft.Json;
using System.Collections.Generic;

namespace DataModel
{
    public class ContestType : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "contest-type";
        public override string Name { get; set; }
        public List<ContestName> Names { get; set; }


        [JsonProperty("berry_flavor")]
        public NamedApiResource<BerryFlavor> BerryFlavor { get; set; }
    }

    public class ContestName
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public NamedApiResource<Language> Language { get; set; }
    }

    public class ContestEffect : ApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "contest-effect";
        public int Appeal { get; set; }
        public int Jam { get; set; }


        [JsonProperty("effect_entries")]
        public List<Effects> EffectEntries { get; set; }


        [JsonProperty("flavor_text_entries")]
        public List<FlavorTexts> FlavorTextEntries { get; set; }
    }

    public class SuperContestEffect : ApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "super-contest-effect";
        public int Appeal { get; set; }
        public List<NamedApiResource<Move>> Moves { get; set; }


        [JsonProperty("flavor_text_entries")]
        public List<FlavorTexts> FlavorTextEntries { get; set; }
    }
}
