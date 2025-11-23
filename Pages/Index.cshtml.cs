using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Codeworkhub.Pages
{
    public class IndexModel : PageModel
    {
        public List<CardItem> Cards { get; set; }

        public void OnGet()
        {
            string Link = "/ComingSoon";
            Cards = new List<CardItem>
            {
                new("Math Quiz Game", "Challenge yourself with auto-generated math problems.", "/Apps/MathQuiz/Quiz", "🧠"),
                new("Rock-Paper-Scissors", "Play against AI and track your win streak.", "/Apps/RockPaperScissor/Game", "✊"),
                new("Typing Speed Test", "Measure your words per minute and accuracy.", "/Apps/Typefast/Typefast", "⌨️"),
                new("Flashcards Study Tool", "Flip through learning cards with smooth animations.", Link, "📚"),
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
