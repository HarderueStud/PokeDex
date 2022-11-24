using Newtonsoft.Json;
using System.Collections.Generic;

namespace DataModel
{
    public class EvolutionChain : ApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "evolution-chain";
        public ChainLink Chain { get; set; }


        [JsonProperty("baby_trigger_item")]
        public NamedApiResource<Item> BabyTriggerItem { get; set; }
    }

    public class ChainLink
    {
        public NamedApiResource<PokemonSpecies> Species { get; set; }

        [JsonProperty("is_baby")]
        public bool IsBaby { get; set; }


        [JsonProperty("evolution_details")]
        public List<EvolutionDetail> EvolutionDetails { get; set; }


        [JsonProperty("evolves_to")]
        public List<ChainLink> EvolvesTo { get; set; }
    }

    public class EvolutionDetail
    {
        public NamedApiResource<Item> Item { get; set; }
        public NamedApiResource<EvolutionTrigger> Trigger { get; set; }
        public int? Gender { get; set; }
        public NamedApiResource<Location> Location { get; set; }


        [JsonProperty("held_item")]
        public NamedApiResource<Item> HeldItem { get; set; }


        [JsonProperty("known_move")]
        public NamedApiResource<Move> KnownMove { get; set; }


        [JsonProperty("known_move_type")]
        public NamedApiResource<Type> KnownMoveType { get; set; }


        [JsonProperty("min_level")]
        public int? MinLevel { get; set; }


        [JsonProperty("min_happiness")]
        public int? MinHappiness { get; set; }


        [JsonProperty("min_beauty")]
        public int? MinBeauty { get; set; }


        [JsonProperty("min_affection")]
        public int? MinAffection { get; set; }


        [JsonProperty("needs_overworld_rain")]
        public bool NeedsOverworldRain { get; set; }


        [JsonProperty("party_species")]
        public NamedApiResource<PokemonSpecies> PartySpecies { get; set; }


        [JsonProperty("party_type")]
        public NamedApiResource<Type> PartyType { get; set; }


        [JsonProperty("relative_physical_stats")]
        public int? RelativePhysicalStats { get; set; }


        [JsonProperty("time_of_day")]
        public string TimeOfDay { get; set; }


        [JsonProperty("trade_species")]
        public NamedApiResource<PokemonSpecies> TradeSpecies { get; set; }


        [JsonProperty("turn_upside_down")]
        public bool TurnUpsideDown { get; set; }
    }


    public class EvolutionTrigger : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "evolution-trigger";
        public override string Name { get; set; }
        public List<Names> Names { get; set; }


        [JsonProperty("pokemon_species")]
        public List<NamedApiResource<PokemonSpecies>> PokemonSpecies { get; set; }
    }
}
