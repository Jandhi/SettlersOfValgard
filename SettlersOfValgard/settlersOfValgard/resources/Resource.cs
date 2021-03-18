using System.Collections.Generic;
using SettlersOfValgardGame.settlersOfValgard.resources.storage;
using SettlersOfValgardGame.ui.console.color;
using SettlersOfValgardGame.ui.models;

namespace SettlersOfValgardGame.settlersOfValgard.resources
{
    public abstract class Resource : NamedObject
    {
        public Resource(string nameText, VColor nameForeground, int size)
        {
            NameText = nameText;
            NameForeground = nameForeground;
            Size = size;
            AllResources.Add(this);
        }

        public override string NameText { get; }
        public override VColor NameForeground { get; } 
        public int Size { get; }
        public abstract StorageType StorageType { get; }
        public static List<Resource> AllResources { get; } = new List<Resource>();
    }
}