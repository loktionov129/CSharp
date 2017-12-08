namespace patterns.Singleton
{
    public class Program: BaseProgram
    {
        protected override void Run()
        {
            DataBase db_connection1 = DataBase.Instance;
            DataBase db_connection2 = DataBase.Instance;
            db_connection1.Data = "data_was_modified";
            System.Console.WriteLine(db_connection2.Data);
        }
    }
}
