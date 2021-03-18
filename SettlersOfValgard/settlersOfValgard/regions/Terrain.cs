using System.Collections.Generic;
using SettlersOfValgard.Game.Resources;
using SettlersOfValgardGame.ui.console.color;
using SettlersOfValgardGame.ui.console.text;
using SettlersOfValgardGame.ui.models;

namespace SettlersOfValgardGame.settlersOfValgard.regions
{
    public class Terrain : NamedObject, IDescribed
    {
        public Terrain(string nameText, VColor nameForeground, VText description, Dictionary<Resource, int> gatherTable)
        {
            NameText = nameText;
            NameForeground = nameForeground;
            Description = description;
            GatherTable = gatherTable;
        }

        public override string NameText { get; }
        public override VColor NameForeground { get; }
        public VText Description { get; }
        public Dictionary<Resource, int> GatherTable { get; }
    }
}