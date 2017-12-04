namespace patterns.AbstractFactory
{
    public class Program : BaseProgram
    {
        protected override void Run()
        {
            Client client = new Client(new CocaColaFactory());
            client.Run();

            client = new Client(new PepsiFactory());
            client.Run();
        }
    }
}
