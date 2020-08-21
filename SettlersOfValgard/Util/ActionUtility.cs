using System;

namespace SettlersOfValgard.Util
{
    public class ActionUtility
    {
        public static void Repeat(Action action, int num)
        {
            for (var i = 0; i < 3; i++)
            {
                action.Invoke();
            }
        }
    }
}