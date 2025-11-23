using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Codeworkhub.Pages.Apps.StudyTools
{
    public class FlashcardsModel : PageModel
    {
        public List<Flashcard> Cards { get; set; } = new List<Flashcard>();
        public Dictionary<string, List<Flashcard>> Categories { get; set; }

        public void OnGet()
        {
            Categories = new Dictionary<string, List<Flashcard>>()
            {
                ["math"] = new List<Flashcard>()
                {
                    new Flashcard("2 + 2?", "4"),
                    new Flashcard("5 x 3?", "15"),
                    new Flashcard("10 ÷ 2?", "5"),
                    new Flashcard("Square root of 16?", "4"),
                    new Flashcard("7 + 8?", "15"),
                    new Flashcard("12 - 5?", "7"),
                    new Flashcard("9 x 6?", "54"),
                    new Flashcard("18 ÷ 3?", "6"),
                    new Flashcard("5^2?", "25"),
                    new Flashcard("15% of 200?", "30")
                },
                ["science"] = new List<Flashcard>()
                {
                    new Flashcard("H2O is chemical formula for?", "Water"),
                    new Flashcard("Speed of light?", "299,792,458 m/s"),
                    new Flashcard("Our planet?", "Earth"),
                    new Flashcard("Gas plants use to make food?", "Carbon dioxide"),
                    new Flashcard("Force formula?", "Mass x Acceleration"),
                    new Flashcard("Symbol for Gold?", "Au"),
                    new Flashcard("Organ in humans that pumps blood?", "Heart"),
                    new Flashcard("Largest planet?", "Jupiter"),
                    new Flashcard("Human body has how many bones?", "206"),
                    new Flashcard("Study of life?", "Biology")
                },
                ["geography"] = new List<Flashcard>()
                {
                    new Flashcard("Capital of France?", "Paris"),
                    new Flashcard("Largest continent?", "Asia"),
                    new Flashcard("Longest river?", "Nile"),
                    new Flashcard("Highest mountain?", "Mount Everest"),
                    new Flashcard("Country with most people?", "China"),
                    new Flashcard("Capital of Japan?", "Tokyo"),
                    new Flashcard("Ocean between Africa and Australia?", "Indian Ocean"),
                    new Flashcard("Desert in Africa?", "Sahara"),
                    new Flashcard("Capital of USA?", "Washington D.C."),
                    new Flashcard("Smallest country?", "Vatican City")
                }
            };

            // Default category
            Cards = Categories["math"];
        }

        public class Flashcard
        {
            public string Question { get; set; }
            public string Answer { get; set; }

            public Flashcard(string question, string answer)
            {
                Question = question;
                Answer = answer;
            }
        }
    }
}
