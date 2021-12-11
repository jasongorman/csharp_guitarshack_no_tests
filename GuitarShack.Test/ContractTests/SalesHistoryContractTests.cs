namespace GuitarShack.Test.ContractTests
{
    public class SalesHistoryContractTests : AbstractSalesHistoryTestsBase
    {
        protected override WebService<Sales> CreateService()
        {
            return new WebService<Sales>($"https://gjtvhjg8e9.execute-api.us-east-2.amazonaws.com/default/sales");
        }
    }
}