using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SettlersOfValgard.Model.Building;
using SettlersOfValgard.Model.Building.Workplace;
using SettlersOfValgard.UtilLibrary;

namespace SettlersOfValgard.View.Command.Settlement
{
    public class WorkCommand : Command
    {
        public override string Name => "Work Status";
        public override string[] Aliases { get; } = {"w", "work", "Work"};
        public override bool AvailableInMenu => false;
        public override string ToolTip => $"Use \"{Aliases[0]}\" to get a status of work in your settlement. Use \"{Aliases[0]} [workplace]\" to employ idle workers in a workplace with name [workplace].";

        protected override void Execute(string[] args, Game game)
        {
            var settlement = game.Settlement;
            

            if (args.Length == 0)
            {
                Dictionary<string, int> workplaceWorkersDictionary = new Dictionary<string, int>();
                
                foreach (var workplace in settlement.Buildings.Select(building => building as Workplace))
                {
                    if (workplace == null) continue; // Not a workplace
                    
                    if (workplaceWorkersDictionary.ContainsKey(workplace.Name))
                    {
                        workplaceWorkersDictionary[workplace.Name] += workplace.Workers.Count;
                    }
                    else
                    {
                        workplaceWorkersDictionary.Add(workplace.Name, workplace.Workers.Count);
                    }
                }

                foreach (var (name, num) in workplaceWorkersDictionary)
                {
                    if (num > 0)
                    {
                        CustomConsole.WriteLine($"{name}: {num}");
                    }
                }
                
                var idleCount = settlement.Settlers.Count(s => s.CanWork(settlement) && s.Workplace == null);
                if(idleCount > 0) CustomConsole.WriteLine($"{CustomConsole.Red}Idle: {idleCount}");
                
                var underageCount = settlement.Settlers.Count(s => s.IsUnderage(settlement));
                if(underageCount > 0) CustomConsole.WriteLine($"{CustomConsole.Yellow}Underage: {underageCount}");
            }
            else
            {
                var sb = new StringBuilder(args[0]);
                int ordinal = -1;
                for (var i = 1; i < args.Length; i++)
                {
                    try
                    {
                        ordinal = int.Parse(args[i]);
                    }
                    catch (FormatException e)
                    {
                        sb.Append($" {args[i]}");
                    }
                }

                EmployWorkers(settlement, sb.ToString(), ordinal);
            }
        }

        private void EmployWorkers(Model.Core.Settlement settlement, string name, int ordinal)
        {
            var buildings = settlement.Buildings;
            var targetBuildings = buildings.Where(b => string.Equals(b.Name, name, StringComparison.CurrentCultureIgnoreCase)).ToList();
            var idle = settlement.Settlers.Where(s => s.CanWork(settlement) && s.Workplace == null).ToList();

            if (ordinal != -1 && ordinal < 1)
            {
                //Bad ordinal
                CustomConsole.WriteLine($"{CustomConsole.Red}You cannot input non-natural ordinals!");
            }
            else if (targetBuildings.Count == 0)
            {
                //No such building
                CustomConsole.WriteLine($"{CustomConsole.Red}You have no Buildings with the name \"{name}\"!");
            } 
            else if (targetBuildings.Count < ordinal)
            {
                //No such ordinal
                CustomConsole.WriteLine($"{CustomConsole.Red}You only have {targetBuildings.Count} instances of building \"{targetBuildings[0].Name}\"");
            }
            else if (idle.Count == 0)
            {
                //No idle Workers!
                CustomConsole.WriteLine($"{CustomConsole.Red}You have no idle workers!");
            }
            else if (ordinal != -1)
            {
                //Handle ordinal
                var target = targetBuildings[ordinal] as Workplace;

                if (target == null)
                {
                    //Not Workplace
                    CustomConsole.WriteLine($"{CustomConsole.Red}No Workplaces with name \"{name}\"!");
                }
                else if(target.IsFull)
                {
                    //Full
                    CustomConsole.WriteLine($"{CustomConsole.Red}The Workplace \"{name} #{ordinal}\" is full!");
                }
                else
                {
                    //Success
                    var employedCount = 0;
                    while (!target.IsFull && idle.Count > 0)
                    {
                        target.AddWorker(idle[0]);
                        idle.RemoveAt(0);
                        employedCount++;
                    }
                    
                    CustomConsole.WriteLine($"{CustomConsole.Green}Employed {employedCount} workers at {target}!");
                }
            } 
            else
            {
                //Handle non-ordinal
                if (targetBuildings.TrueForAll(building => !(building is Workplace)))
                {
                    //Not Workplace
                    CustomConsole.WriteLine($"{CustomConsole.Red}No Workplaces with name \"{name}\"!");
                }
                else if(!targetBuildings.Any(building => building is Workplace workplace && !workplace.IsFull))
                {
                    //Full
                    CustomConsole.WriteLine($"{CustomConsole.Red}All Workplaces with name \"{name}\" are full!");
                }
                else
                {
                    //Success
                    var employedCount = 0;
                    var workeplacesEmployedCount = 0;
                    foreach (var building in targetBuildings)
                    {
                        //Don't accept non-workplaces
                        if (!(building is Workplace workplace)) continue;
                        
                        //Can't employ above availability or capacity
                        var workersToEmploy = Math.Min(idle.Count,
                            workplace.MaxWorkers - workplace.Workers.Count);
                        if (workersToEmploy > 0) workeplacesEmployedCount++;
                        for (var i = 0; i < workersToEmploy; i++)
                        {
                            workplace.AddWorker(idle[0]);
                            idle.RemoveAt(0);
                            employedCount++;
                        }

                        if (idle.Count == 0) break;
                    }

                    var buildingPlural = workeplacesEmployedCount > 1 ? "s" : "";
                    CustomConsole.WriteLine($"{CustomConsole.Green}Employed {employedCount} workers at {workeplacesEmployedCount} {name}{buildingPlural}!");
                }
            }
        }
    }
}