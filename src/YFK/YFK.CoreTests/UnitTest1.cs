using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YFK.Core.Logger;
using YFK.Core.Cache;

namespace YFK.CoreTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void 日志写入测试()
        {
            ILogger logger = new FileLogger();
            logger.Info("测试日志");
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
        [TestMethod]
        public void log4net日志测试()
        {
            ILogger logger = new Log4netLogger();
            logger.Info("log4net测试日志");
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
        [TestMethod]
        public void Nlog日志测试()
        {
            ILogger logger = new NLogger();
            logger.Info("Nlog日志测试");
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

        [TestMethod]
        public void Redis测试()
        {
            string key = "REDIS_TEST_KEY";
            string redisValue="redis测试";
            ICacheManager cache = new RedisManager();
            cache.Set(key, redisValue, 60);
            string value = cache.Get<string>(key);
            Assert.AreEqual(value, redisValue);
            cache.Remove(key);
        }
        [TestMethod]
        public void MemoryCacheManager测试()
        {
            string key = "Memory_TEST_KEY";
            string memoryValue = "Memory测试";
            ICacheManager cache = new MemoryCacheManager();
            cache.Set(key, memoryValue, 60);
           string value= cache.Get<string>(key);

           Assert.AreEqual(value, memoryValue);
           cache.Remove(key);
        }
    }
}
