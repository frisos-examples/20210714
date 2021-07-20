using ConsoleApp1;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1
{
    [TestClass]
    public class DepartmentHandlerTest
    {
        [TestClass]
        public class Constructor
        {
            [TestMethod]
            public void ExpectArgumentNullExceptionWhenDepartmentOptionsIsNull() => Assert.ThrowsException<ArgumentNullException>(() => new DepartmentHandler(null));
        }

        [TestClass]
        public class MethodHappyFlows
        {
            private Mock<IOptions<List<Department>>> departmentOptionsMock;
            private DepartmentHandler departmentHandler;

            [TestInitialize]
            public void Init()
            {
                var _departments = new List<Department>
                {
                    new Department
                    {
                        Name = "d1",
                        MaxWeight = 1
                    },

                    new Department
                    {
                        Name = "d2",
                        MinWeight = 1,
                        MaxWeight = 10
                    },

                    new Department
                    {
                        Name = "d3",
                        MinWeight = 10
                    },

                    new Department
                    {
                        Name = "d4",
                        MinValue = 1000
                    }
                };

                departmentOptionsMock = new Mock<IOptions<List<Department>>>();

                departmentOptionsMock.Setup(d => d.Value).Returns(_departments).Verifiable();

                departmentHandler = new DepartmentHandler(departmentOptionsMock.Object);
            }

            public void VerifyInit()
            {
                departmentOptionsMock.Verify(s => s.Value);
            }

            [TestClass]
            public class GetDepartmentByValue {
                private Mock<IOptions<List<Department>>> departmentOptionsMock;
                private DepartmentHandler departmentHandler;

                [TestInitialize]
                public void Init()
                {
                    var _departments = new List<Department>
                {
                    new Department
                    {
                        Name = "d1",
                        MaxWeight = 1
                    },

                    new Department
                    {
                        Name = "d2",
                        MinWeight = 1,
                        MaxWeight = 10
                    },

                    new Department
                    {
                        Name = "d3",
                        MinWeight = 10
                    },

                    new Department
                    {
                        Name = "d4",
                        MinValue = 1000
                    }
                };

                    departmentOptionsMock = new Mock<IOptions<List<Department>>>();

                    departmentOptionsMock.Setup(d => d.Value).Returns(_departments).Verifiable();

                    departmentHandler = new DepartmentHandler(departmentOptionsMock.Object);
                }

                public void VerifyInit()
                {
                    departmentOptionsMock.Verify(s => s.Value);
                }

                [TestMethod]
                public void ExpectToGetD4WhenValueIsMoreThan1000()
                {
                    VerifyInit();

                    var result = departmentHandler.GetDepartmentByValue((decimal)1000.1, out var department);

                    Assert.IsTrue(result);
                    Assert.AreEqual("d4", department.Name);
                }

                [TestMethod]
                public void ExpectToGetNullWhenValueIsLessThan1000()
                {
                    VerifyInit();

                    var result = departmentHandler.GetDepartmentByValue((decimal)0, out var department);

                    Assert.IsFalse(result);
                    Assert.IsNull(department);
                }

            }


            [TestClass]
            public class GetDepartmentByWeight
            {
                private Mock<IOptions<List<Department>>> departmentOptionsMock;
                private DepartmentHandler departmentHandler;

                [TestInitialize]
                public void Init()
                {
                    var _departments = new List<Department>
                {
                    new Department
                    {
                        Name = "d1",
                        MaxWeight = 1
                    },

                    new Department
                    {
                        Name = "d2",
                        MinWeight = 1,
                        MaxWeight = 10
                    },

                    new Department
                    {
                        Name = "d3",
                        MinWeight = 10
                    },

                    new Department
                    {
                        Name = "d4",
                        MinValue = 1000
                    }
                };

                    departmentOptionsMock = new Mock<IOptions<List<Department>>>();

                    departmentOptionsMock.Setup(d => d.Value).Returns(_departments).Verifiable();

                    departmentHandler = new DepartmentHandler(departmentOptionsMock.Object);
                }

                public void VerifyInit()
                {
                    departmentOptionsMock.Verify(s => s.Value);
                }

                [TestMethod]
                public void ExpectToGetD1WhenWeightIsLessThan1()
                {
                    VerifyInit();

                    var result = departmentHandler.GetDepartmentByWeight((decimal)0.5, out var department);

                    Assert.IsTrue(result);
                    Assert.AreEqual("d1", department.Name);
                }

                [TestMethod]
                public void ExpectToGetD1WhenWeightIsEqualTo1()
                {
                    VerifyInit();

                    var result = departmentHandler.GetDepartmentByWeight((decimal)1, out var department);

                    Assert.IsTrue(result);
                    Assert.AreEqual("d1", department.Name);
                }

                [TestMethod]
                public void ExpectToGetD2WhenWeightIsMoreThan1AndLessThan10()
                {
                    VerifyInit();

                    var result = departmentHandler.GetDepartmentByWeight((decimal)1.1, out var department);

                    Assert.IsTrue(result);
                    Assert.AreEqual("d2", department.Name);

                }

                [TestMethod]
                public void ExpectToGetD2WhenWeightIsEqualTo10()
                {
                    VerifyInit();

                    var result = departmentHandler.GetDepartmentByWeight((decimal)10, out var department);

                    Assert.IsTrue(result);
                    Assert.AreEqual("d2", department.Name);

                }

                [TestMethod]
                public void ExpectToGetD3WhenWeightIsMoreThan10()
                {
                    VerifyInit();

                    var result = departmentHandler.GetDepartmentByWeight((decimal)10.1, out var department);

                    Assert.IsTrue(result);
                    Assert.AreEqual("d3", department.Name);

                }
            }

        }

        [TestClass]
        public class MethodUnHappyFlows
        {
            [TestClass]
            public class GetDepartmentByValue
            {
                private Mock<IOptions<List<Department>>> departmentOptionsMock;
                private DepartmentHandler departmentHandler;

                [TestInitialize]
                public void Init()
                {
                    var _departments = new List<Department>();

                    departmentOptionsMock = new Mock<IOptions<List<Department>>>();

                    departmentOptionsMock.Setup(d => d.Value).Returns(_departments).Verifiable();

                    departmentHandler = new DepartmentHandler(departmentOptionsMock.Object);
                }

                public void VerifyInit()
                {
                    departmentOptionsMock.Verify(s => s.Value);
                }

                [TestMethod]
                public void ExpectToGetNullWhenValueIsMoreThan1000()
                {
                    VerifyInit();

                    var result = departmentHandler.GetDepartmentByValue((decimal)1000.1, out var department);

                    Assert.IsFalse(result);
                    Assert.IsNull(department);
                }

                [TestMethod]
                public void ExpectToGetNullWhenValueIsLessThan1000()
                {
                    VerifyInit();

                    var result = departmentHandler.GetDepartmentByValue((decimal)0, out var department);

                    Assert.IsFalse(result);
                    Assert.IsNull(department);
                }

            }


            [TestClass]
            public class GetDepartmentByWeight
            {
                private Mock<IOptions<List<Department>>> departmentOptionsMock;
                private DepartmentHandler departmentHandler;

                [TestInitialize]
                public void Init()
                {
                    var _departments = new List<Department>();

                    departmentOptionsMock = new Mock<IOptions<List<Department>>>();

                    departmentOptionsMock.Setup(d => d.Value).Returns(_departments).Verifiable();

                    departmentHandler = new DepartmentHandler(departmentOptionsMock.Object);
                }

                public void VerifyInit()
                {
                    departmentOptionsMock.Verify(s => s.Value);
                }

                [TestMethod]
                public void ExpectToGetNullWhenWeightIsLessThan1()
                {
                    VerifyInit();

                    var result = departmentHandler.GetDepartmentByWeight((decimal)0.5, out var department);

                    Assert.IsFalse(result);
                    Assert.IsNull(department);
                }

                [TestMethod]
                public void ExpectToGetNullWhenWeightIsEqualTo1()
                {
                    VerifyInit();

                    var result = departmentHandler.GetDepartmentByWeight((decimal)1, out var department);

                    Assert.IsFalse(result);
                    Assert.IsNull(department);
                }

                [TestMethod]
                public void ExpectToGetNullWhenWeightIsMoreThan1AndLessThan10()
                {
                    VerifyInit();

                    var result = departmentHandler.GetDepartmentByWeight((decimal)1.1, out var department);

                    Assert.IsFalse(result);
                    Assert.IsNull(department);

                }

                [TestMethod]
                public void ExpectToGetNullWhenWeightIsEqualTo10()
                {
                    VerifyInit();

                    var result = departmentHandler.GetDepartmentByWeight((decimal)10, out var department);

                    Assert.IsFalse(result);
                    Assert.IsNull(department);
                }

                [TestMethod]
                public void ExpectToGetNullWhenWeightIsMoreThan10()
                {
                    VerifyInit();

                    var result = departmentHandler.GetDepartmentByWeight((decimal)10.1, out var department);

                    Assert.IsFalse(result);
                    Assert.IsNull(department);
                }
            }

        }
    }
}
