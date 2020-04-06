using System;
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
        
        public static bool operator == (CustomEnum obj1, CustomEnum obj2)
        {
            if (obj1 is null)
            {
                return obj2 is null;
            }

            if (obj2 is null) return false;
            
            return obj1.Value == obj2.Value && obj1.GetType() == obj2.GetType();
        }

        public static bool operator !=(CustomEnum obj1, CustomEnum obj2)
        {
            return !(obj1 == obj2);
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