using System;
using System.Linq;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Settler.Traits
{
    public class TraitGenerator
    {
        public static void GenerateTraits(Settler settler)
        {
            foreach (var trait in Trait.Traits)
            {
                settler.Traits[trait] = RandomUtil.WeightedGet(TraitLevel.TraitLevels, TraitLevel.Average, TraitLevel.Weight);
            }
            EnsureMajorTrait(settler);
        }

        public static void EnsureMajorTrait(Settler settler)
        {
            //Always some major trait
            if (Trait.Traits.ToList().TrueForAll(trait => settler.Traits[trait] > TraitLevel.Low && settler.Traits[trait] < TraitLevel.High))
            {
                settler.Traits[RandomUtil.Get(Trait.Traits)] = RandomUtil.Get(new[]
                    {TraitLevel.VeryLow, TraitLevel.Low, TraitLevel.High, TraitLevel.VeryHigh});
            }
        }
    }
}