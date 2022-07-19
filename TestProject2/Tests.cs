using FluentAssertions;
using NUnit.Framework;

namespace TestProject2
{
    [TestFixture]
    public class NssmProcessTest
    {
        private NssmProcess _nssmProcess;

        [Test]
        public void problem_1()
        {
            _nssmProcess = new NssmProcess(@"C:\Users\User\RiderProjects\TestProject2\nssm.exe");
            _nssmProcess.Exec("remove not-exist-service confirm").Should().Contain("Can't open service!");
        }

        [Test]
        public void problem_2()
        {
            _nssmProcess = new NssmProcess(@"C:\Users\User\RiderProjects\TestProject2\nssm.exe");
            _nssmProcess.Exec("remove not-exist-service").Should().Contain("Can't open service!");
        }


        [Test]
        public void test_case()
        {
            _nssmProcess = new NssmProcess("ipconfig.exe");
            _nssmProcess.Exec("").Should().Contain("Windows IP");
        }
    }
}