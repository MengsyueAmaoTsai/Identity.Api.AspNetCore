using System.Net.Http.Json;

namespace RichillCapital.Identity.Api.AcceptanceTests;

public static class HttpClientExtensions
{
    public static async Task<(HttpResponseMessage, TResult?)> GetAndDeserializeAsync<TResult>(
        this HttpClient client,
        string path)
    {
        var response = await client.GetAsync(path);

        if (!response.IsSuccessStatusCode)
        {
            return (response, default!);
        }

        var result = await response.Content.ReadFromJsonAsync<TResult>();

        return (response, result);
    }
}