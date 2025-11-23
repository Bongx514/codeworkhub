using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Codeworkhub.Pages
{
    public class ComingSoonModel : PageModel
    {
        [BindProperty] public string Name { get; set; }
        [BindProperty] public string Source { get; set; }
        [BindProperty] public string Suggestion { get; set; }

        public void OnGet() { }

        public IActionResult OnPostSuggest()
        {
            try
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Suggestion.txt");

                string entry =
                        $@"Name: {(string.IsNullOrWhiteSpace(Name) ? "Anonymous" : Name)}
                        Source: {Source}
                        Suggestion: {Suggestion}
                        ------------------------------------------------------------";

                if (!System.IO.File.Exists(filePath))
                {
                    System.IO.File.WriteAllText(filePath, entry);
                }
                else
                {
                    System.IO.File.AppendAllText(filePath, Environment.NewLine + entry);
                }

                TempData["Success"] = "true";
            }
            catch
            {
                TempData["Error"] = "true";
            }

            return RedirectToPage();
        }
    }
}
