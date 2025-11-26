using System;
using System.Collections.Generic;
using System.Linq;

namespace Codeworkhub.Helpers
{
    public class AiCommandHelper
    {
        private static readonly string[] GreetingResponses =
        {
            "Hello! 👋 I'm Phoibe, your interactive assistant!",
            "Hi there! 😊 I'm Phoibe — here to help guide you around.",
            "Hey! ✨ Phoibe at your service. How can I assist?"
        };

        private static readonly string[] Jokes =
        {
            "Why do programmers prefer dark mode? Because light attracts bugs! 🪲",
            "Why was the JavaScript developer sad? Because he didn't Node how to Express himself 😅",
            "Why did the function break up with the loop? It said it needed space! 😂"
        };

        public static (List<string> replies, string? actionUrl) ProcessCommand(string userText)
        {
            var responses = new List<string>();
            string text = userText.ToLower().Trim();
            string? action = null;

            // Helpers
            bool ContainsAny(params string[] phrases) => phrases.Any(p => text.Contains(p));

            bool AnyCommand(params string[] words) =>
                words.Any(w => text.Split(' ', '.', ',', '!', '?').Contains(w));

            // Dictionary of command actions
            var commandRoutes = new Dictionary<string[], string>
            {
                { new[] { "snake", "slither", "cobra", "python game" }, "/Apps/Snake/SnakeGame" },
                { new[] { "math", "quiz", "maths", "arithmetic" }, "/Apps/MathQuiz/Quiz" },
                { new[] { "rock paper scissors", "rps", "rock", "paper", "scissors" }, "/Apps/RockPaperScissor/Game" },
                { new[] { "typing", "typefast", "keyboard", "speed" }, "/Apps/Typefast/Typefast" },
                { new[] { "flash", "flashcards", "study", "cards" }, "/Apps/StudyTools/Flashcards" },
                { new[] { "unit", "converter", "convert", "convert units" }, "/Apps/Converter/UnitConverter" },
                { new[] { "flip", "flipcards", "flip game", "memory game", "cards" }, "/Apps/Flipgame/Flipcards" },
                { new[] { "learn", "tutorials", "Progrmming", "networking", "Science" }, "/Apps/Tutorials/TutorialsCenter" }
            };

            // Greetings
            if (ContainsAny("hello", "hi", "hey", "yo", "hiya", "greetings"))
            {
                responses.Add(GreetingResponses[new Random().Next(GreetingResponses.Length)]);
                responses.Add("You can ask me to open apps like Snake 🐍 or Math Quiz 🧠, or say `help` to see all commands.");
            }

            // About site
            if (ContainsAny("about site", "about the site", "what is this", "site info"))
            {
                responses.Add("This platform is your all-in-one interactive hub — games, study tools, quizzes, and experiments designed to be fun and educational. 🚀");
            }

            // About AI
            if (ContainsAny("about phoibe", "who are you", "who is phoibe", "your name"))
            {
                responses.Add("I'm Phoibe — your friendly virtual assistant. I can open apps, answer basic questions, tell jokes, and more! 🤖");
            }

            // Help / commands
            if (ContainsAny("help", "commands", "what can you do", "list commands"))
            {
                responses.Add("Here are some things you can say:\n" +
                              "• `play snake`\n" +
                              "• `open math quiz`\n" +
                              "• `start rock paper scissors`\n" +
                              "• `launch typing test`\n" +
                              "• `flashcards please`\n" +
                              "• `open unit converter`\n" +
                              "• `play flip cards`\n" +
                              "• `tell me a joke`\n" +
                              "• `about site`\n" +
                              "• `about phoibe`\n" +
                              "• `lets learn`");
            }

            // ==== Action Routing ====
            foreach (var route in commandRoutes)
            {
                if (route.Key.Any(k => text.Contains(k)))
                {
                    action = route.Value;
                    responses.Add($"Opening {route.Value.Split('/').Last()}… 🚀");
                    break;
                }
            }

            // ======================= EASTER EGG REDEMPTION ==========================
            if (text.StartsWith("redeem"))
            {
                var code = text.Replace("redeem", "").Trim();

                var result = EasterEggHelper.ProcessEasterEgg(code);

                if (result.found)
                    responses.Add(result.message);
                else
                    responses.Add(result.message);

                return (responses, action);
            }

            // Fun features
            if (ContainsAny("joke", "funny", "laugh"))
            {
                responses.Add(Jokes[new Random().Next(Jokes.Length)]);
            }

            if (ContainsAny("dance"))
            {
                responses.Add("🕺 *Phoibe does a questionable robotic dance. Audience confused but supportive.*");
            }

            // If user tried to command but no match
            if (responses.Count == 0 && ContainsAny("open", "start", "launch", "play", "run"))
            {
                responses.Add("I think you're trying to start something — but I'm not sure which app. Try one of these:");
                responses.Add("Snake 🐍 | Math Quiz 🧮 | Rock Paper Scissors ✂️ | Typing Test ⌨️ | Flashcards 🎓");
            }

            // Fallback
            if (responses.Count == 0 && action == null)
            {
                responses.Add("Hmm... I don't understand that yet 🤔");
                responses.Add("Try saying `help` to see what I can do.");
            }

            return (responses, action);
        }
    }
}
