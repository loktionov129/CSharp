namespace patterns.src.AbstractFactory
{
    public class Program : patterns.BaseProgram
    {
        public override void Run()
        {
            Client client = new Client(new CocaColaFactory());
            client.Run();

            client = new Client(new PepsiFactory());
            client.Run();
        }
    }
}