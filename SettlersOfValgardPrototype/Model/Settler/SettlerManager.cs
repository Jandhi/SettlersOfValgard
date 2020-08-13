using System;
using System.Collections.Generic;

namespace SettlersOfValgard.Model.Settler
{
    public class SettlerManager
    {
        public List<Relationship.Relationship> Relationships { get; } = new List<Relationship.Relationship>();
        public Dictionary<Type, List<Relationship.Relationship>> RelationshipsByType { get; } = new Dictionary<Type, List<Relationship.Relationship>>();
        public List<Settler> Settlers { get; } = new List<Settler>();
        public List<Family> Families { get; } = new List<Family>();
        public List<Settler> Graveyard { get; } = new List<Settler>();

        public void Add(Relationship.Relationship relationship)
        {
            Relationships.Add(relationship);
            if (RelationshipsByType.ContainsKey(relationship.GetType()))
            {
                RelationshipsByType[relationship.GetType()].Add(relationship);
            }
            else
            {
                RelationshipsByType.Add(relationship.GetType(), new List<Relationship.Relationship>{relationship});
            }
        }

        public void Add(Family family)
        {
            Families.Add(family);
            foreach (var member in family.Members)
            {
                member.Setup();
                Settlers.Add(member);
            }
        }

        public void Add(Settler settler)
        {
            settler.Setup();
            Settlers.Add(settler);
            if (!Families.Contains(settler.Family))
            {
                Families.Add(settler.Family);
            }
        }

        public void UpdatePrestige(Settlement.Settlement settlement)
        {
            foreach (var settler in Settlers)
            {
                settler.UpdatePrestige(settlement);
            }
        }
    }
}