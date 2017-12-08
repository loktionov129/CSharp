namespace patterns.Adapter
{
    public class Client
    {
        public void DoSomething(Target target)
        {
            target.Request();
        }
    }
}
