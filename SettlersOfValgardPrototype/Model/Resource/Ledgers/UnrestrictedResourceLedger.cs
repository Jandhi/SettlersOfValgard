namespace SettlersOfValgard.Model.Resource
{
    public class UnrestrictedResourceLedger : ResourceLedger
    {
        public virtual void Add(ResourceLedger other)
        {
            foreach (var (resource, amount) in other.Contents)
            {
                if (Contents.ContainsKey(resource))
                { 
                    Contents[resource] += amount;
                }
                else
                {
                    Contents.Add(resource, amount);
                }
            }
        }
    }
}