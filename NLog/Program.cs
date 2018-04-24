using System;

namespace NetRore.Csharp.Cmd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new Program().Launch();
        }

        private void Launch()
        {
            StaticLogger.LogInfo(GetType(), "Begin Launch...");
            try
            {
                Console.WriteLine(42 / int.Parse("0"));
            }
            catch (Exception ex)
            {
                StaticLogger.LogException(GetType(), "Something went wrong", ex);
            }
            StaticLogger.LogInfo(GetType(), "End Launch...");
        }
    }
}