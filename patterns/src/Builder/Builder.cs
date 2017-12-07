namespace patterns.Builder
{
    public abstract class Builder
    {
        protected House Result;

        protected Builder()
        {
            Result = new House();
        }

        public House GetResult()
        {
            return Result;
        }

        public abstract void BuildBasement();
        public abstract void BuildStorey();
        public abstract void BuildRoof();
    }
}
