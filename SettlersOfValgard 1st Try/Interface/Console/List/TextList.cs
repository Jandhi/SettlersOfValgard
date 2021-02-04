using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.Util;

namespace SettlersOfValgard.Interface.Console.List
{
    public class TextList<T> : TextEffect
    {
        private int _count = 1;
        public TextListFormat<T> Format { get; }
        public bool UpdatePreviousList { get; }
        

        public TextList(IEnumerable<T> contents, TextListFormat<T> format = null, bool updatePreviousList = true)
        {
            Contents = contents;
            Format = format ?? new TextListFormat<T>();
            UpdatePreviousList = updatePreviousList;
        }

        public IEnumerable<T> Contents { get; }
        
        public override void Write()
        {
            foreach (var (item, amount) in ProcessContents())
            {
                WriteItem(item, amount);
            }
            if(UpdatePreviousList) VInput.PreviousList = Contents as List<INamed>;
        }

        public Dictionary<T, int> ProcessContents()
        {
            var dictionary = new Dictionary<T, int>();
            foreach (var item in Contents)
            {
                if (!Format.IsGrouped)
                {
                    dictionary.Add(item, 1);
                    continue;
                }
                
                var match = dictionary.Select(pair => pair.Key).FirstOrDefault(t => Format.Func(t) == Format.Func(item));
                if (match != null && !match.Equals(default(T)))
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
            var numberString = Format.IsNumbered ? $"{_count}: " : "";
            var indent = "";
            for (var i = 0; i < Format.Indent; i++) indent += " ";
            VConsole.WriteLine($"{indent}{numberString}{colorString}{Format.Func(item)}{VColor.White}{amountString}");
            _count++;
        }
    }
}