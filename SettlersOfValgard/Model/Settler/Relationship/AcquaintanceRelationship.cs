using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Relationship
{
    public class AcquaintanceRelationship : Relationship
    {
        public static readonly RelationshipRole Acquaintance = new RelationshipRole("Acquaintance", 0, CustomConsole.Cyan);
        
        private AcquaintanceRelationship(int value, Settler settler1, Settler settler2) : base(value, settler1, Acquaintance, settler2, Acquaintance)
        {}

        public static void Make (int value, Settler settler1, Settler settler2)
        {
            new AcquaintanceRelationship(value, settler1, settler2);
        }
    }
}