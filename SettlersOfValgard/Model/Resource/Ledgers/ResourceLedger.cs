using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SettlersOfValgard.Model.Resource
{
    public class ResourceLedger
    {
        public ResourceLedger()
        {
            Contents = new Dictionary<Resource, int>();
        }
        
        public Dictionary<Resource, int> Contents { get; set; }
        
        public bool Contains(Resource resource)
        {
            return Contents.ContainsKey(resource) && Contents[resource] > 0;
        }

        public bool IsEmpty()
        {
            return Contents.All(pair => pair.Value == 0);
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            var first = true;
            foreach (var (resource, amount) in Contents)
            {
                var start = first ? "" : ", ";
                if(amount != 0) stringBuilder.Append($"{start}{resource} {(amount > 0 ? "+" : "")}{amount}");
                if(first) first = false;
            }

            return stringBuilder.ToString();
        }
    }
}