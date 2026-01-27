namespace IPMA_Api.Services
{
    public class Repository 
    {
        private string url = "https://api.ipma.pt";

        private readonly HttpClient _http;

        public Repository(HttpClient http)
        {
            _http = http;
        }

        


    }
}
