using FakeStore.Models;
using System.Net.Http.Json;

namespace FakeStore.Services
{
    public class FakeService
    {

        private readonly HttpClient _httpClient;

        public FakeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var response = await _httpClient.GetAsync("https://fakestoreapi.com/products");
            response.EnsureSuccessStatusCode();
            var products = await response.Content.ReadFromJsonAsync<List<Product>>();
            return products;
        }

        public async Task<Product> GetProductAsync(int id)
        {
            var response = await _httpClient.GetAsync($"https://fakestoreapi.com/products/{id}");
            response.EnsureSuccessStatusCode();
            var product = await response.Content.ReadFromJsonAsync<Product>();
            return product;
        }

        public async Task<Product> CreatePostAsync(Product newProduct)
        {
            var response = await _httpClient.PostAsJsonAsync("https://fakestoreapi.com/products", newProduct);
            response.EnsureSuccessStatusCode();
            var createdProduct = await response.Content.ReadFromJsonAsync<Product>();
            return createdProduct;
        }

        public async Task UpdatePostAsync(int id, Product updatedProduct)
        {
            var response = await _httpClient.PutAsJsonAsync($"https://fakestoreapi.com/products/{id}", updatedProduct);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteProductAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://fakestoreapi.com/products/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
