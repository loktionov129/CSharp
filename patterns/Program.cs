namespace patterns
{
    class Program
    {
        public static void Main(string[] args)
        {
            App app = new App(new string[] { "patterns", "src" });
            app.Run();
        }
    }
}
