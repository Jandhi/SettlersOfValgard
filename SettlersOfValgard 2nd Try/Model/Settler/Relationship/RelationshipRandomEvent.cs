using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.Model.Event;
using SettlersOfValgard.Model.Event.Option;
using SettlersOfValgard.Model.Rank;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Relationship
{
    public abstract class RelationshipRandomEvent : RandomEvent
    {
        public Relationship Relationship { get; set; }
        
        public override bool IsAvailable(Settlement.Settlement settlement)
        {
            return settlement.SettlerManager.Relationships.Any(IsPossibleRelationship) 
                   && settlement.Rank >= MinRank 
                   && settlement.Rank <= MaxRank;
        }
        
        public virtual PlayerRank MinRank => PlayerRank.Freeman;
        public virtual PlayerRank MaxRank => PlayerRank.Konungr;

        public abstract bool IsPossibleRelationship(Relationship relationship);
        
        public override void PreExecute(Settlement.Settlement settlement)
        {
            FindRelationship(settlement);
        }
        
        private void FindRelationship(Settlement.Settlement settlement)
        {
            Relationship = RandomUtil.Get(settlement.SettlerManager.Relationships.Where(IsPossibleRelationship).ToArray());
        }
    }
}