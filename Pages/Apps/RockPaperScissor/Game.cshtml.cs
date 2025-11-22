using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Codeworkhub.Pages.Apps.RockPaperScissor
{
    public class GameModel : PageModel
    {
        private static readonly Random _rand = new Random();

        [BindProperty] public int PlayerScore { get; set; }
        [BindProperty] public int CpuScore { get; set; }
        [BindProperty] public int Round { get; set; } = 1;
        [BindProperty] public string ResultMessage { get; set; }
        [BindProperty] public string CpuChoice { get; set; }

        public void OnGet() { }

        public IActionResult OnPostPlay(string choice)
        {
            var options = new[] { "rock", "paper", "scissors" };
            CpuChoice = options[_rand.Next(options.Length)];

            if (choice == CpuChoice)
            {
                ResultMessage = $"Draw! Both picked {choice}.";
            }
            else if ((choice == "rock" && CpuChoice == "scissors") ||
                     (choice == "paper" && CpuChoice == "rock") ||
                     (choice == "scissors" && CpuChoice == "paper"))
            {
                PlayerScore++;
                ResultMessage = $"You Win! {choice} beats {CpuChoice}.";
            }
            else
            {
                CpuScore++;
                ResultMessage = $"CPU Wins! {CpuChoice} beats {choice}.";
            }

            Round++;

            if (PlayerScore == 2 || CpuScore == 2)
            {
                return Page();
            }

            if (Round > 3)
                return Page();

            return Page();
        }

        public IActionResult OnPostReset()
        {
            PlayerScore = 0;
            CpuScore = 0;
            Round = 1;
            ResultMessage = null;
            CpuChoice = null;

            return RedirectToPage();
        }
    }
}
