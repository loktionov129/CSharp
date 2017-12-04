using System;

namespace patterns
{
    public abstract class BaseProgram
    {
        protected abstract void Run();

        public void Start()
        {
            string programName = this.GetType().Namespace;

            Console.WriteLine("\r\nRun " + programName + "...");
            Run();
            Console.WriteLine("Terminate " + programName + "...");
        }
    }
}
