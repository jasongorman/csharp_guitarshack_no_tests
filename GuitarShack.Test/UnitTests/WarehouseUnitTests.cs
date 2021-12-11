using System.Collections.Generic;

namespace GuitarShack.Test.UnitTests
{
    public class WarehouseUnitTests : AbstractWarehouseTests
    {
        protected override WebService<Product> CreateService()
        {
            return new StubProductService("");
        }

        private class StubProductService : WebService<Product>
        {
            public StubProductService(string baseUrl) : base(baseUrl)
            {
            }

            public override Product Fetch(Dictionary<string, string> queryParams)
            {
                return new Product() { id = 811, stock = 27, leadTime = 14 };
            }
        }
    }
}