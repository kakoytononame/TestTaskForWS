using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace TestForRest;

public class BaseHttpService:IBaseHttpService
{
    
    private readonly HttpClient _httpClient;

    public BaseHttpService()
    {
        _httpClient = new HttpClient();
    }
    public async Task<HttpResponseMessage> Get(string URL)
    {
        var response=await _httpClient.GetAsync(URL);
        return response;
    }

    public async Task<HttpResponseMessage> Put(string URL,JsonContent data)
    {

        return await _httpClient.PutAsync(URL, data);
    }

    public async Task<HttpResponseMessage> Post(string URL,JsonContent data)
    {
       return await _httpClient.PostAsync(URL,data);
    }

    public async Task<HttpResponseMessage> Delete(string URL,String name)
    {
        return await _httpClient.DeleteAsync(URL+$"?Name={name}");
    }
}