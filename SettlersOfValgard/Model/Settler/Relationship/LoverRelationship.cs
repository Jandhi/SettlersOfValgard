using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Relationship
{
    public class LoverRelationship : Relationship
    {
        public static readonly RelationshipRole Lover = new RelationshipRole("Lover", 'l', CustomConsole.Magenta);
        
        private LoverRelationship(SettlerManager sm, int value, Settler lover1, Settler lover2) : base(sm, value, lover1, Lover, lover2, Lover)
        {
        }

        public static void Make(SettlerManager sm, int value, Settler lover1, Settler lover2)
        {
            new LoverRelationship(sm, value, lover1, lover2);
        }
    }
}