using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1
{
    [TestClass]
    public class ParcelJsonHandlerTest
    {
        [TestClass]
        public class MethodHappyFlows
        {
            private ParcelJsonHandler parcelJsonHandler;

            [TestInitialize]
            public void Init()
            {
                parcelJsonHandler = new ParcelJsonHandler();
            }

            [TestMethod]
            public void ExpectJsonToBeSuccefullyReadAndReturningContainer()
            {
                var filePath = "./Container_68465468.json";

                var result = parcelJsonHandler.Deserialize(filePath);

                Assert.IsNotNull(result);
                Assert.AreEqual(68465468, result.Id);
            }
        }
    }
}
