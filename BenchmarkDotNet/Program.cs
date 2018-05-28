using BenchmarkDotNet.Running;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<StringBuilderTest>();
        }
    }
}
