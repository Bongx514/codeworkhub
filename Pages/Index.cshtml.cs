using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Codeworkhub.Pages
{
    public class IndexModel : PageModel
    {
        public List<CardItem> Cards { get; set; }

        public void OnGet()
        {
            Cards = new List<CardItem>
            {
                new("Math Quiz Game", "Challenge yourself with auto-generated math problems.", "/Apps/MathQuiz/Quiz", "🧠"),
                new("Rock-Paper-Scissors", "Play against AI and track your win streak.", "/RPS", "✊"),
                new("Typing Speed Test", "Measure your words per minute and accuracy.", "/TypingTest", "⌨️"),
                new("Flashcards Study Tool", "Flip through learning cards with smooth animations.", "/Flashcards", "📚"),
                new("BMI Calculator", "Find out your body mass index using your height & weight.", "/BMI", "⚖️"),
                new("Unit Converter", "Convert weight, currency, length & temperature.", "/Converter", "🔁"),
                new("Memory Card Flip Game", "Match cards and beat the clock.", "/MemoryGame", "🃏"),
                new("Trivia Game", "Trivia questions with scoring and review.", "/Trivia", "❓"),
                new("Budget Planner", "Track expenses with session-based storage.", "/Budget", "💰"),
                new("Sudoku Mini", "Play or auto-solve Sudoku puzzles.", "/Sudoku", "🔢")
            };
        }

        public record CardItem(string Title, string Description, string Link, string Icon);
    }
}
