using Entities.Models;

namespace BlazorProduct.Client.HttpRepository
{
    public interface IProductHttpRepository
    {
        Task<List<Product>> GetProducts();
        Task CallChartEndpoint();
    }
}
