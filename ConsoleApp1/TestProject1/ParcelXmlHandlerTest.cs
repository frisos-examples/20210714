using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1
{
    public class ParcelXmlHandlerTest
    {
        [TestClass]
        public class Method_HappyFlows
        {
            private ParcelXmlHandler parcelXmlHandler;

            [TestInitialize]
            public void Init()
            {
                parcelXmlHandler = new ParcelXmlHandler();
            }

            [TestMethod]
            public void ExpectXmlToBeSuccefullyReadAndReturningContainer()
            {
                var filePath = "./Container_68465468.xml";

                var result = parcelXmlHandler.Deserialize(filePath);

                Assert.IsNotNull(result);
                Assert.AreEqual(68465468, result.Id);
            }
        }
    }
}
