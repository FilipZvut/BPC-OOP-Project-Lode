using Battleships.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Battleships.Pages;
public class GameModel : PageModel
{
    private readonly ILogger<GameModel> _logger;
    public string Nazev1 { get; set; }
    public string Nazev2 { get; set; }
    public string gm { get; set; }

    public GameModel(ILogger<GameModel> logger)
    {
        _logger = logger;
    }
    public void OnGet(string data)
    {
        gm = data;
        GameManager gameManager = new GameManager(data);
        Nazev1 = gameManager.Player1.Name;
        Nazev2 = gameManager.Player2.Name;
    }
    public IActionResult OnPost(string gamedata)
    {
        var data = gamedata;
        GameManager gameManager = new GameManager(data);
        string row = Request.Form["row"];
        string col = Request.Form["col"];
        string id = Request.Form["id"];

        int rowINT = int.Parse(row);
        int colINT = int.Parse(col);
        int idINT = int.Parse(id);
        gameManager.Play(rowINT, colINT, idINT);
        data = gameManager.ToString();
        _logger.LogInformation($"Player{idINT} played: {rowINT},{colINT}");

        if (gameManager.TestVyhry() == 0)
            return RedirectToPage("/game", new { data });
        else if (gameManager.TestVyhry() == 1)
            return RedirectToPage("/konec", new { gameManager.Player2.Name });
        else
            return RedirectToPage("/konec", new { gameManager.Player1.Name });
    }

    public string GetCellSymbol(string cellState)
    {
        switch (cellState)
        {
            case "@":
                return "🌊";
            case "@@":
                return "🌊";//🚢
            case "@@@":
                return "💥";
            case "@@@@":
                return "❌";
            default:
                return "";
        }
    }


}
