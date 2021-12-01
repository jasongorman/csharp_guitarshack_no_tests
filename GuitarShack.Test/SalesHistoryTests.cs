using System;
using Xunit;

namespace GuitarShack.Test
{
    public class SalesHistoryTests
    {
        [Fact]
        public void FetchesTotalSalesForProductWithinDateRange()
        {
            ISalesHistory salesHistory = new ProductSalesHistory(new WebService<Sales>($"https://gjtvhjg8e9.execute-api.us-east-2.amazonaws.com/default/sales"));
            Assert.Equal(16, salesHistory.Total(811, DateTime.Parse("17/7/2020"), DateTime.Parse("27/7/2020")));
        }
    }
}