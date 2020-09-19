using System;

namespace SettlersOfValgard.Util
{
    public static class ActionUtility
    {
        public static void Repeat(this Action action, int num)
        {
            for (var i = 0; i < num; i++)
            {
                action.Invoke();
            }
        }
    }
}