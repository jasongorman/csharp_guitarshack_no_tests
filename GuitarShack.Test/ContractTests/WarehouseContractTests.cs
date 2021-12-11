namespace GuitarShack.Test.ContractTests
{
    public class WarehouseContractTests : AbstractWarehouseTests
    {
        protected override WebService<Product> CreateService()
        {
            return new WebService<Product>("https://6hr1390c1j.execute-api.us-east-2.amazonaws.com/default/product");
        }
    }
}