using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Relationship
{
    public class RelationshipRole : CustomEnum<RelationshipRole>
    {
        public static RelationshipRole[] Roles =
        {
            AcquaintanceRelationship.Acquaintance, LoverRelationship.Lover, MarriedRelationship.Partner,
            ParentChildRelationship.Parent, ParentChildRelationship.Child, SiblingRelationship.Sibling
        };
        public RelationshipRole(string name, int value, string color) : base(name, value, color) {}
        public override RelationshipRole[] Values => Roles;
    }
}