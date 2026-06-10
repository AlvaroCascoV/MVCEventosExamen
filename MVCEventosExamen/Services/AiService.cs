namespace MVCEventosExamen.Services
{
    public class AiService
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _config;

        public AiService(HttpClient http, IConfiguration config)
        {
            _http = http;
            _config = config;
        }

        public async Task<string> AskAsync(string question)
        {
            var baseUrl = _config["AWS:LambdaUrl"];

            var url = $"{baseUrl}/ai?q={Uri.EscapeDataString(question)}";

            return await _http.GetStringAsync(url);
        }
    }
}
