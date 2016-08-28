using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YFK.Core.Logger;

namespace YFK.CoreTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ILogger logger = new FileLogger();
            try
            {
                int i = 1, j = 0;
                i = i / j;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
    }
}
