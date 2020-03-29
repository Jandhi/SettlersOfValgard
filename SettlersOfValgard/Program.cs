using System.Collections.Generic;
using SettlersOfValgard.Model.Resource;
using SettlersOfValgard.Model.Resource.Food;
using SettlersOfValgard.Model.Resource.Material;
using SettlersOfValgard.UtilLibrary;
using SettlersOfValgard.View;

namespace SettlersOfValgard
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Resource> list = new List<Resource>(){Food.Grain, Food.Meat, Material.Stone};
            var s = new NamedSearchTree<Resource>(list);
            int i = 3;
            //new Game().Execute();
        }
    }
}