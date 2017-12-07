using System;

namespace patterns.Builder
{
    public class Program : BaseProgram
    {
        protected override void Run()
        {
            Builder masonBuilder = new MasonBuilder();
            Director director = new Director(masonBuilder);

            director.Construct();

            House masonHouse = masonBuilder.GetResult();
            masonHouse.Show();
        }
    }
}
