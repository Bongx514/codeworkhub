namespace Codeworkhub.Helpers
{
    public class AiCommandHelper
    {
        public static (List<string> replies, string? actionUrl) ProcessCommand(string userText)
        {
            var responses = new List<string>();
            string text = userText.ToLower().Trim();
            string? action = null;

            // --- BASIC FUN COMMANDS ---
            if (text.Contains("hello") || text.Contains("hi"))
            {
                responses.Add("Hi! My name is Phoibe, pronounced 'Fu-Wee-Bee'. Nice to meet you! 😊 \n" +
                    "I’m currently still under development, and our team is working hard to get \n" +
                    "this AI integration running properly. It may take longer than expected, \n" +
                    "so please don’t get your hopes up too high just yet 😂 \n");
                responses.Add("LOL, seriously… come back tomorrow 😅 \n\n" +
                    "In the meantime, you can try any of the following: \n\n" +
                    "1. Maths Quiz \n" +
                    "2. Rock Paper Scissors \n" +
                    "3. Typing Speed Test \n" +
                    "4. Flashcards \n");
            }
            else if (text.Contains("please") || text.Contains("create"))
            {
                responses.Add("Hi there! Just so you know, I’m not using a real AI model yet, \n " +
                    "so I’m not extremely smart 😅. \n" +
                    "Also, my creators are still saving up AI API keys are expensive 😂 \n" +
                    "But don’t worry, I’m smart enough to open the following if you ask nicely: \n\n" +
                    "1. Maths Quiz \n" +
                    "2. Rock Paper Scissors \n" +
                    "3. Typing Speed Test \n" +
                    "4. Flashcards \n");
            }

            // --- OPEN SPECIFIC GAMES ---
            if (text.Contains("math") || text.Contains("quiz"))
            {
                action = "/Apps/MathQuiz/Quiz";
                responses.Add("Great choice! Launching Maths Quiz 🧮");
            }
            else if (text.Contains("rock") || text.Contains("paper") || text.Contains("scissors"))
            {
                action = "/Apps/RockPaperScissor/Game";
                responses.Add("Time to battle! Opening Rock Paper Scissors 🥊");
            }
            else if (text.Contains("typing") || text.Contains("speed"))
            {
                action = "/Apps/Typefast/Typefast";
                responses.Add("Let’s test your typing skills! ⌨️");
            }
            else if (text.Contains("flash") || text.Contains("study"))
            {
                action = "/Apps/StudyTools/Flashcards";
                responses.Add("Opening Flashcards! 🎓");
            }

            // --- FUN COMMANDS ---
            if (text.Contains("joke"))
            {
                responses.Add("Okay, here’s a joke: Why did the function break up with the loop? Because it couldn’t \n" +
                    "handle the endless commitment 🤣");
            }

            if (text.Contains("dance"))
            {
                responses.Add("🕺💃 *Phoibe attempts an awkward robotic dance* 😂");
            }

            if (responses.Count == 0 && action == null)
            {
                responses.Add("I’m not sure if I can help with that yet \n" +
                              "Try something like:\n" +
                              "• Open math quiz / typing speed / flashcards / rock paper scissors\n" +
                              "• Tell me a joke\n\n" +
                              "Don’t worry, my creators are working hard to make me fully functional soon 🚀");
            }

            return (responses, action);
        }
    }
}
