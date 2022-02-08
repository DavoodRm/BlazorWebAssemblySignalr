using System.Text.Json;
using Entities.Models;

namespace BlazorProduct.Client.HttpRepository
{
	public class ProductHttpRepository : IProductHttpRepository
	{
		private readonly HttpClient _client;

		public ProductHttpRepository(HttpClient client)
		{
			_client = client;
		}

		public async Task CallChartEndpoint()
		{
			var result = await _client.GetAsync("chart");
			if (!result.IsSuccessStatusCode)
				Console.WriteLine("Something went wrong with the response");
		}

		public async Task<List<Product>> GetProducts()
		{
			var response = await _client.GetAsync("https://localhost:5011/api/products");
			var content = await response.Content.ReadAsStringAsync();
			if (!response.IsSuccessStatusCode)
			{
				throw new ApplicationException(content);
			}

			var products = JsonSerializer.Deserialize<List<Product>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
			return products;
		}
	}
}
