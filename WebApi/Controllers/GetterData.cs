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
    }
}
