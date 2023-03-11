using MiNegocio.Shared.Models;
using MiNegocio.Shared.Request;
using Radzen;
using System.Net.Http.Json;

namespace MiNegocio.Client.Service
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;
        private readonly NotificationService _notificationService;

        public ProductService(HttpClient httpClient, NotificationService notificationService)
        {
            _httpClient = httpClient;
            _notificationService = notificationService;
        }

        public async Task<Product?> GetProduct(Guid id) {
            var resul = await _httpClient.GetFromJsonAsync<Product?>($"api/Products/{id}");
            return resul;
        }
        public async Task<bool> AddProduct(Product product)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Products", product);
            if (result.StatusCode == System.Net.HttpStatusCode.Created)
            {
                _notificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = "Producto adcionado", Duration = 4000 });
                return true;
            }
            else
            {
                _notificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = result.StatusCode.ToString(), Duration = 4000 });
                return false;
            }
        }

        public async Task<bool> EditProduct(Product product)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Products/{product.Id}", product);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _notificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = "Producto editado", Duration = 4000 });
                return true;
            }
            else
            {
                _notificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = result.StatusCode.ToString(), Duration = 4000 });
                return false;
            }
        }

        public async Task<bool> InputProduct(Guid id, ProductInput productInput)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Products/input/{id}", productInput);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _notificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = "Producto editado", Duration = 4000 });
                return true;
            }
            else
            {
                _notificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = result.StatusCode.ToString(), Duration = 4000 });
                return false;
            }
        }

        public async Task<bool> DeleteProduct(Product product)
        {
            var result = await _httpClient.DeleteAsync($"api/Products/{product.Id}");
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _notificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = "Product Eliminado", Duration = 4000 });
                return true;
            }
            else
            {
                _notificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = result.StatusCode.ToString(), Duration = 4000 });
                return false;
            }
        }

    }
}
