using System.Collections.Generic;

namespace GuitarShack.Test.UnitTests
{
    public class SalesHistoryUnitTests : AbstractSalesHistoryTestsBase
    {
        protected override WebService<Sales> CreateService()
        {
            return new StubWebService("");
        }
        
        private class StubWebService : WebService<Sales>
        {
            public StubWebService(string baseUrl) : base(baseUrl)
            {
            }

            public override Sales Fetch(Dictionary<string, string> queryParams)
            {
                return new Sales() { total = 16 };
            }
        }
    }
}