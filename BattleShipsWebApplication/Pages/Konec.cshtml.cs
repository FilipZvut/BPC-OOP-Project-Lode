using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BattleShipsWebApplication.Pages
{
    public class KonecModel : PageModel
    {
        public string Winner { get; set; }

        public IActionResult OnGet(string winner)
        {
            Winner = winner;
            return Page();
        }
    }
}
