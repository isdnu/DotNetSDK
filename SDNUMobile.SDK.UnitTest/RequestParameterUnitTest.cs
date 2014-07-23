using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SDNUMobile.SDK.UnitTest
{
    /// <summary>
    /// 请求参数单元测试
    /// </summary>
    [TestClass]
    public class RequestParameterUnitTest
    {
        /// <summary>
        /// 请求参数测试
        /// </summary>
        [TestMethod]
        public void RequestParameterTest()
        {
            String name = "test";
            String expectedString = "teststring";

            RequestParameter parameter = new RequestParameter(name, expectedString);
            Assert.AreEqual(expectedString, parameter.Value);

            Int32 expectedInt32 = 1234;
            parameter.SetParameterValue<Int32>(expectedInt32);
            Assert.AreEqual(expectedInt32.ToString(), parameter.Value);

            String expectedDateTime = "2013-01-02 03:04:05";
            parameter.SetParameterValue(DateTime.Parse(expectedDateTime));
            Assert.AreEqual(expectedDateTime, parameter.Value);

            Byte[] expectedData = new Byte[] { 0, 2, 4, 6, 8 };
            parameter.SetParameterValue("test.data", expectedData);
            Byte[] actualData = parameter.Value as Byte[];

            for (Int32 i = 0; i < expectedData.Length; i++)
            {
                Assert.AreEqual(expectedData[i], actualData[i]);
            }
        }
    }
}