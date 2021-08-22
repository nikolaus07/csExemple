using NUnit.Framework;

namespace csExemple
{
    class StartMain_Nunit
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void test_N_log()
        {
            Test_N_Log.testLogger();
            Assert.Pass();

            // output yyyy / mm / dd 10:37:21.518 | Info | das ist INFO-logger
            // output yyyy / mm / dd 10:37:21.587 | Warn | das ist WARN-logger
            // output yyyy / mm / dd 10:37:21.587 | Error | das ist ERROR-logger
            // output yyyy / mm / dd 10:37:21.587 | Fatal | das ist FATAL-logger
            // output yyyy / mm / dd 16:00:07.972 | Info | das ist INFO-logger
            // output yyyy / mm / dd 16:00:08.047 | Warn | das ist WARN-logger
            // output yyyy / mm / dd 16:00:08.169 | Error | das ist ERROR-logger
            // output yyyy / mm / dd 16:00:08.169 | Fatal | das ist FATAL-logger
        }
    }

}

