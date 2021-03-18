using System;
using SettlersOfValgardGame.ui.console.color;
using SettlersOfValgardGame.ui.console.text;

namespace SettlersOfValgardGame.ui.console
{
    public static class VConsole
    {
        public static int OutputLogMax = 1000;
        public static Log Log = new Log(OutputLogMax);

        public static VText Text(string text, VColor foregroundColor = null, VColor backgroundColor = null,
            params VTextFeature[] features)
        {
            return new VTextSegment(text, foregroundColor, backgroundColor, features);
        }

        public static void WriteLine(params string[] texts)
        {
            WriteLine(new VTextComposite(texts));
        }

        public static void WriteLine(params VText[] vTexts)
        {
            var finalText = "";
            
            foreach (var text in vTexts)
            {
                finalText += text.ToString();
            }

            foreach (var text in finalText.Split("\n"))
            {
                Log.Add(text, Log.MessageType.Output);
                Console.WriteLine(text);
            }
        }

        public static void WriteError(string error, bool deadly = false)
        {
            WriteError(Text(error), deadly);
        }

        public static void WriteError(VText error, bool deadly = false)
        {
            error = Text("ERROR: ").Plus(error);
            error = error.Apply(VTextTransform.SetForeground(VColor.Red, true));
            Log.Add(error.ToString(), Log.MessageType.Error);
            Console.WriteLine(error);
        }

        public static void WriteWarning(string warning)
        {
            WriteWarning(Text(warning));
        }

        public static void WriteWarning(VText warning)
        {
            warning = Text("WARNING: ").Plus(warning);
            warning.Apply(VTextTransform.SetForeground(VColor.Orange, true));
            Log.Add(warning.ToString(), Log.MessageType.Warning);
            Console.WriteLine(warning);
        }

        public static void WriteDebug(string debug)
        {
            WriteDebug(Text(debug));
        }

        public static void WriteDebug(VText debug)
        {
            debug = Text("DEBUG: ").Plus(debug);
            debug.Apply(VTextTransform.SetForeground(VColor.Yellow, true));
            Log.Add(debug.ToString(), Log.MessageType.Debug);
            Console.WriteLine(debug);
        }

        public static string ReadLine()
        {
            return Console.ReadLine();
        }

        public static void Clear()
        {
            Console.Clear();
        }
    }
}