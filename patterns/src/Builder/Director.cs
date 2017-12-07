namespace patterns.Builder
{
    public class Director
    {
        private Builder _builder;

        public Director(Builder builder)
        {
            _builder = builder;
        }

        public void Construct()
        {
            _builder.BuildBasement();
            _builder.BuildStorey();
            _builder.BuildRoof();
        }
    }
}
