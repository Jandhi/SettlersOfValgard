using System.Linq;
using SettlersOfValgard.Model.Settler.Gender;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Relationship
{
    public class MarriedRelationship : Relationship
    {
        public static readonly RelationshipRole Partner = new RelationshipRole("Partner", 'r', CustomConsole.DarkGreen);
        public static readonly RelationshipRole Husband = new RelationshipRole("Husband", Partner.Value, CustomConsole.Cyan);
        public static readonly RelationshipRole Wife = new RelationshipRole("Wife", Partner.Value, CustomConsole.Magenta);
        private MarriedRelationship(SettlerManager sm, int value, Settler partner1, Settler partner2) : base(sm, value, partner1, GetMarriedRole(partner1), partner2, GetMarriedRole(partner2))
        {
            //Remove prior loverRelationship
            var loverRelationship =
                partner1.Relationships.FirstOrDefault(rel => rel is LoverRelationship love && love.Contains(partner2));
            if (loverRelationship != null)
            {
                partner1.Relationships.Remove(loverRelationship);
                partner2.Relationships.Remove(loverRelationship);
            }
        }

        public static RelationshipRole GetMarriedRole(Settler settler)
        {
            if (settler is IGendered<BinaryGender> binaryGenderedSettler)
            {
                if (binaryGenderedSettler.Gender == BinaryGender.Male) return Husband;
                if (binaryGenderedSettler.Gender == BinaryGender.Female) return Wife;
                return Partner;
            }

            return Partner;
        }

        public static void Make(SettlerManager sm, int value, Settler settler1, Settler settler2)
        {
            new MarriedRelationship(sm, value, settler1, settler2);
        }
    }
}