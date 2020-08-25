using System;
using System.Linq;

namespace SettlersOfValgard.Interface.Console
{
    public class GetYesNo
    {
        public static string[] Positive = {"y", "ye", "yes"};
        public static string[] Negative = {"n", "no"};
        public static readonly GameError YesOrNoError = new GameError("You must answer yes or no!");

        public string Question { get; }
        
        public GetYesNo(string question)
        {
            Question = question;
        }

        public bool Execute()
        {
            while (true)
            {
                VConsole.WriteLine($"{Question} (y/n)");
                var response = VInput.GetArgs();

                if (response.Length != 1)
                {
                    YesOrNoError.Write();
                    continue;
                }
                
                if (Positive.Any(word => word == response[0]))
                {
                    return true;
                }

                if (Negative.Any(word => word == response[0]))
                {
                    return false;
                }

                YesOrNoError.Write();
            }
        }
    }
}