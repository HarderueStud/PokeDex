using Newtonsoft.Json;
using System.Collections.Generic;

namespace DataModel
{
    public class Item : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "item";
        public override string Name { get; set; }
        public int Cost { get; set; }
        public List<NamedApiResource<ItemAttribute>> Attributes { get; set; }
        public NamedApiResource<ItemCategory> Category { get; set; }


        [JsonProperty("fling_power")]
        public int? FlingPower { get; set; }


        [JsonProperty("fling_effect")]
        public NamedApiResource<ItemFlingEffect> FlingEffect { get; set; }


        [JsonProperty("effect_entries")]
        public List<VerboseEffect> EffectEntries { get; set; }


        [JsonProperty("flavor_text_entries")]
        public List<VersionGroupFlavorText> FlavorGroupTextEntries { get; set; }


        [JsonProperty("game_indices")]
        public List<GenerationGameIndex> GameIndices { get; set; }


        public List<Names> Names { get; set; }
        public ItemSprites Sprites { get; set; }
        public List<MachineVersionDetail> Machines { get; set; }


        [JsonProperty("held_by_pokemon")]
        public List<ItemHolderPokemon> HeldByPokemon { get; set; }


        [JsonProperty("baby_trigger_for")]
        public ApiResource<EvolutionChain> BabyTriggerFor { get; set; }
    }

    public class ItemSprites
    {
        public string Default { get; set; }
    }

    public class ItemHolderPokemon
    {
        public NamedApiResource<Pokemon> Pokemon { get; set; }


        [JsonProperty("version_details")]
        public List<ItemHolderPokemonVersionDetail> VersionDetails { get; set; }
    }

    public class ItemHolderPokemonVersionDetail
    {
        public string Rarity { get; set; }
        public NamedApiResource<Version> Version { get; set; }
    }

    public class ItemAttribute : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "item-attribute";
        public override string Name { get; set; }
        public List<NamedApiResource<Item>> Items { get; set; }
        public List<Names> Names { get; set; }
        public List<Descriptions> Descriptions { get; set; }
    }

    public class ItemCategory : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "item-category";
        public override string Name { get; set; }
        public List<NamedApiResource<Item>> Items { get; set; }
        public List<Names> Names { get; set; }
        public NamedApiResource<ItemPocket> Pocket { get; set; }
    }

    public class ItemFlingEffect : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "item-fling-effect";
        public override string Name { get; set; }
        public List<NamedApiResource<Item>> Items { get; set; }


        [JsonProperty("effect_entries")]
        public List<Effects> EffectEntries { get; set; }
    }

    public class ItemPocket : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "item-pocket";
        public override string Name { get; set; }
        public List<NamedApiResource<ItemCategory>> Categories { get; set; }
        public List<Names> Names { get; set; }
    }
}
