using System;
using FluentAssertions;
using NUnit.Framework;

namespace TestProject2
{
    [TestFixture]
    public class NssmProcessTest
    {
        private NssmProcess _nssmProcess;

        [SetUp]
        public void SetUp()
        {
            // _nssmProcess = new NssmProcess("ipconfig.exe");
            _nssmProcess = new NssmProcess(@"C:\Users\User\RiderProjects\TestProject2\nssm.exe");
        }

        [Test]
        public void exec_command_at_nssm()
        {
            // _nssmProcess.Exec("").Should().Contain("NSSM: The non-sucking service manager");
            _nssmProcess.Exec("remove not-exist-service confirm").Should().Contain("Can't open service!");
        }
    }
}