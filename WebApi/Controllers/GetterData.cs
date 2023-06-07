using System.Text.Json;

namespace WebApi.Controllers
{
    public class GetterData
    {
        readonly HttpClient client;
        private String ACSESS_TOKEN;
        private String Version;

        public GetterData()
        {
            client = new HttpClient();
            ACSESS_TOKEN = File.ReadAllText("ACSESS_TOKEN.txt");
            Version = "5.131";
        }

        async Task<PostsNamespace.VKUsersPosts> GetLast5Posts(string ID)
        {
            string? result = "";

            HttpResponseMessage response = await client.GetAsync($"https://api.vk.com/method/wall.get?owner_id={ID}&count=5&lang=ru&access_token={ACSESS_TOKEN}&v={Version}");
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsStringAsync();
            }

            PostsNamespace.VKUsersPosts? posts = JsonSerializer.Deserialize<PostsNamespace.VKUsersPosts>(result, PostsNamespace.SerContext.Default.VKUsersPosts);

            return posts;
        }
    }
}
