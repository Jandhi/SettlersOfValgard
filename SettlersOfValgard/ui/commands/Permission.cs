using System.Collections.Generic;
using System.Linq;
using SettlersOfValgardGame.ui.console.color;
using SettlersOfValgardGame.ui.models;
using SettlersOfValgardGame.ui.player;

namespace SettlersOfValgardGame.ui.commands
{
    public class Permission : NamedObject
    {
        public static readonly List<Permission> Permissions = new List<Permission>();
        public static readonly Permission GodMode = new Permission("GodMode", VColor.Gold);
        public static readonly Permission Debug = new Permission("Debug", VColor.Red, new List<Permission>{GodMode});

        public Permission(string nameText, VColor nameForeground, List<Permission> children = null) : base()
        {
            NameText = nameText;
            NameForeground = nameForeground;
            Children = children ?? new List<Permission>();
            Permissions.Add(this);
        }

        public List<Permission> Children { get; }
        
        public bool ProfileHasPermission(Profile profile)
        {
            var visited = new HashSet<Permission>();
            var queue = new Stack<Permission>(profile.Permissions);

            while (queue.Count > 0)
            {
                var permission = queue.Pop();
                if (permission == this)
                {
                    return true;
                }
                else
                {
                    visited.Add(permission);

                    foreach (var child in permission.Children.Where(child => !visited.Contains(child)))
                    {
                        queue.Append(child);
                    }
                }
            }

            // Permission not found!
            return false;
        }

        public override string NameText { get; }
        public override VColor NameForeground { get; }
    }
}