namespace SettlersOfValgard.resource
{
    public enum ResourceType
    {
        Material,
        Food
    }

    public class Resource : INamed
    {
        private Resource(string name, ResourceType type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; }
        public ResourceType Type { get;  }

        public static Resource Wood { get; } = new Resource("Wood", ResourceType.Material);
        public static Resource Meat { get; } = new Resource("Meat", ResourceType.Food);
    }
}