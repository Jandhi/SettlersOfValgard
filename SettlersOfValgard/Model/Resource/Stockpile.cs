using System.Text;

namespace SettlersOfValgard.Model.Resource
{
    public class Stockpile : Bundle {
        public Resource GetHighestOfType(ResourceType type)
        {
            Resource max = null;
            foreach (var (resource, amount) in Contents)
            {
                if (Contains(resource) && resource.type == type)
                {
                    if (max == null)
                    {
                        max = resource;
                    }
                    else if(Contents[resource] > Contents[max])
                    {
                        max = resource;
                    }
                }
            }

            return max;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            var first = true;
            foreach (var (resource, amount) in Contents)
            {
                var start = first ? "" : "\n";
                if(amount > 0) stringBuilder.Append($"{start}{resource} x{amount}");
                if(first) first = false;
            }

            return stringBuilder.ToString();
        }
    }
}