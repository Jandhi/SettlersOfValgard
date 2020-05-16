using System;
using SettlersOfValgard.Model.Name;
using SettlersOfValgard.Model.Settler;
using SettlersOfValgard.Model.Settler.Gender;
using SettlersOfValgard.Model.Settler.Relationship;
using SettlersOfValgard.Model.Settler.Traits;
using SettlersOfValgard.Model.Time;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Varsk
{
    public class VarskFactory : ISettlerFactory
    {
        private readonly SettlerManager _manager;

        public VarskFactory(SettlerManager manager)
        {
            _manager = manager;
        }

        public Settler.Settler Generate()
        {
            return Generate(new Random().Next(2) == 0);
        }
        
        public Settler.Settler Generate(bool isMale)
        {
            int age = (new Random().Next(Varsk.VarskElderYears) + Varsk.VarskAdultYears) * Date.DaysInYear;
            NameFactory name = isMale ? VarskNameFactories.Male() : VarskNameFactories.Female();
            var settler = new Varsk(new Date(-1 * age), name.Generate(), $"{VarskNameFactories.Male().Generate()}sson", isMale ? BinaryGender.Male : BinaryGender.Female);
            TraitGenerator.GenerateTraits(settler);
            return settler;
        }

        public Settler.Settler GenerateParent(bool isMale)
        {
            int age = (int) (Math.Pow(new Random().NextDouble(), 0.2) * Varsk.VarskElderYears + Varsk.VarskAdultYears) * Date.DaysInYear;
            NameFactory name = isMale ? VarskNameFactories.Male() : VarskNameFactories.Female();
            var settler = new Varsk(new Date(-1 * age), name.Generate(), $"{VarskNameFactories.Male().Generate()}sson", isMale ? BinaryGender.Male : BinaryGender.Female);
            TraitGenerator.GenerateTraits(settler);
            return settler;
        }

        public Settler.Settler GenerateChild(Varsk father, Varsk mother)
        {
            int minParentAge = Math.Min(-1 * father.Birthday.DaysSinceSettlement, -1 * mother.Birthday.DaysSinceSettlement);
            int age = new Random().Next(minParentAge - Varsk.VarskAdultYears * Date.DaysInYear);
            bool isMale = new Random().Next(2) == 0;
            NameFactory name = isMale ? VarskNameFactories.Male() : VarskNameFactories.Female();
            var child = new Varsk(new Date(-1 * age), name.Generate(), $"{(father.PrestigeLevel >= mother.PrestigeLevel ? father.GivenName : mother.GivenName)}sson", isMale ? BinaryGender.Male : BinaryGender.Female);
            ParentChildRelationship.Make(_manager,0, father, child);
            ParentChildRelationship.Make(_manager, 0, mother, child);
            Inheritor.GenerateChildTraits(child);
            return child;
        }
    }
}