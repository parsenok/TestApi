using Xunit;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Bogus;
using TestApi;
using TestApi.DataSet;
using Serilog;
using Serilog.Core;
using Allure.Xunit.Attributes;
using Allure.Commons;
using Bogus.DataSets;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Xml.Linq;
namespace TestProject1
{
    [Collection("MyCollection")]
    public class UnitTest1
    {
        private readonly HttpClient client;
        private readonly ILogger logger;
        private readonly Faker faker;
        public UnitTest1()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:3000/");

            logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.File("Log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            faker = new Faker();

        }
        [AllureLink("https://example.com/issue/1234")]
        [AllureSeverity((Allure.Net.Commons.SeverityLevel)SeverityLevel.normal)]
        [AllureOwner("Name")]
        [Fact]
        public async Task Test_CreateUser()
        {
            var newUser = new User { ID = 2, Name = faker.Name.FullName(), Login = faker.Internet.Email() };
            var jsonUser = JsonConvert.SerializeObject(newUser);
            var content = new StringContent(jsonUser, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("User", content);
            Assert.True(response.IsSuccessStatusCode);
        }
        [AllureLink("https://example.com/issue/1234")]
        [AllureSeverity((Allure.Net.Commons.SeverityLevel)SeverityLevel.normal)]
        [AllureOwner("Name")]
        [Fact]
        public async Task Test_GetUser()
        {
            var response = await client.GetAsync("User/2");

            response.EnsureSuccessStatusCode();

            var user = await response.Content.ReadAsStringAsync();
            var retrievedUser = JsonConvert.DeserializeObject<User>(user);

            Assert.NotNull(retrievedUser);
        }
        [AllureLink("https://example.com/issue/1234")]
        [AllureSeverity((Allure.Net.Commons.SeverityLevel)SeverityLevel.normal)]
        [AllureOwner("Name")]
        [Fact]
        public async Task Test_UpdateUser()
        {
            var updateUser = new User { ID = 1, Name = faker.Name.FullName(), Login = faker.Internet.Email() };
            var jsonUser = JsonConvert.SerializeObject(updateUser);
            var content = new StringContent(jsonUser, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("Users/1", content);

            Assert.True(response.IsSuccessStatusCode);
        }
        [AllureLink("https://example.com/issue/1234")]
        [AllureSeverity((Allure.Net.Commons.SeverityLevel)SeverityLevel.normal)]
        [AllureOwner("Name")]
        [Fact]
        public async Task Test_DeleteUser()
        {
            var response = await client.DeleteAsync("Users/1");

            Assert.True(response.IsSuccessStatusCode);
        }
        [AllureLink("https://example.com/issue/1234")]
        [AllureSeverity((Allure.Net.Commons.SeverityLevel)SeverityLevel.normal)]
        [AllureOwner("Name")]
        [Fact]
        public async Task Test_CreatePost()
        {
            var newPost = new Posts { Id = 2, comments_count = 1, comments_like = 4, comments_repost = 2, User = faker.Name.FullName() };
            var jsonPost = JsonConvert.SerializeObject(newPost);
            var content = new StringContent(jsonPost, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("Posts", content);

            Assert.True(response.IsSuccessStatusCode);
        }

        [AllureLink("https://example.com/issue/1234")]
        [AllureSeverity((Allure.Net.Commons.SeverityLevel)SeverityLevel.normal)]
        [AllureOwner("Name")]
        [Fact]
        public async Task Test_GetPost()
        {
            var response = await client.GetAsync("Posts/1");

            response.EnsureSuccessStatusCode();

            var post = await response.Content.ReadAsStringAsync();
            var retrievedPost = JsonConvert.DeserializeObject<Posts>(post);

            Assert.NotNull(retrievedPost);
        }

        [AllureLink("https://example.com/issue/1234")]
        [AllureSeverity((Allure.Net.Commons.SeverityLevel)SeverityLevel.normal)]
        [AllureOwner("Name")]
        [Fact]
        public async Task Test_UpdatePost()
        {
            var updatePost = new Posts { Id = 3, comments_count = 0, comments_like = 6, comments_repost = 0, User = faker.Name.FullName() };
            var jsonPost = JsonConvert.SerializeObject(updatePost);
            var content = new StringContent(jsonPost, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("posts/1", content);

            Assert.True(response.IsSuccessStatusCode);
        }

        [AllureLink("https://example.com/issue/1234")]
        [AllureSeverity((Allure.Net.Commons.SeverityLevel)SeverityLevel.normal)]
        [AllureOwner("Name")]
        [Fact]
        public async Task Test_DeletePost()
        {
            var response = await client.DeleteAsync("Posts/3");

            Assert.True(response.IsSuccessStatusCode);
        }
        [AllureLink("https://example.com/issue/1234")]
        [AllureSeverity((Allure.Net.Commons.SeverityLevel)SeverityLevel.normal)]
        [AllureOwner("Name")]
        [Fact]
        public async Task Test_CreateComment()
        {
            var newComment = new Comments { Id = 3, text = faker.Company.Bs(), coms_like = 4 };
            var jsonComment = JsonConvert.SerializeObject(newComment);
            var content = new StringContent(jsonComment, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("comments", content);

            Assert.True(response.IsSuccessStatusCode);
        }

        [AllureLink("https://example.com/issue/1234")]
        [AllureSeverity((Allure.Net.Commons.SeverityLevel)SeverityLevel.normal)]
        [AllureOwner("Name")]
        [Fact]
        public async Task Test_GetComment()
        {
            var response = await client.GetAsync("comments/3");

            response.EnsureSuccessStatusCode();

            var comment = await response.Content.ReadAsStringAsync();
            var retrievedComment = JsonConvert.DeserializeObject<Comments>(comment);

            Assert.NotNull(retrievedComment);
        }

        [AllureLink("https://example.com/issue/1234")]
        [AllureSeverity((Allure.Net.Commons.SeverityLevel)SeverityLevel.normal)]
        [AllureOwner("Name")]
        [Fact]
        public async Task Test_UpdateComment()
        {
            var updateComment = new Comments { Id = 1, text = faker.Company.Bs(), coms_like = 3 };
            var jsonComment = JsonConvert.SerializeObject(updateComment);
            var content = new StringContent(jsonComment, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("comments/1", content);

            Assert.True(response.IsSuccessStatusCode);
        }

        [AllureLink("https://example.com/issue/1234")]
        [AllureSeverity((Allure.Net.Commons.SeverityLevel)SeverityLevel.normal)]
        [AllureOwner("Name")]
        [Fact]
        public async Task Test_DeleteComment()
        {
            var response = await client.DeleteAsync("comments/3");

            Assert.True(response.IsSuccessStatusCode);
        }
        [AllureLink("https://example.com/issue/1234")]
        [AllureSeverity((Allure.Net.Commons.SeverityLevel)SeverityLevel.normal)]
        [AllureOwner("Name")]
        [Fact]
        public async Task Test_CreateSub()
        {
            var newSub = new Sub { Id = 2, User = faker.Name.FullName() };
            var jsonSub = JsonConvert.SerializeObject(newSub);
            var content = new StringContent(jsonSub, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("Sub", content);

            Assert.True(response.IsSuccessStatusCode);
        }

        [AllureLink("https://example.com/issue/1234")]
        [AllureSeverity((Allure.Net.Commons.SeverityLevel)SeverityLevel.normal)]
        [AllureOwner("Name")]
        [Fact]
        public async Task Test_GetSub()
        {
            var response = await client.GetAsync("Sub/2");

            response.EnsureSuccessStatusCode();

            var album = await response.Content.ReadAsStringAsync();
            var retrievedAlbum = JsonConvert.DeserializeObject<Sub>(album);

            Assert.NotNull(retrievedAlbum);
        }

        [AllureLink("https://example.com/issue/1234")]
        [AllureSeverity((Allure.Net.Commons.SeverityLevel)SeverityLevel.normal)]
        [AllureOwner("Name")]
        [Fact]
        public async Task Test_UpdateSub()
        {
            var updateSub = new Sub { Id = 1, User = faker.Name.FullName() };
            var jsonSub = JsonConvert.SerializeObject(updateSub);
            var content = new StringContent(jsonSub, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("Sub/1", content);

            Assert.True(response.IsSuccessStatusCode);
        }

        [AllureLink("https://example.com/issue/1234")]
        [AllureSeverity((Allure.Net.Commons.SeverityLevel)SeverityLevel.normal)]
        [AllureOwner("Name")]
        [Fact]
        public async Task Test_DeleteSub()
        {
            var response = await client.DeleteAsync("Sub/1");

            Assert.True(response.IsSuccessStatusCode);
        }

        [AllureLink("https://example.com/issue/1234")]
        [AllureSeverity((Allure.Net.Commons.SeverityLevel)SeverityLevel.normal)]
        [AllureOwner("Name")]
        [Fact]
        public async Task Test_CreateU_Subs()
        {
            var newU_Subs = new U_Subs { Id = 4, User = faker.Name.FullName() };
            var jsonU_Subs = JsonConvert.SerializeObject(newU_Subs);
            var content = new StringContent(jsonU_Subs, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("U_Subs", content);

            Assert.True(response.IsSuccessStatusCode);
        }

        [AllureLink("https://example.com/issue/1234")]
        [AllureSeverity((Allure.Net.Commons.SeverityLevel)SeverityLevel.normal)]
        [AllureOwner("Name")]
        [Fact]
        public async Task Test_GetU_Subs()
        {
            var response = await client.GetAsync("U_Subs/4");

            response.EnsureSuccessStatusCode();

            var U_Subs = await response.Content.ReadAsStringAsync();
            var retrievedU_Subs = JsonConvert.DeserializeObject<U_Subs>(U_Subs);

            Assert.NotNull(retrievedU_Subs);
        }
        [AllureLink("https://example.com/issue/1234")]
        [AllureSeverity((Allure.Net.Commons.SeverityLevel)SeverityLevel.normal)]
        [AllureOwner("Name")]
        [Fact]
        public async Task Test_UpdateU_Subs()
        {
            var updateU_Subs = new U_Subs { Id = 1, User = faker.Name.FullName() };
            var jsonU_Subs = JsonConvert.SerializeObject(updateU_Subs);
            var content = new StringContent(jsonU_Subs, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("U_Subs/1", content);

            Assert.True(response.IsSuccessStatusCode);
        }

        [AllureLink("https://example.com/issue/1234")]
        [AllureSeverity((Allure.Net.Commons.SeverityLevel)SeverityLevel.normal)]
        [AllureOwner("Name")]
        [Fact]
        public async Task Test_DeleteU_Subs()
        {
            var response = await client.DeleteAsync("U_Subs/2");

            Assert.True(response.IsSuccessStatusCode);
        }
    }
}