﻿using System;
namespace patterns
{
    abstract public class BaseProgram
    {
        abstract public void Run();

        public void Start()
        {
            string programName = this.GetType().Namespace;

            Console.WriteLine("\r\nRun " + programName + "...");
            Run();
            Console.WriteLine("Terminate " + programName + "...");
        }
    }
}