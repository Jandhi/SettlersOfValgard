using System;
using SettlersOfValgard.Model.Settler;
using SettlersOfValgard.Model.Settler.Relationship;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.Model.Varsk
{
    public class VarskFamilyFactory : IFamilyFactory
    {
        private VarskFactory _factory;
        private SettlerManager _manager;

        public VarskFamilyFactory(SettlerManager manager)
        {
            _manager = manager;
            _factory = new VarskFactory(manager);
        }

        public Family Generate()
        {
            //Generate parents
            Varsk father = _factory.GenerateParent(true) as Varsk;
            Varsk mother = _factory.GenerateParent(false) as Varsk;

            //Generate family
            Family family = new Family($"{(father.PrestigeLevel >= mother.PrestigeLevel ? father.GivenName : mother.GivenName)}sson");
            family.AddMember(father);
            family.AddMember(mother);
            
            MarriedRelationship.Make(_manager, 15, father, mother);
            //Generate kids
            var children = new Random().Next(5);
            for(var i = 0; i < children; i++) family.AddMember(_factory.GenerateChild(father, mother));
            return family;
        }
    }
}