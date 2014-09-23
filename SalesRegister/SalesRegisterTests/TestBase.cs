using System;

namespace SalesRegisterTests
{
    internal abstract class TestBase
    {
        public FakeScannerDataProvider ScannerDataProvider { get; private set; }

        protected TestBase()
        {
            ScannerDataProvider = new FakeScannerDataProvider();
        }
    }
}
