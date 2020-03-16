using System;
using SettlersOfValgard.Model.Name;
using SettlersOfValgard.Model.Settler;
using SettlersOfValgard.Model.Time;

namespace SettlersOfValgard.Model.Varsk
{
    public class VarskFactory : ISettlerFactory
    {
        public Settler.Settler Generate()
        {
            int age = (new Random().Next(Varsk.VarskElderYears) + Varsk.VarskAdultYears) * Date.DaysInYear;
            bool isMale = new Random().Next(2) == 0;
            NameFactory name = isMale ? VarskNameFactories.Male() : VarskNameFactories.Female();
            return new Varsk(new Date(-1 * age), name.Generate(), $"{VarskNameFactories.Male().Generate()}sson");
        }
        
        public Settler.Settler Generate(bool isMale)
        {
            int age = (new Random().Next(Varsk.VarskElderYears) + Varsk.VarskAdultYears) * Date.DaysInYear;
            NameFactory name = isMale ? VarskNameFactories.Male() : VarskNameFactories.Female();
            return new Varsk(new Date(-1 * age), name.Generate(), $"{VarskNameFactories.Male().Generate()}sson");
        }

        public Settler.Settler GenerateChild(Varsk father, Varsk mother)
        {
            int minParentAge = Math.Min(-1 * father.Birthday.DaysSinceSettlement, -1 * mother.Birthday.DaysSinceSettlement);
            int age = new Random().Next(minParentAge - Varsk.VarskAdultYears * Date.DaysInYear);
            bool isMale = new Random().Next(2) == 0;
            NameFactory name = isMale ? VarskNameFactories.Male() : VarskNameFactories.Female();
            return new Varsk(new Date(-1 * age), name.Generate(), $"{father.GivenName}sson");
        }
    }
}