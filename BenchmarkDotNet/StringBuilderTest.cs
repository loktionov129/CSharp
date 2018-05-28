using BenchmarkDotNet.Attributes;
using System.Text;

namespace ConsoleApp1
{
    public class StringBuilderTest
    {
        const int N = 1000;
        string[] strs = null;

        [Setup]
        public void Init()
        {
            strs = new string[] { "A", "Hello", "You", "B", "The", ".NET", "Opt" };
        }

        [Benchmark(Baseline = true)]
        public string WithStringBuilder()
        {
            StringBuilder sb = new StringBuilder();
            var len = strs.Length;
            for (int i = 0; i < N; i++)
            {
                sb.Append(strs[i % len]);
            }
            return sb.ToString();
        }

        [Benchmark]
        public string WithoutStringBuilder()
        {
            string sb = string.Empty;
            var len = strs.Length;
            for (int i = 0; i < N; i++)
            {
                sb += strs[i % len];
            }
            return sb.ToString();
        }
    }
}
