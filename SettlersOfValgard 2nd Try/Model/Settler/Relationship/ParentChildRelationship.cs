using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.Model.Settler.Gender;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Relationship
{
    public class ParentChildRelationship : Relationship
    {
        public static readonly RelationshipRole Parent = new RelationshipRole("Parent", 'p', CustomConsole.DarkGreen);
        public static readonly RelationshipRole Father = new RelationshipRole("Father", Parent.Value, CustomConsole.Blue);
        public static readonly RelationshipRole Mother = new RelationshipRole("Mother", Parent.Value, CustomConsole.DarkMagenta);
        
        public static readonly RelationshipRole Child = new RelationshipRole("Child", 'c', CustomConsole.Green);
        public static readonly RelationshipRole Son = new RelationshipRole("Son", Child.Value, CustomConsole.Cyan);
        public static readonly RelationshipRole Daughter = new RelationshipRole("Daughter", Child.Value, CustomConsole.Magenta);

        private ParentChildRelationship(SettlerManager sm, int value, Settler parent, Settler child) : base(sm, value, parent, GetParentRole(parent), child, GetChildRole(child))
        {
            //Add siblings
            var currentSiblings = SiblingRelationship.GetSiblings(child);
            var actualSiblings = GetChildren(parent).Where(c => c != child);
            foreach (var sibling in actualSiblings)
            {
                if (!currentSiblings.Contains(sibling))
                {
                    SiblingRelationship.Make(sm, 0, child, sibling);
                }
            }
        }

        public static void Make(SettlerManager sm, int value, Settler parent, Settler child)
        {
            new ParentChildRelationship(sm, value, parent, child);
        }

        public static RelationshipRole GetParentRole(Settler settler)
        {
            if (settler is IGendered<BinaryGender> binaryGenderedSettler)
            {
                if (binaryGenderedSettler.Gender == BinaryGender.Male) return Father;
                if (binaryGenderedSettler.Gender == BinaryGender.Female) return Mother;
                return Parent;
            }

            return Parent;
        }
        
        public static RelationshipRole GetChildRole(Settler settler)
        {
            if (settler is IGendered<BinaryGender> binaryGenderedSettler)
            {
                if (binaryGenderedSettler.Gender == BinaryGender.Male) return Son;
                if (binaryGenderedSettler.Gender == BinaryGender.Female) return Daughter;
                return Child;
            }

            return Child;
        }

        public static List<Settler> GetChildren(Settler settler)
        {
            var children = new List<Settler>();
            foreach (var relationship in settler.Relationships)
            {
                if (relationship is ParentChildRelationship parentChildRelationship && parentChildRelationship.Role(settler) == Parent)
                {
                    children.Add(parentChildRelationship.Other(settler));
                }
            }

            return children;
        }
        
        public static List<Settler> GetParents(Settler settler)
        {
            var parents = new List<Settler>();
            foreach (var relationship in settler.Relationships)
            {
                if (relationship is ParentChildRelationship parentChildRelationship && parentChildRelationship.Role(settler) == Child)
                {
                    parents.Add(parentChildRelationship.Other(settler));
                }
            }

            return parents;
        }
    }
}