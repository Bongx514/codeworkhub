using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Codeworkhub.Pages.Apps.TypeFast
{
    public class TypefastModel : PageModel
    {
        public List<string> Words = new()
        {
            "future", "computer", "science", "creative", "developer", "matrix", "galaxy", "vision",
            "rocket", "digital", "system", "neon", "energy", "planet", "mission", "cyber", "gravity",
            "quantum", "binary", "design", "electric", "innovation", "charger", "project"
        };

        [BindProperty] public int CorrectWords { get; set; }
        public int WPM { get; set; }
        public int Accuracy { get; set; }
        public bool ShowResult { get; set; }

        public void OnGet() { }

        public void OnPost()
        {
            WPM = CorrectWords;
            Accuracy = WPM * 5; // temporary visual metric
            ShowResult = true;
        }
    }
}
