using Newtonsoft.Json;
using System.Collections.Generic;

namespace DataModel
{
    public class Move : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "move";
        public override string Name { get; set; }
        public int? Accuracy { get; set; }
        public int? Pp { get; set; }
        public int Priority { get; set; }
        public int? Power { get; set; }
        public NamedApiResource<Generation> Generation { get; set; }
        public List<MachineVersionDetail> Machines { get; set; }
        public MoveMetaData Meta { get; set; }
        public List<Names> Names { get; set; }
        public NamedApiResource<MoveTarget> Target { get; set; }
        public NamedApiResource<Type> Type { get; set; }


        [JsonProperty("effect_chance")]
        public int? EffectChance { get; set; }


        [JsonProperty("contest_combos")]
        public ContestComboSets ContestCombos { get; set; }


        [JsonProperty("contest_type")]
        public NamedApiResource<ContestType> ContestType { get; set; }


        [JsonProperty("contest_effect")]
        public ApiResource<ContestEffect> ContestEffect { get; set; }


        [JsonProperty("damage_class")]
        public NamedApiResource<MoveDamageClass> DamageClass { get; set; }


        [JsonProperty("effect_entries")]
        public List<VerboseEffect> EffectEntries { get; set; }


        [JsonProperty("effect_changes")]
        public List<AbilityEffectChange> EffectChanges { get; set; }


        [JsonProperty("flavor_text_entries")]
        public List<MoveFlavorText> FlavorTextEntries { get; set; }


        [JsonProperty("past_values")]
        public List<PastMoveStatValues> PastValues { get; set; }


        [JsonProperty("stat_changes")]
        public List<MoveStatChange> StatChanges { get; set; }


        [JsonProperty("super_contest_effect")]
        public ApiResource<SuperContestEffect> SuperContestEffect { get; set; }
    }

    public class ContestComboSets
    {
        public ContestComboDetail Normal { get; set; }
        public ContestComboDetail Super { get; set; }
    }

    public class ContestComboDetail
    {
        [JsonProperty("use_before")]
        public List<NamedApiResource<Move>> UseBefore { get; set; }


        [JsonProperty("use_after")]
        public List<NamedApiResource<Move>> UseAfter { get; set; }
    }

    public class MoveFlavorText
    {
        public NamedApiResource<Language> Language { get; set; }


        [JsonProperty("flavor_text")]
        public string FlavorText { get; set; }


        [JsonProperty("version_group")]
        public NamedApiResource<VersionGroup> VersionGroup { get; set; }
    }

    public class MoveMetaData
    {
        public NamedApiResource<MoveAilment> Ailment { get; set; }
        public NamedApiResource<MoveCategory> Category { get; set; }
        public int Drain { get; set; }
        public int Healing { get; set; }


        [JsonProperty("min_hits")]
        public int? MinHits { get; set; }


        [JsonProperty("max_hits")]
        public int? MaxHits { get; set; }


        [JsonProperty("min_turns")]
        public int? MinTurns { get; set; }


        [JsonProperty("max_turns")]
        public int? MaxTurns { get; set; }


        [JsonProperty("crit_rate")]
        public int CritRate { get; set; }


        [JsonProperty("ailment_chance")]
        public int AilmentChance { get; set; }


        [JsonProperty("flinch_chance")]
        public int FlinchChance { get; set; }


        [JsonProperty("stat_chance")]
        public int StatChance { get; set; }
    }

    public class MoveStatChange
    {
        public int Change { get; set; }
        public NamedApiResource<Stat> Stat { get; set; }
    }

    public class PastMoveStatValues
    {
        public int? Accuracy { get; set; }
        public int? Power { get; set; }
        public int? Pp { get; set; }
        public NamedApiResource<Type> Type { get; set; }


        [JsonProperty("effect_chance")]
        public int? EffectChance { get; set; }


        [JsonProperty("effect_entries")]
        public List<VerboseEffect> EffectEntries { get; set; }


        [JsonProperty("version_group")]
        public NamedApiResource<VersionGroup> VersionGroup { get; set; }
    }

    public class MoveAilment : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "move-ailment";
        public override string Name { get; set; }
        public List<NamedApiResource<Move>> Moves { get; set; }
        public List<Names> Names { get; set; }
    }

    public class MoveBattleStyle : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "move-battle-style";
        public override string Name { get; set; }
        public List<Names> Names { get; set; }
    }

    public class MoveCategory : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "move-category";
        public override string Name { get; set; }
        public List<NamedApiResource<Move>> Moves { get; set; }
        public List<Descriptions> Descriptions { get; set; }
    }

    public class MoveDamageClass : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "move-damage-class";
        public override string Name { get; set; }
        public List<NamedApiResource<Move>> Moves { get; set; }
        public List<Descriptions> Descriptions { get; set; }
        public List<Names> Names { get; set; }
    }

    public class MoveLearnMethod : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "move-learn-method";
        public override string Name { get; set; }
        public List<Descriptions> Descriptions { get; set; }
        public List<Names> Names { get; set; }


        [JsonProperty("version_groups")]
        public List<NamedApiResource<VersionGroup>> VersionGroups { get; set; }
    }

    public class MoveTarget : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "move-target";
        public override string Name { get; set; }
        public List<Descriptions> Descriptions { get; set; }
        public List<NamedApiResource<Move>> Moves { get; set; }
        public List<Names> Names { get; set; }
    }
}
