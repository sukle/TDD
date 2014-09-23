using System;

namespace SalesRegisterTests
{
    internal abstract class TestBase
    {
        public FakeSalesDataProvider SalesDataProvider { get; private set; }

        protected TestBase()
        {
            SalesDataProvider = new FakeSalesDataProvider();
        }
    }
}
