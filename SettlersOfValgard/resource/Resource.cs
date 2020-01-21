using System;

namespace SettlersOfValgard.resource
{
    public enum ResourceCategory
    {
        Material,
        Food
    }

    public class Resource : INamed
    {
        private Resource(string name, ResourceCategory category, ConsoleColor color)
        {
            Name = name;
            Category = category;
            Color = color;
        }

        public string Name { get; }
        public ConsoleColor Color { get; }
        public ResourceCategory Category { get;  }

        public static Resource Wood { get; } = new Resource("Wood", ResourceCategory.Material, ConsoleColor.DarkGreen);
        public static Resource Meat { get; } = new Resource("Meat", ResourceCategory.Food, ConsoleColor.Red);

        public override string ToString()
        {
            return Console.Color(Name, Color);
        }
    }
}