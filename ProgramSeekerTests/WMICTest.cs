using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgramSeeker;

namespace ProgramSeekerTests
{
    [TestClass]
    public class WMICTest
    {
        [TestMethod]
        public void TestLocalSoftwareVersionQuery()
        {
            int queryType = 0;
            WMIC wmic = new WMIC(Environment.MachineName, "user", "pass", true, false, false);
            string expected = "/c wmic product get name, version";

            string result = wmic.createQuery(queryType);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestRemoteSoftwareVersionQuery()
        {
            int queryType = 0;
            WMIC wmic = new WMIC("remote", "u", "p", true, false, false);
            string expected = "/c wmic /node:remote /user:remote\\u /password:\"p\" product get name, version";

            string result = wmic.createQuery(queryType);

            Assert.AreEqual(expected, result);
        }
    }
}
