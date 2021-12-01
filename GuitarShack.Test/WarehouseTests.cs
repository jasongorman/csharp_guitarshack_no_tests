using Xunit;

namespace GuitarShack.Test
{
    public class WarehouseTests
    {
        [Fact]
        public void FetchesProductInformation()
        {
            IWarehouse warehouse = new ProductWarehouse(new WebService<Product>("https://6hr1390c1j.execute-api.us-east-2.amazonaws.com/default/product"));
            Product product = warehouse.GetProduct(811);
            Assert.Equal(27, product.stock);
        }
    }
}