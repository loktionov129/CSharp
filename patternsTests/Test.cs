using NUnit.Framework;
using System;
namespace patternsTests
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void TestCase()
        {
            Assert.AreEqual(1, 1, "1 should be a 1");
        }

        [Test()]
        public void TestCase2()
        {
            Assert.AreEqual(4, 1, "4 shouldn't be a 1");
        }
    }
}
