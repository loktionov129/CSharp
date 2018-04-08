namespace patterns.Visitor
{
    /// <summary>
    /// The program.
    /// </summary>
    public class Program: BaseProgram
    {
        /// <summary>
        /// The run.
        /// </summary>
        protected override void Run()
        {
            Animal barsik = new Cat();
            Animal sharik = new Dog();
            Animal farshmak = new Monkey();
            Animal xom940K = new Hamster();

            DoSomeAction(barsik);
            DoSomeAction(sharik);
            DoSomeAction(farshmak);
            DoSomeAction(xom940K);
        }

        /// <summary>
        /// The do some action.
        /// </summary>
        /// <param name="zver">
        /// The zver.
        /// </param>
        private static void DoSomeAction(Animal zver)
        {
            zver.Accept(new PaymentVisitor());
        }
    }
}
