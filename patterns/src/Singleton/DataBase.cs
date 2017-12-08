using System;

namespace patterns.Singleton
{
    public sealed class DataBase
    {
        private static readonly Lazy<DataBase> lazy = new Lazy<DataBase>(() => new DataBase());

        public string Data { get; set; }
        public static DataBase Instance { get { return lazy.Value; } }

        private DataBase()
        {
            Data = "defaultData";
        }
    }
}
