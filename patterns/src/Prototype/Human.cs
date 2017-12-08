namespace patterns.Prototype
{
    public class Human : Prototype
    {
        public string Name { get; internal set; }
        public Human(string data, string name)
            : base(data)
        {
            Name = name;
        }

        public override Prototype Clone()
        {
            return new Human(Data, Name);
        }
    }
}
