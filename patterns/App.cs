using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("patternsTests")]
namespace patterns
{
    public class App
    {
        private static readonly string ClassPath = "patterns" + Path.DirectorySeparatorChar + "src";
        private readonly string[] _commandsForTerminate;

        protected internal const string EntryPointClassname = "Program";
        protected internal readonly string[] ProgramList;

        public App(string[] commandsForTerminate = null)
        {
            _commandsForTerminate = commandsForTerminate ?? new [] { "quit", "exit" };
            ProgramList = GetAvailablePrograms();
        }

        public string AskProgramName()
        {
            Console.WriteLine("\r\n\r\nEnter a name or number of program:");
            PrintAllPrograms();
            Console.WriteLine("Or type one of command to exit: " + string.Join(", ", _commandsForTerminate));
            return Console.ReadLine()
                ?.Trim().ToLower()
                ?? "";
        }

        public void StartProgram(string programName)
        {
            var target = FindProgram(programName);
            if (target != null)
            {
                var program = (BaseProgram)Activator.CreateInstance(target);
                program.Start();
                // program = null;
                GC.Collect();
            }
            else
            {
                Console.WriteLine("Incorrect program!");
            }
        }

        protected internal Type FindProgram(string programName)
        {
            var targetName = ParseProgramName(programName);
            if (targetName == null)
                return null;

            return Type.GetType(
                GetType().Namespace
                + "."
                + targetName
                + "."
                + EntryPointClassname
            );
        }

        protected internal string[] GetAvailablePrograms()
        {
            string relativePath = Type.GetType("Mono.Runtime") == null
                ? "../../../"
                : "./";
            string fullPath = relativePath + ClassPath;

            if (!Directory.Exists(fullPath))
                return new string[0];

            return Directory.GetDirectories(fullPath)
                .Select(path => path.Split(Path.DirectorySeparatorChar).Last())
                .ToArray();
        }

        private string ParseProgramName(string programName)
        {
            int programNumber;
            var programsLength = ProgramList.Length;

            if (int.TryParse(programName, out programNumber))
            {
                if (programNumber < 1 || programNumber > programsLength)
                    return null;

                --programNumber;
                for (var i = 0; i < programsLength; ++i)
                    if (programNumber == i)
                        return ProgramList[i];
            }
            else
            {
                for (var i = 0; i < programsLength; ++i)
                    if (programName == ProgramList[i].ToLower())
                        return ProgramList[i];
            }
            return null;
        }

        private void PrintAllPrograms()
        {
            for (int i = 0, length = ProgramList.Length; i < length; ++i)
                Console.WriteLine($"{1 + i} - {ProgramList[i]}");
        }
    }
}
