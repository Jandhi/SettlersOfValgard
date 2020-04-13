using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.Model.Event;
using SettlersOfValgard.Model.Event.Option;
using SettlersOfValgard.Model.Settler.Gender;
using SettlersOfValgard.Model.Settler.Relationship;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Event
{
    public class VengefulDuelEvent : RandomEvent
    {
        public override string Name => "A Vengeful Duel";

        public override string Description => $"{_challenger} has challenged {_relationship.Other(_challenger)} to a duel!";

        public override EventRarity Rarity => EventRarity.Common;
        private Relationship.Relationship _relationship = null;
        private Settler _challenger = null;

        public override List<EventOption> Options
        {
            get
            {
                var list = new List<EventOption>
                {
                    new EventOption("Let them fight", settlement =>
                    {
                        var winner = RandomUtil.CoinFlip() ? _relationship.Settler1 : _relationship.Settler2;
                        CustomConsole.WriteLine($"{winner} won!");
                    }),
                    new EventOption("Prevent them from fighting",
                        settlement => { CustomConsole.WriteLine("They are grumpy."); })
                };
                return list;
            }
        }

        private void FindRelationship(Settlement.Settlement settlement)
        {
            _relationship = RandomUtil.Get(settlement.SettlerManager.Relationships.Where(IsPossibleRelationship).ToArray());
            _challenger = RandomUtil.CoinFlip() ? _relationship.Settler1 : _relationship.Settler2;
        }

        public override void PreExecute(Settlement.Settlement settlement)
        {
            FindRelationship(settlement);
        }

        public override bool IsAvailable(Settlement.Settlement settlement)
        {
            return settlement.SettlerManager.Relationships.Any(IsPossibleRelationship);
        }

        private static bool IsPossibleRelationship(Relationship.Relationship relationship)
        {
            if (relationship.Level > RelationshipLevel.Hate) return false; //Only possible if they hate each other

            if (!(relationship.Settler1 is IGendered<BinaryGender> settler1) ||
                !(relationship.Settler2 is IGendered<BinaryGender> settler2)) return false; //Currently only possible for males
            
            return settler1.Gender == BinaryGender.Male && settler2.Gender == BinaryGender.Male; 
        } 
    }
}