namespace patterns.Prototype
{
    public class Program : BaseProgram
    {
        protected override void Run()
        {
            Prototype adam = new Human("__data__", "Adam");
            Human andrew = adam.Clone() as Human;
            andrew.Name = "Andrew";

            System.Console.WriteLine(andrew.Name);
            System.Console.WriteLine(andrew.Data);
        }
    }
}
