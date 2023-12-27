
//using Bogus;
//using Newtonsoft.Json;
//using System.Text;
//using TestApi.DataSet;

//class Program
//{
//    private readonly HttpClient client;
//    private readonly Faker faker;
//    static async Task Main()
//    {
//        string baseURL = "http://localhost:3000";
//        await CreateUser(baseURL, new { title = "New Post", author = "New Author" });
//    }
//    public async Task CreateUser(string baseURL, object User)
//    {
//        var newUser = new User { ID = 2, Name = faker.Name.FullName(), Login = faker.Internet.Email() };
//        var jsonUser = JsonConvert.SerializeObject(newUser);
//        var content = new StringContent(jsonUser, Encoding.UTF8, "application/json");
//        var response = await client.PostAsync("User", content);
//    }
//}
