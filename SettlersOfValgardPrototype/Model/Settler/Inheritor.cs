using System;
using System.Collections.Generic;
using System.Linq;
using SettlersOfValgard.Model.Settler.Relationship;
using SettlersOfValgard.Model.Settler.Traits;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler
{
    public abstract class Inheritor : Settler
    {
        public List<Settler> Parents
        {
            get
            {
                return Relationships.Where(rel => rel is ParentChildRelationship pcr && pcr.Role(this) == ParentChildRelationship.Child).Select(relationship => relationship.Other(this)).ToList();
            }
        }

        public static void GenerateChildTraits(Human child)
        {
            List<Settler> parents = new List<Settler>();
            foreach (var relationship in child.Relationships)
            {
                if (relationship is ParentChildRelationship pcr && pcr.Role(child) == ParentChildRelationship.Child)
                {
                    parents.Add(pcr.Other(child));
                }
            }

            var badRelationshipParents = parents.Where(parent =>
                child.Relationships
                    .FirstOrDefault(rel => rel is ParentChildRelationship pcr && pcr.Other(parent) == child)?.Level <=
                RelationshipLevel.Dislike).ToList();

            foreach (var trait in Trait.Traits)
            {
                var parentsTraitsArray = parents.ToArray().Select(parent => parent.Traits[trait].Value).ToArray();
                
                if (badRelationshipParents.Count > 0 && RandomUtil.Chance(1, 3))
                {
                    var parent = RandomUtil.Get(badRelationshipParents);
                    var level = parent.Traits[trait];

                    if (level == TraitLevel.Average) //Reaction goes extreme
                    {
                        child.Traits[trait] = RandomUtil.Get(new[]
                            {TraitLevel.VeryLow, TraitLevel.Low, TraitLevel.High, TraitLevel.VeryHigh});
                    } 
                    else if (level == TraitLevel.AboveAverage) // Reaction goes extreme, more down
                    {
                        child.Traits[trait] = RandomUtil.Get(new[]
                            {TraitLevel.VeryLow, TraitLevel.Low, TraitLevel.VeryHigh});
                    }
                    else if (level == TraitLevel.BelowAverage)
                    {
                        child.Traits[trait] = RandomUtil.Get(new[]
                            {TraitLevel.VeryLow, TraitLevel.High, TraitLevel.VeryHigh});
                    } else if (level >= TraitLevel.High)
                    {
                        child.Traits[trait] = RandomUtil.Get(new[] {TraitLevel.VeryLow, TraitLevel.Low, TraitLevel.BelowAverage});
                    }
                    else
                    {
                        child.Traits[trait] = RandomUtil.Get(new[] {TraitLevel.AboveAverage, TraitLevel.High, TraitLevel.VeryHigh});
                    }
                }
                else
                {
                    var baseLevel = TraitLevel.Average.Get(MathUtil.RoundTowardsZero(MathUtil.UnroundedAverage(parentsTraitsArray)));

                    if (RandomUtil.CoinFlip()) //Drift
                    {
                        if (baseLevel == TraitLevel.VeryLow || baseLevel <= TraitLevel.High && RandomUtil.CoinFlip())
                        {
                            baseLevel = baseLevel.Get(baseLevel.Value + 1);
                        } 
                        else
                        {
                            baseLevel = baseLevel.Get(baseLevel.Value - 1);
                        }
                    } 

                    child.Traits[trait] = baseLevel as TraitLevel;
                }
            }
            
            TraitGenerator.EnsureMajorTrait(child);
        }
    }
}