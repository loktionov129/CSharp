using System;
using System.Linq;

namespace patterns
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] commandsForTerminate = { "0", "q", "e", "quit", "exit" };
            App app = new App(commandsForTerminate, isCurrentDir: Type.GetType("Mono.Runtime") != null);

            string programName = app.AskProgramName();

            while (!commandsForTerminate.Contains(programName))
            {
                Console.WriteLine("I want to start " + programName + "...");
                app.StartProgram(programName);
                programName = app.AskProgramName();
            }
        }
    }
}
