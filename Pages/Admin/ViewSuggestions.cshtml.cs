using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Codeworkhub.Pages.Admin
{
    public class ViewSuggestionsModel : PageModel
    {
        public string SuggestionContent { get; set; }

        public void OnGet()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Suggestion.txt");

            SuggestionContent = System.IO.File.Exists(filePath)
                ? System.IO.File.ReadAllText(filePath)
                : "No suggestions have been submitted yet.";
        }
    }
}
