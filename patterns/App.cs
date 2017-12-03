using System;
using System.IO;
using System.Linq;

namespace patterns
{
    public class App
    {
        private string[] commandForTerminate = new string[] { "0", "q", "e", "quit", "exit" };
        private string[] programList;
        private string[] fullPath;

        public App(string[] path)
        {
            fullPath = path;
        }

        public void Run()
        {
            programList = GetAvailablePrograms();
            string programName = GetProgramName();

            while (!commandForTerminate.Contains(programName))
            {
                Console.WriteLine("I want to start " + programName + "...");
                StartProgram(programName);
                programName = GetProgramName();
            }
        }

        private string[] GetAvailablePrograms()
        {
            string src = "../../../" + String.Join("/", fullPath);
            return Directory.GetDirectories(src).Select(path => path.Split('\\').Last()).ToArray();
        }

        private string GetProgramName()
        {
            Console.WriteLine("\r\n\r\nEnter a name or number of program:");
            PrintAllPrograms();
            Console.WriteLine("Or type one of command to exit: " + String.Join(", ", commandForTerminate));
            return Console.ReadLine().Trim().ToLower();
        }

        private Type FindProgram(string programName)
        {
            string targetName = ParseProgramName(programName);
            if (targetName == null)
            {
                return null;
            }

            string programNameSpace = String.Join(".", fullPath);
            Type programType = Type.GetType(programNameSpace + "." + targetName + ".Program");
            return programType;
        }

        private string ParseProgramName(string programName)
        {
            int programNumber;
            int programsLength = programList.Count();

            if (Int32.TryParse(programName, out programNumber))
            {
                if (programNumber < 1 || programNumber > programsLength)
                {
                    return null;
                }

                --programNumber;
                for (int i = 0; i < programsLength; ++i)
                {
                    if (programNumber == i)
                    {
                        return programList[i];
                    }
                }
            }
            else
            {
                for (int i = 0; i < programsLength; ++i)
                {
                    if (programName == programList[i].ToLower())
                    {
                        return programList[i];
                    }
                }
            }
            return null;
        }

        private void PrintAllPrograms()
        {
            for (int i = 0, length = programList.Count(); i < length; ++i)
            {
                Console.WriteLine(String.Format("{0} - {1}", 1 + i, programList[i]));
            }
        }

        private void StartProgram(string programName)
        {
            Type target = FindProgram(programName);
            if (target != null)
            {
                BaseProgram program = (BaseProgram)Activator.CreateInstance(target);
                program.Start();
                program = null;
                GC.Collect();
            }
            else
            {
                Console.WriteLine("Incorrect program!");
            }
        }
    }
}