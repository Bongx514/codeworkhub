using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace Codeworkhub.Pages.Apps.MathQuiz
{
    public class QuizModel : PageModel
    {
        public class MathQuestion
        {
            public string? QuestionText { get; set; }
            public decimal? Answer { get; set; }
        }

        public class ReviewAnswer
        {
            public string? Question { get; set; }
            public decimal? CorrectAnswer { get; set; }
            public decimal? UserAnswer { get; set; }
        }

        public List<MathQuestion> Questions { get; set; } = new();
        [BindProperty] public List<decimal>? Answers { get; set; }
        public List<ReviewAnswer> IncorrectAnswers { get; set; } = new();

        public bool ShowResults { get; set; }
        public decimal Score { get; set; }
        public string GradeMessage { get; set; }
        public string GradeColor { get; set; }

        public void OnGet()
        {
            GenerateRandomQuestions();
            TempData["quizQuestions"] = JsonConvert.SerializeObject(Questions);
        }

        public void OnPost()
        {
            var storedJson = TempData["quizQuestions"]?.ToString();
            if (storedJson != null)
                Questions = JsonConvert.DeserializeObject<List<MathQuestion>>(storedJson)!;

            Score = 0;

            for (int i = 0; i < Questions.Count; i++)
            {
                if (Answers![i] == Questions[i].Answer)
                {
                    Score++;
                }
                else
                {
                    IncorrectAnswers.Add(new ReviewAnswer
                    {
                        Question = Questions[i].QuestionText,
                        CorrectAnswer = Questions[i].Answer,
                        UserAnswer = Answers[i]
                    });
                }
            }

            ShowResults = true;

            if (Score >= 9) { GradeMessage = "Legend! 🏆"; GradeColor = "text-yellow-400"; }
            else if (Score >= 7) { GradeMessage = "Great Work! ⭐"; GradeColor = "text-green-400"; }
            else if (Score >= 5) { GradeMessage = "Keep Practicing 💪"; GradeColor = "text-orange-400"; }
            else { GradeMessage = "Try Again! 📘"; GradeColor = "text-red-400"; }
        }

        private void GenerateRandomQuestions()
        {
            if (Questions.Count > 0) return;

            var rand = new Random();
            string[] operators = { "+", "-", "*", "/" };

            for (int i = 0; i < 10; i++)
            {
                int a = rand.Next(5, 50);
                int b = rand.Next(2, 12);
                string op = operators[rand.Next(operators.Length)];

                int answer = op switch
                {
                    "+" => a + b,
                    "-" => a - b,
                    "*" => a * b,
                    "/" => a / b,
                    _ => 0
                };

                Questions.Add(new MathQuestion
                {
                    QuestionText = $"{a} {op} {b}",
                    Answer = answer
                });
            }
        }
    }

}
