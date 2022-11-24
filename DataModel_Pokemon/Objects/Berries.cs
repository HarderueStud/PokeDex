using Newtonsoft.Json;
using System.Collections.Generic;

namespace DataModel
{
    public class Berry : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "berry";
        public override string Name { get; set; }
        public int Size { get; set; }
        public int Smoothness { get; set; }
        public NamedApiResource<BerryFirmness> Firmness { get; set; }
        public List<BerryFlavorMap> Flavors { get; set; }
        public NamedApiResource<Item> Item { get; set; }


        [JsonProperty("growth_time")]
        public int GrowthTime { get; set; }


        [JsonProperty("max_harvest")]
        public int MaxHarvest { get; set; }


        [JsonProperty("natural_gift_power")]
        public int NaturalGiftPower { get; set; }

        
        [JsonProperty("soil_dryness")]
        public int SoilDryness { get; set; }


        [JsonProperty("natural_gift_type")]
        public NamedApiResource<Type> NaturalGiftType { get; set; }
    }

    public class BerryFlavorMap
    {
        public int Potency { get; set; }
        public NamedApiResource<BerryFlavor> Flavor { get; set; }
    }

    public class BerryFirmness : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "berry-firmness";
        public override string Name { get; set; }
        public List<NamedApiResource<Berry>> Berries { get; set; }
        public List<Names> Names { get; set; }
    }

    public class BerryFlavor : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "berry-flavor";
        public override string Name { get; set; }
        public List<FlavorBerryMap> Berries { get; set; }
        public List<Names> Names { get; set; }


        [JsonProperty("contest_type")]
        public NamedApiResource<ContestType> ContestType { get; set; }
    }

    public class FlavorBerryMap
    {
        public int Potency { get; set; }
        public NamedApiResource<Berry> Berry { get; set; }
    }
}
