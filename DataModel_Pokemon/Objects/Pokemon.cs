using System.Collections.Generic;
using Newtonsoft.Json;

namespace DataModel
{
    /// <summary>
    /// 
    /// Les classes sont construites en fonction de la hiérarchie disponible 
    /// dans la documentation de pokeapi.co a l'adresse : https://pokeapi.co/docs/v2
    /// 
    /// </summary>

    // Pokemon (endpoint)
    public class PokemonList
    {
        [JsonProperty("results")]
        public List<NamedApiResource<Pokemon>> Pokemons { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("previous")]
        public string Previous { get; set; }
    }
    public class Pokemon : NamedApiResource
    {
        internal new static string ApiEndpoint { get; } = "pokemon";

        [JsonProperty("id")]
        public override int Id { get; set; }

        [JsonProperty("name")]
        public override string Name { get; set; }

        [JsonProperty("base_experience")]
        public int BaseExperience { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("weight")]
        public int Weight { get; set; }

        [JsonProperty("abilities")]
        public List<PokemonAbility> Abilities { get; set; }

        [JsonProperty("forms")]
        public List<NamedApiResource<PokemonForm>> Forms { get; set; }

        [JsonProperty("game_indices")]
        public List<VersionGameIndex> GameIndicies { get; set; }

        [JsonProperty("held_items")]
        public List<PokemonHeldItem> HeldItems { get; set; }

        [JsonProperty("location_area_encounters")]
        public string LocationAreaEncounters { get; set; }

        [JsonProperty("moves")]
        public List<PokemonMove> Moves { get; set; }

        [JsonProperty("species")]
        public NamedApiResource<PokemonSpecies> Species { get; set; }

        [JsonProperty("sprites")]
        public PokemonSprites Sprites { get; set; }

        [JsonProperty("stats")]
        public List<PokemonStat> Stats { get; set; }

        [JsonProperty("types")]
        public List<PokemonType> Types { get; set; }
    }


    // ---- Ability ----
    public class Ability : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "ability";
        public override string Name { get; set; }
        public NamedApiResource<Generation> Generation { get; set; }
        public List<Names> Names { get; set; }
        public List<AbilityPokemon> Pokemon { get; set; }


        [JsonProperty("is_main_series")]
        public bool IsMainSeries { get; set; }


        [JsonProperty("effect_entries")]
        public List<VerboseEffect> EffectEntries { get; set; }


        [JsonProperty("effect_changes")]
        public List<AbilityEffectChange> EffectChanges { get; set; }


        [JsonProperty("flavor_text_entries")]
        public List<AbilityFlavorText> FlavorTextEntries { get; set; }
    }

    public class AbilityEffectChange
    {
        [JsonProperty("effect_entries")]
        public List<Effects> EffectEntries { get; set; }


        [JsonProperty("version_group")]
        public NamedApiResource<VersionGroup> VersionGroup { get; set; }
    }

    public class AbilityFlavorText
    {
        public NamedApiResource<Language> Language { get; set; }


        [JsonProperty("flavor_text")]
        public string FlavorText { get; set; }


        [JsonProperty("version_group")]
        public NamedApiResource<VersionGroup> VersionGroup { get; set; }
    }

    public class AbilityPokemon
    {
        public int Slot { get; set; }
        public NamedApiResource<Pokemon> Pokemon { get; set; }


        [JsonProperty("is_hidden")]
        public bool IsHidden { get; set; }
    }

    public class PokemonAbility
    {
        public int Slot { get; set; }
        public NamedApiResource<Ability> Ability { get; set; }


        [JsonProperty("is_hidden")]
        public bool IsHidden { get; set; }
    }


    // ---- Form ----
    public class PokemonForm : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "pokemon-form";
        public override string Name { get; set; }
        public int Order { get; set; }
        public NamedApiResource<Pokemon> Pokemon { get; set; }
        public PokemonFormSprites Sprites { get; set; }
        public List<Names> Names { get; set; }


        [JsonProperty("form_order")]
        public int FormOrder { get; set; }


        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }


        [JsonProperty("is_battle_only")]
        public bool IsBattleOnly { get; set; }


        [JsonProperty("is_mega")]
        public bool IsMega { get; set; }


        [JsonProperty("form_name")]
        public string FormName { get; set; }


        [JsonProperty("version_group")]
        public NamedApiResource<VersionGroup> VersionGroup { get; set; }


        [JsonProperty("form_names")]
        public List<Names> FormNames { get; set; }
    }

    public class PokemonFormSprites
    {
        [JsonProperty("front_default")]
        public string FrontDefault { get; set; }


        [JsonProperty("front_shiny")]
        public string FrontShiny { get; set; }


        [JsonProperty("back_default")]
        public string BackDefault { get; set; }


        [JsonProperty("back_shiny")]
        public string BackShiny { get; set; }
    }


    // ---- Move ----
    public class PokemonMove
    {
        public NamedApiResource<Move> Move { get; set; }


        [JsonProperty("version_group_details")]
        public List<PokemonMoveVersion> VersionGroupDetails { get; set; }
    }

    public class PokemonMoveVersion
    {
        [JsonProperty("move_learn_method")]
        public NamedApiResource<MoveLearnMethod> MoveLearnMethod { get; set; }


        [JsonProperty("version_group")]
        public NamedApiResource<VersionGroup> VersionGroup { get; set; }


        [JsonProperty("level_learned_at")]
        public int LevelLearnedAt { get; set; }
    }


    // ---- Sprite ----
    public class PokemonSprites
    {
        [JsonProperty("front_default")]
        public string FrontDefault { get; set; }


        [JsonProperty("front_shiny")]
        public string FrontShiny { get; set; }


        [JsonProperty("front_female")]
        public string FrontFemale { get; set; }


        [JsonProperty("front_shiny_female")]
        public string FrontShinyFemale { get; set; }


        [JsonProperty("back_default")]
        public string BackDefault { get; set; }


        [JsonProperty("back_shiny")]
        public string BackShiny { get; set; }


        [JsonProperty("back_female")]
        public string BackFemale { get; set; }


        [JsonProperty("back_shiny_female")]
        public string BackShinyFemale { get; set; }
    }


    // ---- Species ----
    public class PokemonSpecies : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "pokemon-species";
        public override string Name { get; set; }
        public int Order { get; set; }

        public NamedApiResource<PokemonColor> Color { get; set; }
        public NamedApiResource<PokemonShape> Shape { get; set; }
        public NamedApiResource<PokemonHabitat> Habitat { get; set; }
        public NamedApiResource<Generation> Generation { get; set; }
        public List<Names> Names { get; set; }
        public List<Genuses> Genera { get; set; }
        public List<PokemonSpeciesVariety> Varieties { get; set; }


        [JsonProperty("gender_rate")]
        public int GenderRate { get; set; }


        [JsonProperty("capture_rate")]
        public int CaptureRate { get; set; }


        [JsonProperty("base_happiness")]
        public int BaseHappiness { get; set; }


        [JsonProperty("is_baby")]
        public bool IsBaby { get; set; }


        [JsonProperty("hatch_counter")]
        public int HatchCounter { get; set; }


        [JsonProperty("has_gender_differences")]
        public bool HasGenderDifferences { get; set; }


        [JsonProperty("forms_switchable")]
        public bool FormsSwitchable { get; set; }


        [JsonProperty("growth_rate")]
        public NamedApiResource<GrowthRate> GrowthRate { get; set; }


        [JsonProperty("pokedex_numbers")]
        public List<PokemonSpeciesDexEntry> PokedexNumbers { get; set; }


        [JsonProperty("egg_groups")]
        public List<NamedApiResource<EggGroup>> EggGroups { get; set; }


        [JsonProperty("evolves_from_species")]
        public NamedApiResource<PokemonSpecies> EvolvesFromSpecies { get; set; }


        [JsonProperty("evolution_chain")]
        public ApiResource<EvolutionChain> EvolutionChain { get; set; }


        [JsonProperty("pal_park_encounters")]
        public List<PalParkEncounterArea> PalParkEncounters { get; set; }


        [JsonProperty("flavor_text_entries")]
        public List<PokemonSpeciesFlavorTexts> FlavorTextEntries { get; set; }


        [JsonProperty("form_descriptions")]
        public List<Descriptions> FormDescriptions { get; set; }
    }

    public class PokemonColor : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "pokemon-color";
        public override string Name { get; set; }
        public List<Names> Names { get; set; }


        [JsonProperty("pokemon_species")]
        public List<NamedApiResource<PokemonSpecies>> PokemonSpecies { get; set; }
    }

    public class PokemonShape : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "pokemon-shape";
        public override string Name { get; set; }
        public List<Names> Names { get; set; }


        [JsonProperty("awesome_names")]
        public List<AwesomeNames> AwesomeNames { get; set; }


        [JsonProperty("pokemon_species")]
        public List<NamedApiResource<PokemonSpecies>> PokemonSpecies { get; set; }
    }

    public class PokemonHabitat : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "pokemon-habitat";
        public override string Name { get; set; }
        public List<Names> Names { get; set; }


        [JsonProperty("pokemon_species")]
        public List<NamedApiResource<PokemonSpecies>> PokemonSpecies { get; set; }
    }

    public class Genuses
    {
        public string Genus { get; set; }
        public NamedApiResource<Language> Language { get; set; }
    }

    public class PokemonSpeciesVariety
    {
        public NamedApiResource<Pokemon> Pokemon { get; set; }

        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }
    }

    public class GrowthRate : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "growth-rate";
        public override string Name { get; set; }
        public string Formula { get; set; }
        public List<Descriptions> Descriptions { get; set; }
        public List<GrowthRateExperienceLevel> Levels { get; set; }


        [JsonProperty("pokemon_species")]
        public List<NamedApiResource<PokemonSpecies>> PokemonSpecies { get; set; }
    }

    public class PokemonSpeciesDexEntry
    {
        public NamedApiResource<Pokedex> Pokedex { get; set; }


        [JsonProperty("entry_number")]
        public int EntryNumber { get; set; }
    }

    public class EggGroup : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "egg-group";
        public override string Name { get; set; }
        public List<Names> Names { get; set; }


        [JsonProperty("pokemon_species")]
        public List<NamedApiResource<PokemonSpecies>> PokemonSpecies { get; set; }
    }

    public class PalParkEncounterArea
    {
        public int Rate { get; set; }
        public NamedApiResource<PalParkArea> Area { get; set; }


        [JsonProperty("base_score")]
        public int BaseScore { get; set; }
    }

    public class PokemonSpeciesFlavorTexts
    {
        public NamedApiResource<Version> Version { get; set; }
        public NamedApiResource<Language> Language { get; set; }


        [JsonProperty("flavor_text")]
        public string FlavorText { get; set; }
    }


    // ---- Stat ----
    public class PokemonStat
    {
        public NamedApiResource<Stat> Stat { get; set; }
        public int Effort { get; set; }


        [JsonProperty("base_stat")]
        public int BaseStat { get; set; }
    }

    public class Stat : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "stat";
        public override string Name { get; set; }
        public List<ApiResource<Characteristic>> Characteristics { get; set; }
        public List<Names> Names { get; set; }


        [JsonProperty("game_index")]
        public int GameIndex { get; set; }


        [JsonProperty("is_battle_only")]
        public bool IsBattleOnly { get; set; }


        [JsonProperty("affecting_moves")]
        public MoveStatAffectSets AffectingMoves { get; set; }


        [JsonProperty("affecting_natures")]
        public NatureStatAffectSets AffectingNatures { get; set; }


        [JsonProperty("move_damage_class")]
        public NamedApiResource<MoveDamageClass> MoveDamageClass { get; set; }
    }

    public class Characteristic : ApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "characteristic";

        // Description dans differents languages
        public List<Descriptions> Descriptions { get; set; }


        [JsonProperty("gene_modulo")]
        public int GeneModulo { get; set; }


        [JsonProperty("possible_values")]
        public List<int> PossibleValues { get; set; }


        [JsonProperty("highest_stat")]
        public NamedApiResource<Stat> HighestStat { get; set; }
    }

    public class MoveStatAffectSets
    {
        public List<MoveStatAffect> Increase { get; set; }
        public List<MoveStatAffect> Decrease { get; set; }
    }

    public class MoveStatAffect
    {
        public int Change { get; set; }
        public NamedApiResource<Move> Move { get; set; }
    }


    // ---- Type ----
    public class Type : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "type";
        public override string Name { get; set; }
        public NamedApiResource<Generation> Generation { get; set; }
        public List<Names> Names { get; set; }
        public List<TypePokemon> Pokemon { get; set; }
        public List<NamedApiResource<Move>> Moves { get; set; }


        [JsonProperty("damage_relations")]
        public TypeRelations DamageRelations { get; set; }


        [JsonProperty("game_indices")]
        public List<GenerationGameIndex> GameIndices { get; set; }


        [JsonProperty("move_damage_class")]
        public NamedApiResource<MoveDamageClass> MoveDamageClass { get; set; }
    }

    public class PokemonType
    {
        public int Slot { get; set; }
        public NamedApiResource<Type> Type { get; set; }
    }

    public class TypePokemon
    {
        public int Slot { get; set; }
        public NamedApiResource<Pokemon> Pokemon { get; set; }
    }

    public class TypeRelations
    {
        [JsonProperty("no_damage_to")]
        public List<NamedApiResource<Type>> NoDamageTo { get; set; }


        [JsonProperty("half_damage_to")]
        public List<NamedApiResource<Type>> HalfDamageTo { get; set; }


        [JsonProperty("double_damage_to")]
        public List<NamedApiResource<Type>> DoubleDamageTo { get; set; }


        [JsonProperty("no_damage_from")]
        public List<NamedApiResource<Type>> NoDamageFrom { get; set; }


        [JsonProperty("half_damage_from")]
        public List<NamedApiResource<Type>> HalfDamageFrom { get; set; }


        [JsonProperty("double_damage_from")]
        public List<NamedApiResource<Type>> DoubleDamageFrom { get; set; }
    }


    // ---- Held Item ----
    public class PokemonHeldItem
    {
        public NamedApiResource<Item> Item { get; set; }


        [JsonProperty("version_details")]
        public List<PokemonHeldItemVersion> VersionDetails { get; set; }
    }

    public class PokemonHeldItemVersion
    {
        public NamedApiResource<Version> Version { get; set; }
        public int Rarity { get; set; }
    }






    // ---- Gender ----


    public class Gender : NamedApiResource
    {

        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "gender";
        public override string Name { get; set; }


        [JsonProperty("pokemon_species_details")]
        public List<PokemonSpeciesGender> PokemonSpeciesDetails { get; set; }


        [JsonProperty("required_for_evolution")]
        public List<NamedApiResource<PokemonSpecies>> RequiredForEvolution { get; set; }
    }

    public class PokemonSpeciesGender
    {
        public int Rate { get; set; }


        [JsonProperty("pokemon_species")]
        public NamedApiResource<PokemonSpecies> PokemonSpecies { get; set; }
    }

    // ---- Misc ----

    public class GrowthRateExperienceLevel
    {
        public int Level { get; set; }
        public int Experience { get; set; }
    }

    public class Nature : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "nature";
        public override string Name { get; set; }
        public List<Names> Names { get; set; }


        [JsonProperty("decreased_stat")]
        public NamedApiResource<Stat> DecreasedStat { get; set; }


        [JsonProperty("increased_stat")]
        public NamedApiResource<Stat> IncreasedStat { get; set; }


        [JsonProperty("hates_flavor")]
        public NamedApiResource<BerryFlavor> HatesFlavor { get; set; }


        [JsonProperty("likes_flavor")]
        public NamedApiResource<BerryFlavor> LikesFlavor { get; set; }


        [JsonProperty("pokeathlon_stat_changes")]
        public List<NatureStatChange> PokeathlonStatChanges { get; set; }


        [JsonProperty("move_battle_style_preferences")]
        public List<MoveBattleStylePreference> MoveBattleStylePreferences { get; set; }
    }

    public class NatureStatChange
    {
        [JsonProperty("max_changes")]
        public int MaxChange { get; set; }


        [JsonProperty("pokeathlon_stat")]
        public NamedApiResource<PokeathlonStat> PokeathlonStat { get; set; }
    }

    public class MoveBattleStylePreference
    {
        [JsonProperty("low_hp_preference")]
        public int LowHpPreference { get; set; }


        [JsonProperty("high_hp_preference")]
        public int HighHpPreference { get; set; }


        [JsonProperty("move_battle_style")]
        public NamedApiResource<MoveBattleStyle> MoveBattleStyle { get; set; }
    }

    public class PokeathlonStat : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "pokeathlon-stat";
        public override string Name { get; set; }
        public List<Names> Names { get; set; }


        [JsonProperty("affecting_natures")]
        public NaturePokeathlonStatAffectSets AffectingNatures { get; set; }
    }

    public class NaturePokeathlonStatAffectSets
    {
        public List<NaturePokeathlonStatAffect> Increase { get; set; }
        public List<NaturePokeathlonStatAffect> Decrease { get; set; }
    }

    public class NaturePokeathlonStatAffect
    {
        public NamedApiResource<Nature> Nature { get; set; }


        [JsonProperty("max_change")]
        public int MaxChange { get; set; }
    }

    public class LocationAreaEncounter
    {
        [JsonProperty("location_area")]
        public NamedApiResource<LocationArea> LocationArea { get; set; }


        [JsonProperty("version_details")]
        public List<VersionEncounterDetail> VersionDetails { get; set; }
    }

    public class AwesomeNames
    {
        public NamedApiResource<Language> Language { get; set; }


        [JsonProperty("awesome_name")]
        public string AwesomeName { get; set; }
    }

    public class NatureStatAffectSets
    {
        public List<NamedApiResource<Nature>> Increase { get; set; }
        public List<NamedApiResource<Nature>> Decrease { get; set; }
    }

}
