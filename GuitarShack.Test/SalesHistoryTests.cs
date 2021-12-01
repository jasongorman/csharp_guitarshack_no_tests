using System;
using System.Globalization;
using Xunit;

namespace GuitarShack.Test
{
    public class SalesHistoryTests
    {
        [Fact]
        public void FetchesTotalSalesForProductWithinDateRange()
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            ISalesHistory salesHistory = new ProductSalesHistory(new WebService<Sales>($"https://gjtvhjg8e9.execute-api.us-east-2.amazonaws.com/default/sales"));
            Assert.Equal(16, salesHistory.Total(811, DateTime.ParseExact("7/17/2020", "M/d/yyyy", provider), DateTime.ParseExact("7/27/2020", "M/d/yyyy", provider)));
        }
    }
}