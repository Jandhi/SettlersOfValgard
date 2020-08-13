using System.Collections.Generic;
using System.Linq;

namespace SettlersOfValgard.Model.Building.Workplace
{
    public abstract class Workplace : Building
    {
        public List<Settler.Settler> Workers { get; set; } = new List<Settler.Settler>();
        public abstract int MaxWorkers { get; }
        public bool IsFull => Workers.Count >= MaxWorkers;

        public void AddWorker(Settler.Settler worker)
        {
            if (IsFull) return; //Can't add worker if full
            Workers.Add(worker);
            worker.Workplace = this;
            ;
        }

        public abstract void HostWork(Settler.Settler worker, Settlement.Settlement settlement);
        
        public virtual Settler.Settler GetWorkerToReplace()
        {
            return Workers.FirstOrDefault();
        }
    }
}