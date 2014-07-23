using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDNUMobile.SDK.UnitTest
{
    /// <summary>
    /// 抽象调用方法单元测试
    /// </summary>
    [TestClass]
    public class AbstractRestMethodUnitTest
    {
        /// <summary>
        /// 抽象调用方法测试
        /// </summary>
        [TestMethod]
        public void AbstractRestMethodTest()
        {
            TestRestMethod restMethod = new TestRestMethod();
            String name = "test";

            String expectedString = "teststring";
            restMethod.InternalSetParameter(name, expectedString);
            String actualString = restMethod.InternalGetParameterStringValue(name);
            Assert.AreEqual(expectedString, actualString);

            Int32 expectedInt32 = 1234;
            restMethod.InternalSetParameter<Int32>(name, expectedInt32);
            Int32 actualInt32 = restMethod.InternalGetParameterInt32Value(name).Value;
            Assert.AreEqual(expectedInt32, actualInt32);

            DateTime expectedDateTime = new DateTime(2013, 01, 02, 03, 04, 05);
            restMethod.InternalSetParameter(name, expectedDateTime);
            DateTime actualDateTime = restMethod.InternalGetParameterDateTimeValue(name).Value;
            Assert.AreEqual(expectedDateTime, actualDateTime);

            Byte[] expectedData = new Byte[] { 0, 2, 4, 6, 8 };
            restMethod.InternalSetParameter(name, "test.dat", expectedData);
            Byte[] actualData = restMethod.InternalGetParameterBinaryValue(name);

            for (Int32 i = 0; i < expectedData.Length; i++)
            {
                Assert.AreEqual(expectedData[i], actualData[i]);
            }
        }
    }
}