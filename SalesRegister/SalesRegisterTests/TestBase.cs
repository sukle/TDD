using System;

namespace SalesRegisterTests
{
    internal abstract class TestBase
    {
        public FakeRegisterDataProvider RegisterDataProvider { get; private set; }

        protected TestBase()
        {
            RegisterDataProvider = new FakeRegisterDataProvider();
        }
    }
}
