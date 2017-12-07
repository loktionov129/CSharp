namespace patterns.Builder
{
    public class MasonBuilder: Builder
    {
        public override void BuildBasement()
        {
            Result.Add("mason_basement");
        }

        public override void BuildStorey()
        {
            Result.Add("mason_storey");
        }

        public override void BuildRoof()
        {
            Result.Add("mason_roof");
        }
    }
}
