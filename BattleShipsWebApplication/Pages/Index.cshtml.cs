using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    public string WelcomeMessage { get; set; }

    public void OnGet()
    {
        WelcomeMessage = "dada";
    }
    public IActionResult OnPost(string player1Name, string player2Name)
    {
        GameManager gameManager = new GameManager();
        gameManager.GameCreated(player1Name, player2Name);
        return RedirectToPage("./Game", new { gameManager });
    }
}
