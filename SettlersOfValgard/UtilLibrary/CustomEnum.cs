using SettlersOfValgard.Model.Name;

namespace SettlersOfValgard.UtilLibrary
{
    public abstract class CustomEnum : INamed
    {
        public string Name { get; }
        public int Value { get; }
        public string Color { get; }

        protected CustomEnum(string name, int value, string color)
        {
            Name = name;
            Value = value;
            Color = color;
        }
        
        public static bool operator <(CustomEnum obj1, CustomEnum obj2)
        {
            return obj1.Value < obj2.Value;
        }

        public static bool operator >(CustomEnum obj1, CustomEnum obj2)
        {
            return obj1.Value > obj2.Value;
        }

        public static bool operator >=(CustomEnum obj1, CustomEnum obj2)
        {
            return obj1.Value >= obj2.Value;
        }

        public static bool operator <=(CustomEnum obj1, CustomEnum obj2)
        {
            return obj1.Value <= obj2.Value;
        }

        public override string ToString()
        {
            return $"{Color}{Name}{CustomConsole.White}";
        }
    }
}