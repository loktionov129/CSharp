using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
 * access to private field:
MyReturnType accessiblePrivateField = (MyReturnType)accessor.GetField("privateFieldName");

 * access to private const field:
var privateType = new PrivateType(app.GetType());
var entryPointClassname = privateType.GetStaticFieldOrProperty("EntryPointClassname");

 * access to private method
int actual = (int) accessor.Invoke(
    "TestableMethod1",
    new Type[] {typeof(int)},
    new Object[] {id},
    new Type[] {typeof(int)}
);
*/

namespace patterns.Tests
{
    [TestClass]
    public class AppTest
    {
        [TestMethod]
        public void GetAvailablePrograms_void_expectedProgramListReturned()
        {
            #region Step 0. Arrange
            App app = new App();
            PrivateObject accessor = new PrivateObject(app);
            #endregion

            #region Step 1. Act
            string[] expectedProgramList = { "AbstractFactory", "Builder" };
            string[] actualProgramList = (string[])accessor.Invoke("GetAvailablePrograms");
            Trace.WriteLine("expectedProgramList:");
            Trace.WriteLine(String.Join("\r\n", expectedProgramList));

            Trace.WriteLine("\r\nactualProgramList:");
            Trace.WriteLine(
                actualProgramList?.Length > 0
                ? String.Join("\r\n", actualProgramList)
                : "Programs not found!"
            );

            #endregion

            #region Step 2. Assert
            CollectionAssert.AreEqual(expectedProgramList, actualProgramList);
            #endregion
        }

        [TestMethod]
        public void FindProgram_builder_expectedProgramReturned()
        {
            #region Step 0. Arrange
            App app = new App();
            PrivateObject accessor = new PrivateObject(app);
            #endregion

            #region Step 1. Act
            string actualProgram = accessor.Invoke("FindProgram", "builder")?.ToString();
            string expectedProgram = new Builder.Program().GetType().ToString();

            Trace.WriteLine($"actualProgram: {actualProgram}");
            Trace.WriteLine($"expectedProgram: {expectedProgram}");

            #endregion

            #region Step 2. Assert
            Assert.AreEqual(expectedProgram, actualProgram);
            #endregion
        }

        [TestMethod]
        public void FindProgram_1_expectedProgramReturned()
        {
            #region Step 0. Arrange
            App app = new App();
            PrivateObject accessor = new PrivateObject(app);
            #endregion

            #region Step 1. Act
            string actualProgram = accessor.Invoke("FindProgram", "1")?.ToString();
            string firstProgramFromList = ((string[]) accessor.GetField("_programList")).First();
            var privateType = new PrivateType(app.GetType());
            var entryPointClassname = privateType.GetStaticFieldOrProperty("EntryPointClassname");
            string expectedProgram = $"{app.GetType().Namespace}.{firstProgramFromList}.{entryPointClassname}";

            Trace.WriteLine($"actualProgram: {actualProgram}");
            Trace.WriteLine($"expectedProgram: {expectedProgram}");

            #endregion

            #region Step 2. Assert
            Assert.AreEqual(expectedProgram, actualProgram);
            #endregion
        }

        [TestMethod]
        public void FindProgram_invalid_nullReturned()
        {
            #region Step 0. Arrange
            App app = new App();
            PrivateObject accessor = new PrivateObject(app);
            #endregion

            #region Step 1. Act
            string actualProgram = accessor.Invoke("FindProgram", "invalid")?.ToString();

            Trace.WriteLine($"actualProgram: {actualProgram ?? "<null>"}");
            Trace.WriteLine("expectedProgram: <null>");

            #endregion

            #region Step 2. Assert
            Assert.AreEqual(null, actualProgram);
            #endregion
        }
    }
}
