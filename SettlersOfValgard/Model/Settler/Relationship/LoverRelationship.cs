using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Relationship
{
    public class LoverRelationship : Relationship
    {
        public static readonly RelationshipRole Lover = new RelationshipRole("Lover", 'l', CustomConsole.Magenta);
        
        private LoverRelationship(int value, Settler lover1, Settler lover2) : base(value, lover1, Lover, lover2, Lover)
        {
        }

        public static void Make(int value, Settler lover1, Settler lover2)
        {
            new LoverRelationship(value, lover1, lover2);
        }
    }
}