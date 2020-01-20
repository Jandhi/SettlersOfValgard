namespace SettlersOfValgard.building
{
    public abstract class Building : Named
    {
        public string Name { get; }

        protected Building(string name)
        {
            Name = name;
        }
    }
}