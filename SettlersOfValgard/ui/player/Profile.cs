using System.Collections.Generic;
using SettlersOfValgardGame.ui.commands;

namespace SettlersOfValgardGame.ui.player
{
    public class Profile
    {
        public Profile(List<Permission> permissions = null)
        {
            Permissions = permissions ?? new List<Permission>();
        }

        public List<Permission> Permissions { get; }
    }
}