using NUnit.Framework;
using System.Linq;
using System.IO;
using patterns;

namespace patternsTests
{
    [TestFixture()]
    public class AppTest
    {
        private App app;

        [TestFixtureSetUp()]
        public void RunBeforeEach()
        {
            app = new App();
        }
        [Test()]
        public void GetAvailablePrograms_void_expectedProgramListReturned()
        {
            string[] expectedProgramList = { "AbstractFactory", "Builder", "FactoryMethod" };
            string[] actualProgramList = app.ProgramList;

            CollectionAssert.AreEqual(expectedProgramList, actualProgramList);
        }

        [Test()]
        public void FindProgram_builder_expectedProgramReturned()
        {

            string actualProgram = app.FindProgram("builder")?.ToString();
            string expectedProgram = new patterns.Builder.Program().GetType().ToString();

            Assert.AreEqual(expectedProgram, actualProgram);
        }

        [Test()]
        public void FindProgram_1_expectedProgramReturned()
        {
            string actualProgram = app.FindProgram("1")?.ToString();
            string firstProgramFromList = app.ProgramList.First();
            string entryPointClassname = App.EntryPointClassname;
            string expectedProgram = $"{app.GetType().Namespace}.{firstProgramFromList}.{entryPointClassname}";

            Assert.AreEqual(expectedProgram, actualProgram);
        }

        [Test()]
        public void FindProgram_invalid_nullReturned()
        {
            string actualProgram = app.FindProgram("invalid")?.ToString();
            Assert.IsNull(actualProgram);
        }
    }
}
