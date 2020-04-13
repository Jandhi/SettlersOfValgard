using System;
using SettlersOfValgard.Model.Settler;
using SettlersOfValgard.Model.Settler.Relationship;

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
            Family family = new Family();
            //Generate parents
            Varsk father = _factory.GenerateParent(true) as Varsk;
            family.Members.Add(father);
            Varsk mother = _factory.GenerateParent(false) as Varsk;
            family.Members.Add(mother);
            MarriedRelationship.Make(_manager, 15, father, mother);
            //Generate kids
            var children = new Random().Next(5);
            for(var i = 0; i < children; i++) family.Members.Add(_factory.GenerateChild(father, mother));
            return family;
        }
    }
}