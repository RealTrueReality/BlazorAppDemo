using System.Net.Http.Headers;
using System.Text.Json;
using AspireApp1.Models.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace AspireApp1.Web;

public class ApiClient(HttpClient httpClient, ProtectedLocalStorage localStorage) {
    public async Task<T?> GetFromJsonAsync<T>(string path) {
        await SetAuthHeader();
        return await httpClient.GetFromJsonAsync<T>(path);
    }

    public async Task<T1?> PutAsJsonAsync<T1, T2>(string path, T2 data) {
        await SetAuthHeader();
        var response = await httpClient.PutAsJsonAsync(path, data);
        if (response.IsSuccessStatusCode) {
            return await response.Content.ReadFromJsonAsync<T1>(options: new JsonSerializerOptions()
                { PropertyNameCaseInsensitive = true });
        }

        return default;
    }


    public async Task<T1?> PostAsJsonAsync<T1, T2>(string apiProduct, T2 product) {
        await SetAuthHeader();
        var response = await httpClient.PostAsJsonAsync(apiProduct, product);
        if (response.IsSuccessStatusCode) {
            return await response.Content.ReadFromJsonAsync<T1>(options: new JsonSerializerOptions()
                { PropertyNameCaseInsensitive = true });
        }

        return default;
    }

    public async Task<T?> DeleteAsync<T>(string id) {
        await SetAuthHeader();
        var response = await httpClient.DeleteAsync(id);
        if (response.IsSuccessStatusCode) {
            return await response.Content.ReadFromJsonAsync<T>(options: new JsonSerializerOptions()
                { PropertyNameCaseInsensitive = true });
        }

        return default;
    }

    public async Task SetAuthHeader() {
        var token = (await localStorage.GetAsync<string>("token")).Value;
        if (token is not null) {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}