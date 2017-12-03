namespace patterns.AbstractFactory
{
    public class Program : BaseProgram
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
