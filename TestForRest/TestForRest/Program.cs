
using TestForRest;

BaseHttpService httpService=new BaseHttpService();
TestService testService = new TestService(httpService);

await Start();
async Task Start()
{

    Console.WriteLine("Выберите действие\n 1 - Добавить пользователя\n 2-Удалить пользователя\n" +
                      " 3-Изменить пользователя\n 4-Получить всех пользователей\n 5-Получить одного пользователя");
    var index = Convert.ToInt32(Console.ReadLine());
    switch (index)
    {
        case 1:
            var AddUserResult = await testService.Add();
            Console.WriteLine(AddUserResult);
            break;
        case 2:
            var DeleteResult = await testService.Delete();
            Console.WriteLine(DeleteResult);
            break;
        case 3:
            //testService.Test();
            var UpdateResult =await testService.Update();
            Console.WriteLine(UpdateResult);
            break;
        case 4:
            var testUsers =await testService.GetAll();
            Console.WriteLine(testUsers);
            break;
        case 5:
            var testUser= await testService.Get();
            Console.WriteLine(testUser);
            break;
        default:
            Console.WriteLine("Что-то не так");
            break;
    }
    await Start();
}