using System;
using SettlersOfValgard.Model.Settler;

namespace SettlersOfValgard.Model.Varsk
{
    public class VarskFamilyFactory : IFamilyFactory
    {
        private VarskFactory _factory = new VarskFactory();
        
        public Family Generate()
        {
            Family family = new Family();
            //Generate parents
            Varsk father = _factory.Generate(true) as Varsk;
            family.Members.Add(father);
            Varsk mother = _factory.Generate(false) as Varsk;
            family.Members.Add(mother);
            //Generate kids
            int children = new Random().Next(5);
            for(int i = 0; i < children; i++) family.Members.Add(_factory.GenerateChild(father, mother));
            return family;
        }
    }
}