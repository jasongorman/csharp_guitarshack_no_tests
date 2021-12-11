using System;
using System.Globalization;
using Xunit;

namespace GuitarShack.Test
{
    public abstract class AbstractSalesHistoryTestsBase
    {
        [Fact]
        public void FetchesTotalSalesForProductWithinDateRange()
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            ISalesHistory salesHistory = new ProductSalesHistory(CreateService());
            Assert.Equal(16, salesHistory.Total(811, DateTime.ParseExact("7/17/2020", "M/d/yyyy", provider), DateTime.ParseExact("7/27/2020", "M/d/yyyy", provider)));
        }

        protected abstract WebService<Sales> CreateService();
    }
}