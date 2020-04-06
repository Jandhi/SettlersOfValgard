using System;
using SettlersOfValgard.Model.Resource.Food;
using SettlersOfValgard.Model.Resource.Material;
using SettlersOfValgard.Model.Settler.Relationship;
using SettlersOfValgard.View;

namespace SettlersOfValgard
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            new Game().Execute();
        }
    }
}