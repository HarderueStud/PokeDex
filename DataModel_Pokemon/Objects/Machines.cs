using Newtonsoft.Json;

namespace DataModel
{
    public class Machine : ApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "machine";
        public NamedApiResource<Item> Item { get; set; }


        public NamedApiResource<Move> Move { get; set; }


        [JsonProperty("version_group")]
        public NamedApiResource<VersionGroup> VersionGroup { get; set; }
    }
}
