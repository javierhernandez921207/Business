using MiNegocio.Shared.Models;
using Radzen;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace MiNegocio.Client.Service
{
    public class BusinessService
    {
        private readonly HttpClient _httpClient;
        private readonly NotificationService _notificationService;

        public BusinessService(HttpClient httpClient, NotificationService notificationService)
        {
            _httpClient = httpClient;
            _notificationService = notificationService;
        }

        public async Task<Business[]?> GetBusinessAsync()
        {
            return await _httpClient.GetFromJsonAsync<Business[]>("api/Businesses");
        }

        public async Task<Business?> GetBusinessByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Business?>($"api/Businesses/{id}");
        }

        public async Task<bool> AddBusiness(Business business) {
            var result = await _httpClient.PostAsJsonAsync("api/Businesses", business);
            if (result.StatusCode == System.Net.HttpStatusCode.Created)
            {
                _notificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = "Business Add", Duration = 4000 });
                return true;
            }
            else
            {
                _notificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = result.StatusCode.ToString(), Duration = 4000 });
                return false;
            }
        }

        public async Task<bool> EditBusiness(Business business)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Businesses/{business.Id}", business);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _notificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = "Business updated", Duration = 4000 });
                return true;
            }
            else
            {
                _notificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Error, Summary = result.StatusCode.ToString(), Duration = 4000 });
                return false;
            }
        }

        public async Task<bool> DeleteBusiness(Business business)
        {            
            var result = await _httpClient.DeleteAsync($"api/Businesses/{business.Id}");
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _notificationService.Notify(new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Success", Detail = "Business Deleted", Duration = 4000 });
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
