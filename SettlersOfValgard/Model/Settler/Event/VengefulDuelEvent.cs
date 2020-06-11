using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.Model.Event;
using SettlersOfValgard.Model.Event.Option;
using SettlersOfValgard.Model.Settler.Gender;
using SettlersOfValgard.Model.Settler.Relationship;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Event
{
    public class VengefulDuelEvent : RelationshipRandomEvent
    {
        public override string Name => "A Vengeful Duel";

        public override string Description => $"{Challenger} has challenged {Relationship.Other(Challenger)} to a duel!";

        public override EventRarity Rarity => EventRarity.Common;
        public Settler Challenger { get; set; }

        public override List<EventOption> Options
        {
            get
            {
                var list = new List<EventOption>
                {
                    new EventOption("Let them fight", settlement =>
                    {
                        var winner = RandomUtil.CoinFlip() ? Relationship.Settler1 : Relationship.Settler2;
                        CustomConsole.WriteLine($"{winner} won!");
                    }),
                    new EventOption("Prevent them from fighting", settlement =>
                    {
                        CustomConsole.WriteLine("They are grumpy.");
                    }),
                };
                return list;
            }
        }
        
        public override void PreExecute(Settlement.Settlement settlement)
        {
            base.PreExecute(settlement);
            Challenger = RandomUtil.CoinFlip() ? Relationship.Settler1 : Relationship.Settler2;
        }

        public override bool IsPossibleRelationship(Relationship.Relationship relationship)
        {
            if (relationship.Level > RelationshipLevel.Hate) return false; //Only possible if they hate each other

            if (!(relationship.Settler1 is IGendered<BinaryGender> settler1) ||
                !(relationship.Settler2 is IGendered<BinaryGender> settler2)) return false; //Currently only possible for males
            
            return settler1.Gender == BinaryGender.Male && settler2.Gender == BinaryGender.Male; 
        } 
    }
}