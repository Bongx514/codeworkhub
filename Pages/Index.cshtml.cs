using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Codeworkhub.Pages
{
    public class IndexModel : PageModel
    {
        public List<CardItem> Cards { get; set; }

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public IndexModel(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClient = httpClientFactory.CreateClient();
            _config = config;
        }

        public class ChatRequest
        {
            public string userMessage { get; set; }
        }

        public class ChatResponse
        {
            public string response { get; set; }
        }

        public async Task<JsonResult> OnPostChat([FromBody] ChatRequest request)
        {
            var apiKey = _config["OpenAI:ApiKey"];

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", apiKey);

            var payload = new
            {
                model = "gpt-4o-mini",
                messages = new[]
                {
                new { role = "user", content = request.userMessage }
            }
            };

            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
            var json = await result.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(json);
            var reply = doc.RootElement.GetProperty("choices")[0]
                                       .GetProperty("message")
                                       .GetProperty("content")
                                       .GetString();

            return new JsonResult(new ChatResponse { response = reply });
        }

        public void OnGet()
        {
            string Link = "/ComingSoon";
            Cards = new List<CardItem>
            {
                new("Math Quiz Game", "Challenge yourself with auto-generated math problems.", "/Apps/MathQuiz/Quiz", "🧠"),
                new("Rock-Paper-Scissors", "Play against AI and track your win streak.", "/Apps/RockPaperScissor/Game", "✊"),
                new("Typing Speed Test", "Measure your words per minute and accuracy.", "/Apps/Typefast/Typefast", "⌨️"),
                new("Flashcards Study Tool", "Flip through learning cards with smooth animations.", "/Apps/StudyTools/Flashcards", "📚"),
                new("BMI Calculator", "Find out your body mass index using your height & weight.", Link, "⚖️"),
                new("Unit Converter", "Convert weight, currency, length & temperature.", Link, "🔁"),
                new("Memory Card Flip Game", "Match cards and beat the clock.", Link, "🃏"),
                new("Trivia Game", "Trivia questions with scoring and review.", Link, "❓"),
                new("Budget Planner", "Track expenses with session-based storage.", Link, "💰"),
                new("Sudoku Mini", "Play or auto-solve Sudoku puzzles.", Link, "🔢")
            };
        }

        public record CardItem(string Title, string Description, string Link, string Icon);
    }
}
