using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Battleships.Logic;

namespace Battleships.Pages;
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
        string row = Request.Form["row"];
        string col = Request.Form["col"];
        string id = Request.Form["id"];

        // Zde můžete provést další zpracování hodnot, například převést je na čísla, pokud jsou ve formátu řetězce
        int rowINT = int.Parse(row);
        int colINT = int.Parse(col);
        int idINT = int.Parse(id);
        gameManager.Play(rowINT, colINT, idINT);
        data = gameManager.ToString();
        _logger.LogWarning($"{rowINT}, {colINT}, {idINT}");
        if (gameManager.TestVyhry() == 0)
            return RedirectToPage("/game", new { data });
        else if (gameManager.TestVyhry() == 1)
            return RedirectToPage("/konec", new { gameManager.player2.Name });
        else
            return RedirectToPage("/konec", new { gameManager.player1.Name });
    }

    public string GetCellSymbol(string cellState)
    {
        switch (cellState)
        {
            case "@":
                return "🌊";
            case "@@":
                return "🌊";
            case "@@@":
                return "💥";
            case "@@@@":
                return "❌";
            default:
                return "";
        }
    }


}
