using System;
using System.Collections.Generic;
using System.Text;
using SettlersOfValgard.Model.Name;

namespace SettlersOfValgard.View.Command
{
    public class Tag : INamed, IDescribed
    {
        public string Name { get; }
        public string Description { get; }
        
        public string Format
        {
            get
            {
                StringBuilder sb = new StringBuilder(Name);
                Arguments.ForEach(arg => sb.Append($" [{arg.Name}]"));
                return sb.ToString();
            }
        }

        public bool Used
        {
            get
            {
                try
                {
                    return Arguments.TrueForAll(arg => arg.IsUsable());
                }
                catch (FormatException f)
                {
                    return false;
                }
            }
        }

        public void Clear()
        {
            foreach (var arg in Arguments)
            {
                arg.Clear();
            }
        }

        public List<Argument.Argument> Arguments;
        
        public Tag(string name, string description)
        {
            Arguments = new List<Argument.Argument>();
            Name = name;
            Description = description;
        }

        public Tag(string name, string description, List<Argument.Argument> arguments)
        {
            Arguments = arguments;
            Description = description;
            Name = name;
        }
    }
}