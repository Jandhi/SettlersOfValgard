using System.Collections.Generic;
using SettlersOfValgardGame.settlersOfValgard.resources;
using SettlersOfValgardGame.settlersOfValgard.resources.storage;
using SettlersOfValgardGame.ui.console;
using SettlersOfValgardGame.ui.console.color;
using SettlersOfValgardGame.ui.console.text;
using SettlersOfValgardGame.ui.models;

namespace SettlersOfValgardGame.settlersOfValgard.terrain
{
    public class Terrain : NamedObject, IDescribed
    {
        public static readonly Terrain Forest = new Terrain("Forest", VColor.Woods, VConsole.Text("A wooded area"), 
            (new Bundle((Material.Wood, 1)), 1));
        
        public static readonly Terrain Meadow = new Terrain("Meadow", VColor.Chartreuse, VConsole.Text("An open grassland"), 
            (new Bundle((Material.Wood, 1)), 1),
            (new Bundle((Material.Herbs, 1)), 1));
        
        public static readonly Terrain River = new Terrain("River", VColor.Wind, VConsole.Text("An flowing river"), 
            (new Bundle((Food.Fish, 1)), 1));
        
        public static readonly Terrain Lake = new Terrain("Lake", VColor.Lake, VConsole.Text("A lovely lake"),
            (new Bundle((Food.Fish, 1)), 1));
        
        public Terrain(string nameText, VColor nameForeground, VText description, List<(Bundle, int)> gatherTable)
        {
            NameText = nameText;
            NameForeground = nameForeground;
            Description = description;
            GatherTable = gatherTable;
        }
        
        public Terrain(string nameText, VColor nameForeground, VText description, params (Bundle, int)[] gatherables) :
            this(nameText, nameForeground, description, new List<(Bundle, int)>(gatherables))
        {
        }

        public override string NameText { get; }
        public override VColor NameForeground { get; }
        public VText Description { get; }
        public List<(Bundle, int)> GatherTable { get; }
    }
}