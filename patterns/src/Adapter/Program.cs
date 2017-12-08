namespace patterns.Adapter
{
    public class Program : BaseProgram
    {
        protected override void Run()
        {
            Client client = new Client();
            client.DoSomething(new Adapter());
        }
    }
}
