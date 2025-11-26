using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Codeworkhub.Pages.Apps.Tutorials
{
    public class TutorialsCenterModel : PageModel
    {
        public List<CardItem> Cards { get; set; }

        public void OnGet()
        {
            string comingSoon = "/ComingSoon";

            Cards = new List<CardItem>
            {
                new("Programming", "Learn languages, frameworks, and coding fundamentals.", "/Apps/Tutorials/Programing", "💻"),
                new("Maths", "Master algebra, calculus, and problem-solving skills.", comingSoon, "🧮"),
                new("Science", "Explore physics, chemistry, biology, and more.", comingSoon, "🔬"),
                new("Networking", "Understand networks, protocols, and security basics.", comingSoon, "🌐"),
                new("IT Basics", "Learn hardware, software, and essential IT skills.", comingSoon, "🖥️"),
            };
        }

        public record CardItem(string Title, string Description, string Link, string Icon);
    }
}
