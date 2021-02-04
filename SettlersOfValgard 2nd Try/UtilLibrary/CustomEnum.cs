using System;
using SettlersOfValgard.Interface.Console;
using SettlersOfValgard.Model.Name;

namespace SettlersOfValgard.UtilLibrary
{
    public abstract class CustomEnum<T> : INamed where T : CustomEnum<T>
    {
        public string Name { get; }
        public int Value { get; }
        public string Color { get; }
        public abstract T[] Values { get; }

        protected CustomEnum(string name, int value, string color)
        {
            Name = name;
            Value = value;
            Color = color;
        }

        public CustomEnum<T> Get(int value)
        {
            foreach (var item in Values)
            {
                if (item.Value == value)
                {
                    return item;
                }
            }

            return default;
        }
        
        public static bool operator == (CustomEnum<T> obj1, CustomEnum<T> obj2)
        {
            if (obj1 is null)
            {
                return obj2 is null;
            }

            if (obj2 is null) return false;
            
            return obj1.Value == obj2.Value && obj1.GetType() == obj2.GetType();
        }

        public static bool operator !=(CustomEnum<T> obj1, CustomEnum<T> obj2)
        {
            return !(obj1 == obj2);
        }

        public static bool operator <(CustomEnum<T> obj1, CustomEnum<T> obj2)
        {
            return obj1.Value < obj2.Value;
        }

        public static bool operator >(CustomEnum<T> obj1, CustomEnum<T> obj2)
        {
            return obj1.Value > obj2.Value;
        }

        public static bool operator >=(CustomEnum<T> obj1, CustomEnum<T> obj2)
        {
            return obj1.Value >= obj2.Value;
        }

        public static bool operator <=(CustomEnum<T> obj1, CustomEnum<T> obj2)
        {
            return obj1.Value <= obj2.Value;
        }

        public override string ToString()
        {
            return $"{Color}{Name}{CustomConsole.White}";
        }
    }
}