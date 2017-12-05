using System;
using System.IO;
using System.Linq;

namespace patterns
{
    public class App
    {
        private static readonly string ClassPath = "patterns" + Path.DirectorySeparatorChar + "src";
        private const string EntryPointClassname = "Program";
        private readonly string[] _commandsForTerminate;
        private readonly string[] _programList;

        public App(string[] commandsForTerminate = null)
        {
            _commandsForTerminate = commandsForTerminate ?? new [] { "quit", "exit" };
            _programList = GetAvailablePrograms();
        }

        public string AskProgramName()
        {
            Console.WriteLine("\r\n\r\nEnter a name or number of program:");
            PrintAllPrograms();
            Console.WriteLine("Or type one of command to exit: " + string.Join(", ", _commandsForTerminate));
            return Console.ReadLine()?.Trim().ToLower() ?? "";
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

        private string[] GetAvailablePrograms()
        {
            string fullPath = "../../../" + ClassPath;

            if (!Directory.Exists(fullPath))
                fullPath = "./" + ClassPath;

            if (!Directory.Exists(fullPath))
                return new string[0];

            return Directory.GetDirectories(fullPath)
                .Select(path => path.Split(Path.DirectorySeparatorChar).Last()).ToArray();
        }

        private Type FindProgram(string programName)
        {
            var targetName = ParseProgramName(programName);
            if (targetName == null)
                return null;

            var programType = Type.GetType(GetType().Namespace + "." + targetName + "." + EntryPointClassname);
            return programType;
        }

        private string ParseProgramName(string programName)
        {
            int programNumber;
            var programsLength = _programList.Length;

            if (int.TryParse(programName, out programNumber))
            {
                if (programNumber < 1 || programNumber > programsLength)
                    return null;

                --programNumber;
                for (var i = 0; i < programsLength; ++i)
                    if (programNumber == i)
                        return _programList[i];
            }
            else
            {
                for (var i = 0; i < programsLength; ++i)
                    if (programName == _programList[i].ToLower())
                        return _programList[i];
            }
            return null;
        }

        private void PrintAllPrograms()
        {
            for (int i = 0, length = _programList.Length; i < length; ++i)
                Console.WriteLine($"{1 + i} - {_programList[i]}");
        }
    }
}
