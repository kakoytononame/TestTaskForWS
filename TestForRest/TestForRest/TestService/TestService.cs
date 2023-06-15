using System.Net.Http.Json;
using System.Text.Json;

namespace TestForRest;

public class TestService
{
    private readonly IBaseHttpService _baseHttpService;
    public TestService(IBaseHttpService baseHttpService)
    {
        _baseHttpService = baseHttpService;
    }

    public async Task<string> Get()
    {
        var name = "Folder1.1.1";
        var result=await (await _baseHttpService.Get($"http://localhost:5112/User/Get?ParrentName={name}")).Content.ReadAsStringAsync();
        return result;
    }

    public async Task<string> GetAll()
    {
        var result=await (await _baseHttpService.Get($"http://localhost:5112/User/GetAll")).Content.ReadAsStringAsync();
        return result;
    }

    public async Task<string> Update()
    {
        var JsonData = JsonContent.Create(
            new
            {
                Id = Guid.Parse("52f163d0-e358-4e11-9f82-dcce1caaaaaa"),
                Name = "Folder1.1.1"
            });

        var response = await _baseHttpService.Put($"http://localhost:5112/User/Update", JsonData);
        var result= await response.Content.ReadAsStringAsync();
        return result;
    }

    public async Task<string> Delete()
    {
        var name = "Folder1.1.1";
        var response = await _baseHttpService.Delete("http://localhost:5112/User/Delete",name);
        var result =await response.Content.ReadAsStringAsync();
        return result;
    }

    public async Task<string> Add()
    {
        var JsonData = JsonContent.Create(
            new
            {
                ParrentName = "Folder1",
                NewName = "Folder1.3"
            });
        var response = await _baseHttpService.Post("http://localhost:5112/User/Create", JsonData);
        var result = await response.Content.ReadAsStringAsync();
        return result;
    }   
    
}