using System;
using SettlersOfValgard.Old.settler;

namespace SettlersOfValgard.settler
{
    public class SettlerFactory
    {
        private const int MaxAge = 100;

        public static Settler Get()
        {
            NameFactory fac = new VarskNameFactory();
            var years = getAge();
            var gender = (Gender) Random.Weighted(SettlementSettings.GenderWeights);
            return new Settler(fac.GetSettlerName(gender, years), years, gender);
        }

        private static int getAge()
        {
            var lifeStage = Random.Next(10);
            if (lifeStage < 2)
                return Random.Next(Settler.AdultAge);
            if (lifeStage < 9)
                return Random.Next(Settler.ElderAge - Settler.AdultAge) + Settler.AdultAge;
            return (int) Math.Sqrt(Random.Next((int) Math.Pow(MaxAge - Settler.ElderAge, 2))) + Settler.ElderAge;
        }
    }
}