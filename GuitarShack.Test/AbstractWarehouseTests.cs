using Xunit;

namespace GuitarShack.Test
{
    public abstract class AbstractWarehouseTests
    {
        [Fact]
        public void FetchesProductInformation()
        {
            IWarehouse warehouse = new ProductWarehouse(CreateService());
            Product product = warehouse.GetProduct(811);
            Assert.Equal(27, product.stock);
        }

        protected abstract WebService<Product> CreateService();
    }
}