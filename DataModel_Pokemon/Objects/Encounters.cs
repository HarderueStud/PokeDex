using System.Collections.Generic;

namespace DataModel
{
    public class EncounterMethod : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "encounter-method";
        public override string Name { get; set; }
        public int Order { get; set; }
        public List<Names> Names { get; set; }
    }

    public class EncounterCondition : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "encounter-condition";
        public override string Name { get; set; }
        public List<Names> Names { get; set; }
        public List<NamedApiResource<EncounterConditionValue>> Values { get; set; }
    }

    public class EncounterConditionValue : NamedApiResource
    {
        public override int Id { get; set; }
        internal new static string ApiEndpoint { get; } = "encounter-condition-value";
        public override string Name { get; set; }
        public NamedApiResource<EncounterCondition> Condition { get; set; }
        public List<Names> Names { get; set; }
    }
}
