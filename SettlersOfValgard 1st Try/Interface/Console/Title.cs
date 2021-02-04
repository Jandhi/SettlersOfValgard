using System.Drawing;
using SettlersOfValgard.Util;

namespace SettlersOfValgard.Interface.Console
{
    public class Title<T> : TextEffect where T : INamed, IColored
    {
        public Title(T item)
        {
            Item = item;
        }
        
        public T Item { get; }

        public override void Write()
        {
            VConsole.WriteLine($"{VColor.Gray}--------");
            VConsole.WriteLine($"{Item.Color}{Item.Name.ToUpper()}{VColor.White}");
        }
    }
}