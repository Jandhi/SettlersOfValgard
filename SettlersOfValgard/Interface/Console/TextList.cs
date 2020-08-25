using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.Util;

namespace SettlersOfValgard.Interface.Console
{
    public class TextList<T> : TextEffect where T : INamed
    {
        private int _count = 1;
        public bool IsNumbered { get; }
        public bool IsGrouped { get; }

        public TextList(List<T> contents, bool isNumbered = false, bool isGrouped = true)
        {
            Contents = contents;
            IsNumbered = isNumbered;
            IsGrouped = isGrouped;
        }

        public List<T> Contents { get; }
        
        public override void Write()
        {
            foreach (var (item, amount) in ProcessContents())
            {
                WriteItem(item, amount);
            }
            VInput.PreviousList = Contents as List<INamed>;
        }

        public Dictionary<T, int> ProcessContents()
        {
            var dictionary = new Dictionary<T, int>();
            foreach (var item in Contents)
            {
                if (!IsGrouped)
                {
                    dictionary.Add(item, 1);
                    continue;
                }
                
                var match = dictionary.Select(pair => pair.Key).FirstOrDefault(t => t.Name == item.Name);
                if (match != null)
                {
                    dictionary[match]++;
                }
                else
                {
                    dictionary.Add(item, 1);
                }
            }
            return dictionary;
        }

        private void WriteItem(T item, int amount)
        {
            var colorString = item is IColored colored ? colored.Color : VColor.White;
            var amountString = amount > 1 ? $" x{amount}" : "";
            var numberString = IsNumbered ? $"{_count}: " : "";
            VConsole.WriteLine($"{numberString}{colorString}{item.Name}{VColor.White}{amountString}");
            _count++;
        }
    }
}