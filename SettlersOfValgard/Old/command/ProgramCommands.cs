namespace SettlersOfValgard.command
{
    public static class ProgramCommands
    {
        public static void Quit(Command command)
        {
            Console.WriteLine("Goodbye!");
            OldProgram.EndGame = true;
        }
    }
}