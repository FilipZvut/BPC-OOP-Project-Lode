using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using projekt_lodě.Pages;
using static Board;

public class GameModel : PageModel
{
    public string Nazev1 { get; set; }
    public string Nazev2 { get; set; }
    public string gm { get; set; }


    
    private readonly ILogger<GameModel> _logger;

    public GameModel(ILogger<GameModel> logger)
    {
        _logger = logger;
    }
    public void OnGet(string data)
    {
        gm = data;
        GameManager gameManager = new GameManager(data);
        Nazev1 = gameManager.player1.Name;
        Nazev2 = gameManager.player2.Name;
    }

    public IActionResult OnPostPlay(string gamedata)
    {
         
        var data = gamedata;
        GameManager gameManager = new GameManager(data);


        _logger.LogInformation(data);

        return Page();
    }

    public IActionResult OnPostNahodne(string gamedata)
    {
        var data = gamedata;
        GameManager gameManager = new GameManager(data);
        gameManager.Play(0, 0, 1);
        data = gameManager.ToString();
        _logger.LogWarning(data);
        return RedirectToPage("/game", new { data });
    }

    public string GetCellSymbol(string cellState)
    {
        switch (cellState)
        {
            case "@":
                return "🌊";
            case "@@":
                return "🚢";
            case "@@@":
                return "💥";
            case "@@@@":
                return "❌";
            default:
                return "";
        }
    }


}
