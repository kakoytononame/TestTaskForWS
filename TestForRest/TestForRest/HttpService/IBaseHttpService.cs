using System.Net.Http.Json;

namespace TestForRest;

public interface IBaseHttpService
{
    public Task<HttpResponseMessage> Get(string URL);

    public Task<HttpResponseMessage> Put(string URL, JsonContent data);

    public Task<HttpResponseMessage> Post(string URL, JsonContent data);

    public Task<HttpResponseMessage> Delete(string URL, String name);


}