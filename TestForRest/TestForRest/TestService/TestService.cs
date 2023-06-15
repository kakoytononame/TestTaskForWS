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
        var id = Guid.Parse("52f163d0-e358-4e11-9f82-dcce1ca464ff");
        var result=await (await _baseHttpService.Get($"http://localhost:5112/User/Get?id={id}")).Content.ReadAsStringAsync();
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
                Id = Guid.Parse("52f163d0-e358-4e11-9f82-dcce1ca464ff"),
                Login = "TestUser",
                Password = "NewPassword"
            });

        var response = await _baseHttpService.Put($"http://localhost:5112/User/Update", JsonData);
        var result= await response.Content.ReadAsStringAsync();
        return result;
    }

    public async Task<string> Delete()
    {
        var id = Guid.Parse("a7be82ef-05f3-44d8-a60e-b00895d5c82f"); //удаление пользователя номер 5;
        var response = await _baseHttpService.Delete("http://localhost:5112/User/Delete",id);
        var result =await response.Content.ReadAsStringAsync();
        return result;
    }

    public async Task<string> Add()
    {
        var JsonData = JsonContent.Create(
            new
            {
                Login = "NewTestUser",
                Password = "NewPassword"
            });
        var response = await _baseHttpService.Post("http://localhost:5112/User/Create", JsonData);
        var result = await response.Content.ReadAsStringAsync();
        return result;
    }

    public void Test()
    {
        var JsonData = JsonContent.Create(
            new
            {
                Id = Guid.Parse("52f163d0-e358-4e11-9f82-dcce1ca464ff"),
                Login = "TestUser",
                Password = "NewPassword"
            });

        var response =  _baseHttpService.Put($"http://localhost:5112/User/Update", JsonData).Result;
        var result= response.Content.ReadAsStringAsync().Result;
    }
}