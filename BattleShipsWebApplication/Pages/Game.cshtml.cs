using Microsoft.AspNetCore.Mvc.RazorPages;

public class GameModel : PageModel
{
    public GameManager GameManager { get; set; }

    public void OnGet(GameManager gameManager)
    {
        GameManager = gameManager;
    }
}
