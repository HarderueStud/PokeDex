namespace DataModel
{
    // Va être utile pour le cache avec leurs ID
    public abstract class ResourceBase
    {
        public abstract int Id { get; set; }
        public static string ApiEndpoint { get; }
    }

    public abstract class NamedApiResource : ResourceBase
    {
        public abstract string Name { get; set; }
    }
    public abstract class ApiResource : ResourceBase { }
}
