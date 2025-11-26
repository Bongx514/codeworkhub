using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Codeworkhub.Pages.Apps.Tutorials
{
    public class ProgramingModel : PageModel
    {
        public List<TutorialCard> Frameworks { get; set; }
        public List<TutorialCard> Languages { get; set; }
        public List<TutorialCard> CloudServices { get; set; }

        public void OnGet()
        {
            Frameworks = new List<TutorialCard>
            {
                new("Angular", "A powerful front-end framework for building dynamic web apps.",
                    "Use: Web applications | Pros: TypeScript, scalable, great tooling | Cons: Steep learning curve",
                    "https://angular.io/docs",
                    "https://www.youtube.com/results?search_query=angular+tutorial+for+beginners"),

                new("React", "A library for building fast, interactive UIs with components.",
                    "Use: Web and Mobile | Pros: Virtual DOM, reusable components | Cons: JSX syntax learning curve",
                    "https://reactjs.org/docs/getting-started.html",
                    "https://www.youtube.com/results?search_query=react+tutorial+for+beginners"),

                new(".NET 8-10", "A versatile framework for building web, desktop, and cloud applications.",
                    "Use: Full-stack apps | Pros: Cross-platform, high performance | Cons: Large ecosystem, heavier than JS frameworks",
                    "https://learn.microsoft.com/en-us/dotnet/",
                    "https://www.youtube.com/results?search_query=.net+tutorial+for+beginners")
            };

            Languages = new List<TutorialCard>
            {
                new("C#", "A versatile object-oriented language used in .NET applications.",
                    "Use: Desktop, Web, Games | Pros: Strong typing, IDE support | Cons: Windows-centric ecosystem",
                    "https://learn.microsoft.com/en-us/dotnet/csharp/",
                    "https://www.youtube.com/results?search_query=c%23+tutorial+for+beginners"),

                new("C++", "A powerful low-level language for performance-critical applications.",
                    "Use: Systems, Games | Pros: Fast, memory control | Cons: Complex syntax",
                    "https://isocpp.org/get-started",
                    "https://www.youtube.com/results?search_query=c%2B%2B+tutorial+for+beginners"),

                new("JavaScript", "The language of the web for building dynamic web pages.",
                    "Use: Front-end, Back-end | Pros: Easy to start, huge ecosystem | Cons: Loosely typed",
                    "https://developer.mozilla.org/en-US/docs/Web/JavaScript",
                    "https://www.youtube.com/results?search_query=javascript+tutorial+for+beginners"),

                new("PHP", "A server-side scripting language for web development.",
                    "Use: Backend Web | Pros: Easy setup, large community | Cons: Inconsistent syntax",
                    "https://www.php.net/docs.php",
                    "https://www.youtube.com/results?search_query=php+tutorial+for+beginners"),

                new("Node.js", "A JavaScript runtime for building fast, scalable back-end services.",
                    "Use: Backend | Pros: Non-blocking, huge ecosystem | Cons: Callback complexity",
                    "https://nodejs.org/en/docs/",
                    "https://www.youtube.com/results?search_query=node.js+tutorial+for+beginners")
            };

            CloudServices = new List<TutorialCard>
            {
                new("Vercel", "A cloud platform to deploy frontend frameworks and static sites.",
                    "Pros: Instant deployment, Git integration | Cons: Limited backend support",
                    "https://vercel.com/docs",
                    "https://www.youtube.com/results?search_query=vercel+tutorial+for+beginners"),

                new("Azure", "Microsoft's cloud platform for hosting, databases, and services.",
                    "Pros: Enterprise ready, scalable | Cons: Learning curve",
                    "https://learn.microsoft.com/en-us/azure/",
                    "https://www.youtube.com/results?search_query=azure+tutorial+for+beginners")
            };
        }

        public record TutorialCard(string Title, string Description, string UseProsCons, string OfficialDocs, string VideoLink);
    }
}
