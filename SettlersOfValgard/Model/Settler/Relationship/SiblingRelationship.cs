using System.Collections.Generic;
using SettlersOfValgard.Model.Settler.Gender;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Relationship
{
    public class SiblingRelationship : Relationship
    {
        public static readonly RelationshipRole Sibling = new RelationshipRole("Sibling", 's', CustomConsole.Yellow);
        public static readonly RelationshipRole Brother = new RelationshipRole("Brother", Sibling.Value, CustomConsole.Cyan);
        public static readonly RelationshipRole Sister = new RelationshipRole("Sister", Sibling.Value, CustomConsole.Magenta);
        
        private SiblingRelationship(SettlerManager sm, int value, Settler sibling1, Settler sibling2) : base(sm, value, sibling1, GetSiblingRole(sibling1), sibling2, GetSiblingRole(sibling2))
        {
        }

        public static void Make(SettlerManager sm, int value, Settler sibling1, Settler sibling2)
        {
            new SiblingRelationship(sm, 0, sibling1, sibling2);
        }

        public static RelationshipRole GetSiblingRole(Settler s)
        {
            if (s is IGendered<BinaryGender> binaryGenderedSettler)
            {
                if (binaryGenderedSettler.Gender == BinaryGender.Male) return Brother;
                if (binaryGenderedSettler.Gender == BinaryGender.Female) return Sister;
                return Sibling;
            }

            return Sibling;
        }
        
        public static List<Settler> GetSiblings(Settler settler)
        {
            var siblings = new List<Settler>();
            foreach (var relationship in settler.Relationships)
            {
                if (relationship is SiblingRelationship siblingRelationship)
                {
                    siblings.Add(siblingRelationship.Other(settler));
                }
            }

            return siblings;
        }
    }
}