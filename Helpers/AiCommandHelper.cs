namespace Codeworkhub.Helpers
{
    public class AiCommandHelper
    {
        public static (List<string> replies, string? actionUrl) ProcessCommand(string userText)
        {
            var responses = new List<string>();
            string text = userText.ToLower().Trim();
            string? action = null;

            // Helpers for parsing
            bool IsCommand(params string[] keywords) =>
                keywords.Any(k => text.Split(' ').Any(word => word == k) || text.Contains($" {k} "));

            bool ContainsAny(params string[] phrases) =>
                phrases.Any(p => text.Contains(p));


            if (ContainsAny("hello", "hi"))
            {
                responses.Add("Hello..I'm Phoibe, the AI assistant of this site. I can open games, answer simple questions, " +
                              "tell a joke, and give guidance about the site. My intelligence is basic, but I learn over time! \n");
                responses.Add("Here are some commands you can try:\n" +
                              "• `play snake` - Start the Snake Game 🐍\n" +
                              "• `open math quiz` - Launch Maths Quiz 🧠\n" +
                              "• `start rock paper scissors` - Play Rock Paper Scissors ✂️\n" +
                              "• `launch typing test` - Test typing speed ⌨️\n" +
                              "• `flashcards please` - Open Flashcards 🎓\n" +
                              "• `tell me a joke` - I’ll try to make you laugh 😅\n" +
                              "• `about site` - Learn about this website\n" +
                              "• `about phoibe` - Learn about me");
            }
            // ===== ABOUT SITE / AI ====
            if (ContainsAny("about site", "what is this site", "site info"))
            {
                responses.Add("This site is a small hub of interactive web apps designed to entertain and educate. " +
                              "You can play games like Snake, Rock Paper Scissors, or Maths Quiz, " +
                              "practice typing skills, or use Flashcards to study.");
            }

            if (ContainsAny("about phoibe", "who are you", "who is phoibe", "about ai", "what is your name", "name"))
            {
                responses.Add("I'm Phoibe, the AI assistant of this site. I can open games, answer simple questions, " +
                              "tell a joke, and give guidance about the site. My intelligence is basic, but I learn over time!");
            }

            if (ContainsAny("list commands", "available commands", "help"))
            {
                responses.Add("Here are some commands you can try:\n" +
                              "• `play snake` - Start the Snake Game 🐍\n" +
                              "• `open math quiz` - Launch Maths Quiz 🧠\n" +
                              "• `start rock paper scissors` - Play Rock Paper Scissors ✂️\n" +
                              "• `launch typing test` - Test typing speed ⌨️\n" +
                              "• `flashcards please` - Open Flashcards 🎓\n" +
                              "• `tell me a joke` - I’ll try to make you laugh 😅\n" +
                              "• `about site` - Learn about this website\n" +
                              "• `about phoibe` - Learn about me");
            }

            // ===== GAME ROUTERS (specific commands first) =====
            if (ContainsAny("snake", "slither", "cobra", "python game"))
            {
                action = "/Apps/Snake/SnakeGame";
                responses.Add("Launching Snake 🐍. Good luck!");
            }
            else if (ContainsAny("math", "quiz", "maths", "arithmetic"))
            {
                action = "/Apps/MathQuiz/Quiz";
                responses.Add("Opening Maths Quiz 🧮. Sharpen your brain!");
            }
            else if (ContainsAny("rock paper scissors", "rps") || IsCommand("rock", "paper", "scissors"))
            {
                action = "/Apps/RockPaperScissor/Game";
                responses.Add("Opening Rock Paper Scissors ✂️. May the odds be in your favor!");
            }
            else if (ContainsAny("typing", "typefast", "speed", "keyboard"))
            {
                action = "/Apps/Typefast/Typefast";
                responses.Add("Typing Speed Test loading… ⌨️ Let's see how fast you can type!");
            }
            else if (ContainsAny("flash", "flashcards", "study"))
            {
                action = "/Apps/StudyTools/Flashcards";
                responses.Add("Opening Flashcards 🎓. Time to learn something new!");
            }

            // ===== GENERIC COMMAND PROMPT (if user used a verb like open/start but no specific app matched) =====
            if (responses.Count == 0 && ContainsAny("please", "create"))
            {
                responses.Add("I see you want me to do something. I can currently open these apps:");
                responses.Add("• Maths Quiz 🧮\n• Rock Paper Scissors ✂️\n• Typing Speed Test ⌨️\n• Flashcards 🎓\n• Snake 🐍");
            }

            // ===== FUN RESPONSES =====
            if (ContainsAny("joke", "funny"))
            {
                responses.Add("Here's a joke: Why was the JavaScript developer sad? Because he didn't Node how to Express himself.");
            }

            if (ContainsAny("dance"))
            {
                responses.Add("🕺 *Phoibe attempts a robotic dance move. It's not pretty, but it's entertaining.*");
            }

            // ===== FALLBACK =====
            if (responses.Count == 0 && action == null)
            {
                responses.Add("I'm not sure what you mean. Try one of the following:\n" +
                              "• `play snake`\n• `open math quiz`\n• `start rock paper scissors`\n• `launch typing test`\n" +
                              "• `flashcards please`\n• `tell me a joke`\n• `about site`\n• `about phoibe`\n• `list commands`");
            }

            return (responses, action);
        }
    }
}
