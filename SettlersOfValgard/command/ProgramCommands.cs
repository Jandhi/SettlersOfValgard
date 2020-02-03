namespace SettlersOfValgard.command
{
    public static class ProgramCommands
    {
        public static void Quit(Command command)
        {
            Console.WriteLine("Goodbye!");
            Program.EndGame = true;
        }
    }
}